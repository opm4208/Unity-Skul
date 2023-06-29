using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    private void Start()
    {
        GameManager.Player.player.position = transform.position;
    }
}
