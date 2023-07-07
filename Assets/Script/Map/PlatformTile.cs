using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlatformTile : MonoBehaviour
{
    TilemapCollider2D tile;

    private void Awake()
    {
        tile = GetComponent<TilemapCollider2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(Input.GetKey(KeyCode.DownArrow)&& Input.GetKey(KeyCode.C))
        {
            tile.enabled = false;
            tile.enabled = true;
        }
    }
}
