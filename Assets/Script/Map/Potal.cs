using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E)&&GameManager.Stage.monsterCount<1)
        {
            GameManager.Stage.NextStage();
            collision.gameObject.transform.position = GameManager.Stage.curStage.transform.GetChild(1).position;
        }
    }
}
