using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
	[SerializeField] private float m_speed = 20.0f;
	[SerializeField] private AttackBehaviour m_attack;

	[SerializeField] private AttackBehaviour[] m_attackBefaviours;
	private int m_weaponIndex;

	private void Awake() {
		m_attackBefaviours = Resources.LoadAll<AttackBehaviour>("Attacks/");
		m_weaponIndex = 0;
		m_attack = m_attackBefaviours[0];
	}

	private void Start() {
		Reset();
	}

	public void ChangeWeapon() {
		m_weaponIndex = (m_weaponIndex + 1) % m_attackBefaviours.Length;
		m_attack = m_attackBefaviours[m_weaponIndex];

	}

	public void ChangeAttackBehaviour(AttackBehaviour attack) {
		m_attack = attack;
	}

	public void ExecuteAttack() {
		m_attack.Attack();
	}

	public void Reset() {
		transform.position = Vector3.zero;
	}

	public void MoveTo(Vector2 dir) {
		Vector3 moveVec = dir * m_speed;
		transform.position += moveVec * Time.deltaTime;
	}
}
