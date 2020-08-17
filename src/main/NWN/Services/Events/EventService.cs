using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using NWN.API;
using NWN.API.Events;

namespace NWN.Services
{
  [ServiceBinding(typeof(IScriptDispatcher))]
  [ServiceBinding(typeof(EventService))]
  public sealed class EventService : IScriptDispatcher
  {
    private static readonly Logger Log = LogManager.GetCurrentClassLogger();

    // Type info cache
    private readonly Dictionary<Type, IEventAttribute> cachedEventInfo = new Dictionary<Type, IEventAttribute>();

    // Lookup Data
    private readonly Dictionary<string, EventHandler> scriptToEventMap = new Dictionary<string, EventHandler>();
    private readonly Dictionary<Type, EventHandler> typeToHandlerMap = new Dictionary<Type, EventHandler>();

    /// <summary>
    /// Removes an existing global event handler that was added using <see cref="SubscribeAll{TEvent}"/>.
    /// </summary>
    /// <param name="existingHandler">The existing handler/callback.</param>
    /// <typeparam name="TEvent">The event to unsubscribe from.</typeparam>
    public void UnsubscribeAll<TEvent>(Action<TEvent> existingHandler) where TEvent : Event<TEvent>
    {
      if (typeToHandlerMap.TryGetValue(typeof(TEvent), out EventHandler eventHandler))
      {
        eventHandler.Unsubscribe(existingHandler);
      }
    }

    /// <summary>
    /// Removes an existing event handler from an object that was added using <see cref="Subscribe{TObject,TEvent}"/>.
    /// </summary>
    /// <param name="nwObject">The object containing the existing subscription.</param>
    /// <param name="existingHandler">The existing handler/callback.</param>
    /// <typeparam name="TObject">The type of nwObject.</typeparam>
    /// <typeparam name="TEvent">The event to unsubscribe from.</typeparam>
    public void Unsubscribe<TObject, TEvent>(TObject nwObject, Action<TEvent> existingHandler) where TEvent : Event<TObject, TEvent>, new() where TObject : NwObject
    {
      if (typeToHandlerMap.TryGetValue(typeof(TEvent), out EventHandler eventHandler))
      {
        eventHandler.Unsubscribe(nwObject, existingHandler);
      }
    }

    /// <summary>
    /// Adds the specified object to the global dispatch list for the specified event.
    /// </summary>
    /// <param name="nwObject">The object to add.</param>
    /// <typeparam name="TObject">The type of nwObject.</typeparam>
    /// <typeparam name="TEvent">The event to add this object to.</typeparam>
    public void Register<TObject, TEvent>(TObject nwObject) where TEvent : Event<TObject, TEvent>, new() where TObject : NwObject
    {
      EventHandler eventHandler = GetOrCreateHandler<TEvent>();
      CheckEventHooked<TObject, TEvent>(nwObject, eventHandler);
    }

    /// <summary>
    /// Subscribes to the specified event.
    /// </summary>
    /// <param name="handler">The callback function/handler for this event.</param>
    /// <typeparam name="TEvent">The event to subscribe to.</typeparam>
    public void SubscribeAll<TEvent>(Action<TEvent> handler) where TEvent : Event<TEvent>, new()
    {
      EventHandler eventHandler = GetOrCreateHandler<TEvent>();
      eventHandler.Subscribe(handler);
    }

    /// <summary>
    /// Subscribes to the specified event on the given object.
    /// </summary>
    /// <param name="nwObject">The subscribe target for this event.</param>
    /// <param name="handler">The callback function/handler for this event.</param>
    /// <typeparam name="TObject">The type of nwObject.</typeparam>
    /// <typeparam name="TEvent">The event to subscribe to.</typeparam>
    public void Subscribe<TObject, TEvent>(TObject nwObject, Action<TEvent> handler) where TEvent : Event<TObject, TEvent>, new() where TObject : NwObject
    {
      EventHandler eventHandler = GetOrCreateHandler<TEvent>();
      eventHandler.Subscribe(nwObject, handler);
      CheckEventHooked<TObject, TEvent>(nwObject, eventHandler);
    }

    private void CheckEventHooked<TObject, TEvent>(TObject nwObject, EventHandler eventHandler) where TEvent : Event<TObject, TEvent>, new() where TObject : NwObject
    {
      // Nothing to hook.
      if (nwObject == null)
      {
        return;
      }

      // We only need to hook native events, as nwnx events are set up during handler creation.
      IEventAttribute eventAttribute = GetEventInfo(typeof(TEvent));
      eventAttribute.InitObjectHook<TObject, TEvent>(eventHandler, nwObject, eventHandler.ScriptName);
    }

    private EventHandler GetOrCreateHandler<TEvent>() where TEvent : Event<TEvent>, new()
    {
      Type type = typeof(TEvent);
      if (typeToHandlerMap.TryGetValue(type, out EventHandler eventHandler))
      {
        return eventHandler;
      }

      IEventAttribute eventInfo = GetEventInfo(type);
      eventHandler = CreateEventHandler<TEvent>();
      eventInfo.InitHook(eventHandler.ScriptName);

      return eventHandler;
    }

    private IEventAttribute GetEventInfo(Type type)
    {
      if (cachedEventInfo.TryGetValue(type, out IEventAttribute eventAttribute))
      {
        return eventAttribute;
      }

      eventAttribute = LoadEventInfo(type);
      cachedEventInfo[type] = eventAttribute;

      return eventAttribute;
    }

    private IEventAttribute LoadEventInfo(Type type)
    {
      object eventAttribute = type.GetCustomAttributes(typeof(IEventAttribute), true).SingleOrDefault();
      if (eventAttribute != null)
      {
        return (IEventAttribute) eventAttribute;
      }

      throw new InvalidOperationException($"Event Type {type.GetFullName()} does not define an event info attribute!");
    }

    private EventHandler CreateEventHandler<TEvent>() where TEvent : Event<TEvent>, new()
    {
      EventHandler eventHandler = EventHandler.Create<TEvent>();

      scriptToEventMap[eventHandler.ScriptName] = eventHandler;
      typeToHandlerMap[typeof(TEvent)] = eventHandler;
      return eventHandler;
    }

    ScriptHandleResult IScriptDispatcher.ExecuteScript(string scriptName, uint oidSelf)
    {
      if (scriptToEventMap.TryGetValue(scriptName, out EventHandler eventHandler))
      {
        eventHandler.CallEvents(oidSelf.ToNwObject());
        return ScriptHandleResult.Handled;
      }

      return ScriptHandleResult.NotHandled;
    }
  }
}