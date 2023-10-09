using TMPro;
using UnityEngine;

public class Entity : MonoBehaviour {
	private EntiryConfig _config;
	private TMP_Text _nameText;
	private static readonly string ConfigFileName = "/PlayerConfig.json";
	private bool _canMove = true;

	private void OnEnable()
	{
		EventBus.Subscribe(RaceEventType.Countdown, StopEntity);
		EventBus.Subscribe(RaceEventType.Start, StartEntity);
		
	}

	private void OnDisable()
	{
		EventBus.UnSubscribe(RaceEventType.Countdown, StopEntity);
		EventBus.UnSubscribe(RaceEventType.Start, StartEntity);
	}

	private void StartEntity() => _canMove = true;
	private void StopEntity() => _canMove = false;

	private void Awake() {
		_nameText = GetComponentInChildren<TMP_Text>();
		EntiryConfig[] configArray = JsonHelper.LoadJsonFile<EntiryConfig>(Application.dataPath + ConfigFileName);
		_config = configArray[0];
	}

	private void Start() {
		_nameText.text = _config.name;
	}

	private void Update() {
		if (_canMove) {
			float x = Input.GetAxisRaw("Horizontal");
			float y = Input.GetAxisRaw("Vertical");
			Vector3 move = new Vector3(x, y) * _config.moveSpeed;
			transform.position += move * Time.deltaTime;
		}
	}
}
