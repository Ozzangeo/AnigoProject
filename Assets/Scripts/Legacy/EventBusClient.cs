using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBusClient : MonoBehaviour
{
	private void Start()
	{
		EventBus.Publish(RaceEventType.Countdown);
	}
}
