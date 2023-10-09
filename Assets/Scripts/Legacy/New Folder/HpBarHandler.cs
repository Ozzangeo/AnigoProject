

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarHandler : MonoBehaviour, Observer
{
	[SerializeField] private Image[] _hpBarImages;
	private static readonly int MaxHealth = 100;

	public void Notify(ObserverSubject subject)
	{
		HpSetter hpSetter = subject as HpSetter;
		int index = hpSetter.Index;
		int health = hpSetter.Health;

		_hpBarImages[index].fillAmount = (float)health / MaxHealth;
	}
}
