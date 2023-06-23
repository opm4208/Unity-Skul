using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSet : MonoBehaviour
{
    enum DoorType { Coin, Item, Head}
    private SpriteRenderer door;
    private Sprite change;
    private int count;

    private void Awake()
    {
        change = GameManager.Resource.Load<Sprite>("Map/CoinOpen");
        door = transform.GetChild(2).GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            door.sprite = change;
        }
    }
    private void MonsterCheck()
    {
        count = transform.childCount;
    }
}
