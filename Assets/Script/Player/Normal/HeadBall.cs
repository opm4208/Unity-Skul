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
    public Rigidbody2D rb;
    private float quaternion;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        GameManager.Player.head = transform;
        quaternion = 0;
        hitCheck = false;
        rbsprite = GameManager.Player.rbSprite.flipX;
        this.gameObject.layer = 0;
        ballResource = StartCoroutine(BallResource());
        if (rbsprite)
            spriteRenderer.flipX = true;
        rb.gravityScale = 0;
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
        GameManager.Player.animator.SetLayerWeight(1, 0);
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
        this.gameObject.layer = 11;
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Player.skillA.cooltimecheck = false;
            StopCoroutine(BallResource());
            GameManager.Player.animator.SetLayerWeight(1, 0);
            GameManager.Resource.Destroy(transform.gameObject);
        }
    }
}
