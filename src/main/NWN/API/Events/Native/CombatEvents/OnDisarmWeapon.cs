using System;
using System.Runtime.InteropServices;
using NWN.Native.API;
using NWN.Services;
using Feat = NWN.API.Constants.Feat;

namespace NWN.API.Events
{
  public sealed class OnDisarmWeapon : IEvent
  {
    public bool PreventDisarm { get; set; }

    public Lazy<bool> Result { get; private set; }

    public NwGameObject DisarmedObject { get; private init; }

    public NwGameObject DisarmedBy { get; private init; }

    public Feat Feat { get; private init; }

    NwObject IEvent.Context => DisarmedObject;

    internal sealed unsafe class Factory : NativeEventFactory<Factory.ApplyDisarmHook>
    {
      internal delegate int ApplyDisarmHook(void* pEffectHandler, void* pObject, void* pEffect, int bLoadingGame);

      protected override FunctionHook<ApplyDisarmHook> RequestHook()
      {
        delegate* unmanaged<void*, void*, void*, int, int> pHook = &OnApplyDisarm;
        return HookService.RequestHook<ApplyDisarmHook>(pHook, NWNXLib.Functions._ZN21CNWSEffectListHandler13OnApplyDisarmEP10CNWSObjectP11CGameEffecti, HookOrder.Early);
      }

      [UnmanagedCallersOnly]
      private static int OnApplyDisarm(void* pEffectHandler, void* pObject, void* pEffect, int bLoadingGame)
      {
        CNWSObject gameObject = new CNWSObject(pObject, false);
        CGameEffect gameEffect = new CGameEffect(pEffect, false);

        OnDisarmWeapon eventData = new OnDisarmWeapon
        {
          DisarmedObject = gameObject.m_idSelf.ToNwObject<NwGameObject>(),
          DisarmedBy = gameEffect.m_oidCreator.ToNwObject<NwGameObject>(),
          Feat = gameEffect.GetInteger(0) == 1 ? Feat.ImprovedDisarm : Feat.Disarm
        };

        eventData.Result = new Lazy<bool>(() => !eventData.PreventDisarm && Hook.CallOriginal(pEffectHandler, pObject, pEffect, bLoadingGame).ToBool());
        ProcessEvent(eventData);

        return eventData.Result.Value.ToInt();
      }
    }
  }
}
