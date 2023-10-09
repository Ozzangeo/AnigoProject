using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/AttackBehaviour/ThunderAttack", fileName = "ThunderAttack", order = 0)]
public class ThunderAttack : AttackBehaviour {
	public override void Attack() {
		Debug.Log("ThunderAttack.Attck()");
	}
}
