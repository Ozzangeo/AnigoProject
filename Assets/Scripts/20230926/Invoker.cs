using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Invoker : MonoBehaviour {
    private bool m_isRecoding;
    private bool m_isReplaying;
    private float m_replayTime;
    private float m_recordingTime;

    private SortedList<float, ICommand> m_recordedCommand;

	private void Awake() {
        m_recordedCommand = new();
	}

    public void StartRecord() {
        m_recordingTime = 0.0f;
        m_isRecoding = true;
        m_isReplaying = false;
    }

    public void StartReplay() {
        m_replayTime = 0.0f;
        m_isReplaying = true;
        m_isRecoding = false;

        if (m_recordedCommand.Count > 0) {
            m_recordedCommand.Reverse();
        }
    }

    public void ExecuteCommand(ICommand command) {
        command.Execute();

        if (m_isRecoding && !m_recordedCommand.TryGetValue(m_recordingTime, out var value)) {
            m_recordedCommand.Add(m_recordingTime, command);
        }
    }

	private void FixedUpdate() {
		if (m_isRecoding) {
            m_recordingTime += Time.fixedDeltaTime;
        }
        else if (m_isReplaying) {
            m_replayTime += Time.fixedDeltaTime;

            if (m_recordedCommand.Any()) {
                if (Mathf.Approximately(m_replayTime, m_recordedCommand.Keys[0])) {
                    m_recordedCommand.Values[0].Execute();
                    m_recordedCommand.RemoveAt(0);
                }
            } else {
                m_isReplaying = false;
            }
        }
	}
}
