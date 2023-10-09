using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {
	[SerializeField] private Controller m_controller;
	private ICommand m_moveUp;
	private ICommand m_moveDown;
	private ICommand m_moveLeft;
	private ICommand m_moveRight;
	private ICommand m_attackCommand;

	[SerializeField] private Invoker m_replayInvoker;

	private void Awake() {
		m_moveUp = new MoveUp(m_controller);
		m_moveDown = new MoveDown(m_controller);
		m_moveLeft = new MoveLeft(m_controller);
		m_moveRight = new MoveRight(m_controller);
		m_attackCommand = new AttackCommand(m_controller);
	}

	private void Start() {
		m_replayInvoker.StartRecord();
	}

	private void Update() {
		if (Input.GetKey(KeyCode.UpArrow)) { m_replayInvoker.ExecuteCommand(m_moveUp); }
		if (Input.GetKey(KeyCode.LeftArrow)) { m_replayInvoker.ExecuteCommand(m_moveLeft); }
		if (Input.GetKey(KeyCode.DownArrow)) { m_replayInvoker.ExecuteCommand(m_moveDown); }
		if (Input.GetKey(KeyCode.RightArrow)) { m_replayInvoker.ExecuteCommand(m_moveRight); }

		if (Input.GetKeyDown(KeyCode.Z)) { m_attackCommand.Execute(); }
		if (Input.GetKeyDown(KeyCode.X)) { m_controller.ChangeWeapon(); }

		if (Input.GetKeyDown(KeyCode.Space)) {
			m_controller.Reset();
			m_replayInvoker.StartReplay();
		}
	}
}
