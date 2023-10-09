using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : ICommand {
	private Controller m_controller;

	public MoveRight(Controller controller) {
		m_controller = controller;
	}

	public override void Execute() {
		m_controller.MoveTo(Vector2.right);
	}
}
