using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class StartPortal : MonoBehaviour
{
    bool trigger;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!trigger)
        {
            trigger = true;
            GameManager.PortalManager.stageCount++;
            UnitySceneManager.LoadSceneAsync("StartScene");
        }
        //GameManager.Pool.canvasRoot.transform.GetChild(0).gameObject.SetActive(true);
    }
}
