using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;

    [SerializeField] private float jumpPower;
    [SerializeField] private float DashPower;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float movePower;

    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer rbSprite;
    private Vector2 inputDir;
    private Vector3 attackRangePosition;
    private Coroutine dashRoutine;

    public bool doubleJump;
    public bool isGround;
    public bool isDash;
    public bool dashCoolTime;

    public int dashCount;

    private void Awake()
    {
        GameManager.Player = transform;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rbSprite = GetComponent<SpriteRenderer>();
        attackRangePosition = transform.GetChild(0).localPosition;
    }

    private void Update()
    {
        if(!isDash)
            Move();
    }
    private void FixedUpdate()
    {
        GroundCheck();
    }
    public void Move()
    {
        animator.SetInteger("Move",math.abs((int)inputDir.x));
        if (inputDir.x < 0)
            transform.Translate(Vector2.right * inputDir.x*movePower*Time.deltaTime);
        else if (inputDir.x > 0 )
            transform.Translate(Vector2.right * inputDir.x * movePower * Time.deltaTime);
    }

    public void Jump()
    {
        rb.gravityScale = 1;
        if (isDash)
        {
            StopCoroutine(dashRoutine);
            isDash = false;
        }
        if (isGround)
        {
            rb.velocity = Vector2.up * jumpPower;
            //rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }
        else
        {
            animator.SetTrigger("Jump");
            rb.velocity = Vector2.up * jumpPower;
            doubleJump = false;
            animator.SetTrigger("DoubleJump");
        }
    }
    private void OnJump(InputValue value)
    {
        if (isGround || doubleJump)
            Jump();
    }


    IEnumerator Dash()
    {
        DashStart();
        float currentTime = 0f;
        while (true)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= 0.5f)
            {
                StartCoroutine(DashCoolTime());
                dashCoolTime = true;
                break;
            }
            if (rbSprite.flipX)
                transform.Translate(Vector2.left * DashPower * Time.deltaTime);
            else
                transform.Translate(Vector2.right * DashPower * Time.deltaTime);
            yield return null;
        }
        DashEnd();
    }

    IEnumerator DashCoolTime()
    {
        yield return new WaitForSeconds(1f);
        dashCount = 0;
        dashCoolTime = false;
    }
    private void OnDash(InputValue value)
    {
        if(dashCount<2)
            dashRoutine = StartCoroutine(Dash());
    }
    private void OnMove(InputValue value)
    {
        Move();
        if (!isDash)
        {
            inputDir = value.Get<Vector2>();
            if (inputDir.x > 0)
            {
                transform.GetChild(0).localPosition = attackRangePosition;
                rbSprite.flipX = false;

            }
            else if (inputDir.x < 0)
            {
                transform.GetChild(0).localPosition = new Vector3(-attackRangePosition.x, attackRangePosition.y, attackRangePosition.z);
                rbSprite.flipX = true;
            }
        }
    }
    
    
    private void GroundCheck()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, groundLayer);
        if (hit.collider != null)
        {
            Debug.DrawRay(transform.position, new Vector3(hit.point.x, hit.point.y, 0) - transform.position, Color.red);
            isGround = true;
            doubleJump = true;
            animator.SetBool("GroundCheck", true);
        }
        else
        {
            isGround = false;
            animator.SetBool("GroundCheck", false);
            Debug.DrawRay(transform.position, Vector3.down * 1.5f, Color.green);
        }
    }
    private void DashEnd()
    {
        rb.gravityScale = 1;
        isDash = false;
    }
    private void DashStart()
    {
        dashCount++;
        rb.gravityScale = 0;
        rb.velocity = Vector2.up * 0;
        isDash = true;
        animator.SetTrigger("Dash");
    }
}
