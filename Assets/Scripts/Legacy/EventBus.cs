using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventBus : MonoBehaviour
{
	private static readonly Dictionary<RaceEventType, UnityEvent> Events = new();
	
	public static void Subscribe(RaceEventType type, UnityAction listener)
	{
		if (Events.TryGetValue(type, out var @event))
		{
			@event.AddListener(listener);
		}
		else
		{
			@event = new();
			@event.AddListener(listener);
			Events.Add(type, @event);
		}
	}

	public static void UnSubscribe(RaceEventType type, UnityAction listener) {
		if (Events.TryGetValue(type, out var @event))
		{
			@event.RemoveListener(listener);
		}
	}

	public static void Publish(RaceEventType type)
	{
		if (Events.TryGetValue(type, out var @event))
		{
			@event.Invoke();
		}
	}
}
