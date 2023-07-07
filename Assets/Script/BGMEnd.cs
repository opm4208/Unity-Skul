using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMEnd : MonoBehaviour
{
    private void Update()
    {
        if(GameManager.PortalManager.stageCount == 4)
        {
            Destroy(gameObject);
        }
    }
}
