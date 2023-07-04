using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class Potal : MonoBehaviour
{
    Transform f;
    SpriteRenderer spriteRenderer;
    SpriteRenderer changeSprite;

    private void Start()
    {
        f = transform.GetChild(0);
        spriteRenderer = GetComponent<SpriteRenderer>();
        changeSprite = transform.GetChild (1).GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = changeSprite.sprite;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        f.gameObject.SetActive(true);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.F))
        {
            GameManager.PortalManager.stageCount++;
            UnitySceneManager.LoadScene(GameManager.PortalManager.stageCount);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        f.gameObject.SetActive(false);
    }
}
