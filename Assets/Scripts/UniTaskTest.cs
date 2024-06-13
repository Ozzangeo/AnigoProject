using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniTaskTest : MonoBehaviour
{
    private bool _keyInputCheck;

    async UniTaskVoid Start()
    {
        Debug.Log("Hello");
        await UniTask.WaitUntil(() => _keyInputCheck);
        Debug.Log("World");
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log("아무 키 누름");
            _keyInputCheck = true;
        }
    }
}
