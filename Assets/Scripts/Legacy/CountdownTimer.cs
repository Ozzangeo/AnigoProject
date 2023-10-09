using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
	[SerializeField] private float _duration = 3.0f;

	private void OnEnable()
	{
		EventBus.Subscribe(RaceEventType.Countdown, StartTimer);
	}

	private void OnDisable()
	{
		
		EventBus.UnSubscribe(RaceEventType.Countdown, StartTimer);
	}

	private void StartTimer()
	{
		StartCoroutine(Countdown());
	}

	IEnumerator Countdown()
	{
		WaitForSeconds waitTime = new WaitForSeconds(1);
		float timeAgo = _duration;

		while (timeAgo > 0)
		{
			Debug.Log(timeAgo);

			yield return waitTime;

			timeAgo -= 1;
		}
		Debug.Log("Start");

		EventBus.Publish(RaceEventType.Start);
	}
}
