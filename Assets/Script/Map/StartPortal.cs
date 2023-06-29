using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class StartPortal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Pool.canvasRoot.transform.GetChild(0).gameObject.SetActive(true);
        UnitySceneManager.LoadSceneAsync("StartScene");
    }
}
