using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HpSetter : ObserverSubject
{
	[SerializeField] private TMP_InputField _InputField;
	[SerializeField] private int _index;

	public int Health { get; private set; }
	public int Index => _index;

	private void Awake()
	{
		_InputField.onEndEdit.AddListener(OnEndEdit);
	}

	private void OnEnable()
	{
		var observer = GameObject.FindObjectOfType<HpBarHandler>();
		Attach(observer);
	}

	private void OnDisable()
	{
		var observer = GameObject.FindObjectOfType<HpBarHandler>();
		Detach(observer);
	}

	private void OnEndEdit(string str)
	{
		Health = int.Parse(str);
		NotifyObservers();
	}
}
