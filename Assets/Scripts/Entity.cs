using TMPro;
using UnityEngine;

public class Entity : MonoBehaviour {
	private EntiryConfig _config;
	private TMP_Text _nameText;
	private static readonly string ConfigFileName = "/PlayerConfig.json";

	private void Awake() {
		_nameText = GetComponentInChildren<TMP_Text>();
		EntiryConfig[] configArray = JsonHelper.LoadJsonFile<EntiryConfig>(Application.dataPath + ConfigFileName);
		_config = configArray[0];
	}

	private void Start() {
		_nameText.text = _config.name;
	}

	private void Update() {
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
		Vector3 move = new Vector3(x, y) * _config.moveSpeed;
		transform.position += move * Time.deltaTime;
	}
}
