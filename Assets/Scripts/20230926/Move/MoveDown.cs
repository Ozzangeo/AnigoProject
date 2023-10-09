using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : ICommand {
	private Controller m_controller;

	public MoveDown(Controller controller) {
		m_controller = controller;
	}

	public override void Execute() {
		m_controller.MoveTo(Vector2.down);
	}
}
