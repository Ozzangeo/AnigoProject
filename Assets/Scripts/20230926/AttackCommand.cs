using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : ICommand {
	private Controller m_controller;
	public AttackCommand(Controller contorller) { 
		m_controller = contorller;
	}

	public override void Execute() {
		m_controller.ExecuteAttack();
	}
}
