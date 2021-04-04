using System;
using NWN.Native.API;
using NWN.Services;

namespace NWN.API.Events
{
  public class OnStealthModeUpdate : IEvent
  {
    /// <summary>
    /// Gets or sets an override behaviour to use if <see cref="EventType"/> is an Enter event.
    /// </summary>
    public StealthModeOverride EnterOverride { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this creature should not be allowed to exit stealth mode, if <see cref="EventType"/> is an Exit event.
    /// </summary>
    public bool PreventExit { get; set; }

    public ToggleModeEventType EventType { get; private init; }

    public NwCreature Creature { get; private init; }

    NwObject IEvent.Context => Creature;

    [NativeFunction(NWNXLib.Functions._ZN12CNWSCreature14SetStealthModeEh)]
    internal delegate void SetStealthModeHook(IntPtr pCreature, byte nStealthMode);

    internal class Factory : NativeEventFactory<SetStealthModeHook>
    {
      public Factory(Lazy<EventService> eventService, HookService hookService) : base(eventService, hookService) {}

      protected override FunctionHook<SetStealthModeHook> RequestHook(HookService hookService)
        => hookService.RequestHook<SetStealthModeHook>(OnSetStealthMode, HookOrder.Early);

      private void OnSetStealthMode(IntPtr pCreature, byte nStealthMode)
      {
        CNWSCreature creature = new CNWSCreature(pCreature, false);

        bool willBeStealthed = nStealthMode != 0;
        bool currentlyStealthed = creature.m_nStealthMode != 0;

        if (!currentlyStealthed && willBeStealthed)
        {
          HandleEnterStealth(creature, nStealthMode);
        }
        else if (currentlyStealthed && !willBeStealthed)
        {
          HandleExitStealth(creature, nStealthMode);
        }
        else
        {
          Hook.CallOriginal(pCreature, nStealthMode);
        }
      }

      private void HandleEnterStealth(CNWSCreature creature, byte nStealthMode)
      {
        OnStealthModeUpdate eventData = ProcessEvent(new OnStealthModeUpdate
        {
          Creature = creature.m_idSelf.ToNwObject<NwCreature>(),
          EventType = ToggleModeEventType.Enter
        });

        switch (eventData.EnterOverride)
        {
          case StealthModeOverride.ForceEnter:
            ForceEnterStealth(creature, nStealthMode);
            break;
          case StealthModeOverride.PreventHIPSEnter:
            PreventHIPSEnterStealth(creature, nStealthMode);
            break;
          case StealthModeOverride.PreventEnter:
            creature.ClearActivities(1);
            break;
          default:
            Hook.CallOriginal(creature, nStealthMode);
            break;
        }
      }

      private void HandleExitStealth(CNWSCreature creature, byte nStealthMode)
      {
        OnStealthModeUpdate eventData = ProcessEvent(new OnStealthModeUpdate
        {
          Creature = creature.m_idSelf.ToNwObject<NwCreature>(),
          EventType = ToggleModeEventType.Exit
        });

        if (eventData.PreventExit)
        {
          creature.SetActivity(1, true.ToInt());
        }
        else
        {
          Hook.CallOriginal(creature, nStealthMode);
        }
      }

      private void ForceEnterStealth(CNWSCreature creature, byte nStealthMode)
      {
        bool noHIPS = false;
        if (!creature.m_pStats.HasFeat((ushort)Feat.HideInPlainSight).ToBool())
        {
          creature.m_pStats.AddFeat((ushort)Feat.HideInPlainSight);
          noHIPS = true;
        }

        Hook.CallOriginal(creature, nStealthMode);

        if (noHIPS)
        {
          creature.m_pStats.RemoveFeat((ushort)Feat.HideInPlainSight);
        }
      }

      private void PreventHIPSEnterStealth(CNWSCreature creature, byte nStealthMode)
      {
        bool bHadHIPS = false;
        if (creature.m_pStats.HasFeat((ushort)Feat.HideInPlainSight).ToBool())
        {
          creature.m_pStats.RemoveFeat((ushort)Feat.HideInPlainSight);
          bHadHIPS = true;
        }

        Hook.CallOriginal(creature, nStealthMode);

        if (bHadHIPS)
        {
          creature.m_pStats.AddFeat((ushort)Feat.HideInPlainSight);
        }
      }
    }
  }
}