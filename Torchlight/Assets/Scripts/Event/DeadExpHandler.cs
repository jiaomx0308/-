using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadExpHandler : EventSystemEvent.IEventHandler
{
    public override void Init()
    {
        regEvent = new List<EventSystemEvent.EventType>();
        regEvent.Add(EventSystemEvent.EventType.DeadExp);
    }

    public override void OnEvent(EventSystemEvent evt)
    {
        Debug.Log("Dead Exp On Event");
        var deadExpEvt = evt as DeadExpEvent;
        var player = ObjectManager.Instance.GetPlayer();
    }
}

public class DeadExpEvent : EventSystemEvent
{
    public int monId;
    public int playerId;
    public int exp;

    public DeadExpEvent()
    {
        type = EventType.DeadExp;
    }
}
