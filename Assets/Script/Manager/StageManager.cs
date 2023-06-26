using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public enum type { Coin, Head, Item };
    public int stageCount=0;
    public int monsterCount;
    public Stage stage;
    public GameObject Monster;
    public GameObject curStage;
    public GameObject prevStage;
    
    private void Start()
    {
        stage = GameManager.Resource.Load<Stage>("Map/Stage");
        curStage = GameManager.Resource.Instantiate(stage.stageArray[stageCount].map[0]);
        Monster = curStage.transform.GetChild(0).gameObject;
        monsterCount = Monster.transform.childCount;

        //stageData = stage.GetComponent<Stage>();
        //curStage = stageData.stageArray[stageCount].map[0];
    }
    public void NextStage()
    {
        prevStage = curStage;
        Destroy(prevStage);
        stageCount++;
        curStage = GameManager.Resource.Instantiate(stage.stageArray[stageCount].map[0]);
        Monster = curStage.transform.GetChild(0).gameObject;
        monsterCount = Monster.transform.childCount;
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
