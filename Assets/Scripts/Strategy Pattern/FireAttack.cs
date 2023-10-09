using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/AttackBehaviour/FireAttack", fileName = "FireAttack", order = 0)]
public class FireAttack : AttackBehaviour {
	public override void Attack() {
		Debug.Log("FireAttack.Attck()");
	}
}
