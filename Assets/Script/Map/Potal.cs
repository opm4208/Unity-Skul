using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (Input.GetKey(KeyCode.E))
        {

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        f.gameObject.SetActive(false);
    }
}
