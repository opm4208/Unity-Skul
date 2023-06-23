using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBall : EnemyBall
{
    // 몬스터랑 벽이랑 구분되게 만들어야함
    private bool rbsprite;
    private bool hitCheck;
    private SpriteRenderer spriteRenderer;
    private Coroutine ballResource;
    private Transform head;
    private Rigidbody2D rb;
    private float quaternion;

    private void Start()
    {
        head = gameObject.transform;
        GameManager.Player.head = head;
        quaternion = 0;
        rbsprite = GameManager.Player.rbSprite.flipX;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        ballResource = StartCoroutine(BallResource());
        if (rbsprite)
            spriteRenderer.flipX = true;
    }
    protected override void Update()
    {
        if (!hitCheck)
        {
            if (rbsprite)
            {
                transform.Translate(Vector2.left * 3 * Time.deltaTime, Space.World);
                if (quaternion >= 360)
                    quaternion = 0;
                transform.rotation = Quaternion.Euler(0f, 0f, quaternion);
                quaternion += 1;
            }
            else
            {
                transform.Translate(Vector2.right * 3 * Time.deltaTime, Space.World);
                if (quaternion <= -360)
                    quaternion = 0;
                transform.rotation = Quaternion.Euler(0f, 0f, quaternion);
                quaternion -= 1;
            }
        }
        else
        {
            if (rbsprite)
            {
                transform.Translate(Vector2.right * 0.5f * Time.deltaTime, Space.World);
                if (quaternion <= -360)
                    quaternion = 0;
                transform.rotation = Quaternion.Euler(0f, 0f, quaternion);
                quaternion -= 0.1f;
            }
            else
            {
                transform.Translate(Vector2.left * 0.5f * Time.deltaTime, Space.World);
                if (quaternion >= 360)
                    quaternion = 0;
                transform.rotation = Quaternion.Euler(0f, 0f, quaternion);
                quaternion += 0.1f;
            }
        }
    }
    IEnumerator BallResource()
    {
        yield return new WaitForSeconds(6);
        GameManager.Resource.Destroy(transform.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitCheck = true;
        if (layerMask.IsContain(collision.gameObject.layer))
        {
            collision.gameObject.GetComponent<Monster>().Hit(damage);
        }
        rb.gravityScale = 1;
        this.gameObject.layer = 9;
    }
}
