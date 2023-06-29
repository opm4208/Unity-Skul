using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public enum type { Coin, Head, Item };
    public int stageCount=0;
    public int monsterCount;
    private Sprite[] doorsp = new Sprite[5];    // (1. 코인, 2. 머리, 3. 아이템, 4. Npc, 5. 보스)
    public Stage stage;
    public GameObject Monster;
    public GameObject curStage;
    public GameObject prevStage;
    public GameObject door;
    
    private void Start()
    {
        stage = GameManager.Resource.Load<Stage>("Map/Stage");
        //curStage = GameManager.Resource.Instantiate(stage.stageArray[stageCount].map[0]);
        //Monster = curStage.transform.GetChild(0).gameObject;
        //monsterCount = Monster.transform.childCount;
        doorsp[0] = GameManager.Resource.Load<Sprite>("Map/Door/CoinOpen");
        doorsp[1] = GameManager.Resource.Load<Sprite>("Map/Door/HeadOpen");
        doorsp[2] = GameManager.Resource.Load<Sprite>("Map/Door/ItemOpen");
        doorsp[3] = GameManager.Resource.Load<Sprite>("Map/Door/NpcOpen");
        doorsp[4] = GameManager.Resource.Load<Sprite>("Map/Door/BossOpen");
    }
    public void NextStage()
    {
        prevStage = curStage;
        Destroy(prevStage);
        stageCount++;
        curStage = GameManager.Resource.Instantiate(stage.stageArray[stageCount].map[0]);
        Monster = curStage.transform.GetChild(0).gameObject;
        monsterCount = Monster.transform.childCount;
        door = curStage.transform.GetChild(2).gameObject;
    }
    public void StageCheck()
    {
        if (monsterCount < 1)
        {
            SpriteRenderer doorSpRender = door.GetComponent<SpriteRenderer>();
            if (door.tag == "Coin")
            {
                doorSpRender.sprite = doorsp[0];
            }
            else if(door.tag == "Head")
            {
                doorSpRender.sprite = doorsp[1];
            }
            else if (door.tag == "Item")
            {
                doorSpRender.sprite = doorsp[2];
            }
            else if (door.tag == "Npc")
            {
                doorSpRender.sprite = doorsp[3];
            }
            else if (door.tag == "Boss")
            {
                doorSpRender.sprite = doorsp[4];
            }
            door.AddComponent<Potal>();
        }
    }
    public void StageCreat(type doorType)
    {
        if (stageCount > 0 && stageCount < 3)
        {
            curStage = GameManager.Resource.Load<GameObject>($"Map/{stageCount}{doorType}");
        }
        else
        {
            curStage = GameManager.Resource.Load<GameObject>($"Map/{stageCount}");
        }
    }
}
