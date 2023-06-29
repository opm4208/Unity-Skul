using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetting : MonoBehaviour
{
    CinemachineVirtualCamera virtualCamera;
    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        virtualCamera.Follow = GameManager.Player.player;
    }
}
