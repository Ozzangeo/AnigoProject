using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : ICommand {
	private Controller m_controller;

	public MoveUp(Controller controller) {
		m_controller = controller;
	}

	public override void Execute() {
		m_controller.MoveTo(Vector2.up);
	}
}
