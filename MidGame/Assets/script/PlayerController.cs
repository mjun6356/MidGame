
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    public float baseSpeed = 1f;
    
    public float jumpForce = 3f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator pAni;
    private bool isGrounded;

    private bool isGiant = false;
    public bool hasSpeedItem = false;
    public bool isInvincible = false; // 무적 상태인가?

    private float moveInput;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pAni = GetComponent<Animator>();
    }

    void Die()
    {
        int randomDeathIndex = Random.Range(1, 6);
        SceneManager.LoadScene("Death " + randomDeathIndex);
    }


    void Update()
    {
        rb.linearVelocity = new Vector2(moveInput * baseSpeed, rb.linearVelocity.y);

        if (!hasSpeedItem) // 아이템을 먹지 않은 상태라면 (!는 '아니다'라는 뜻)
        {
            baseSpeed = 1f; // 기본 속도 6으로 고정
        }

        if (isGiant)
        {
            if (moveInput < 0)
                transform.localScale = new Vector3(2, 2, 2);
            else if (moveInput > 0)
                transform.localScale = new Vector3(-2, 2, 2);
        }
        else
        {
            if (moveInput < 0)
                transform.localScale = new Vector3(1, 1, 1);
            else if (moveInput > 0)
                transform.localScale = new Vector3(-1, 1, 1);
        }

        

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
   
    public void OnMove(InputValue value)
    {
        Vector2 intput = value.Get<Vector2>();
        moveInput = intput.x;
    }

    public void OnJump(InputValue value)
    {
        if(value.isPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            pAni.SetTrigger("Jump");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Respawn"))
        {
            Die();
        }

        if (collision.CompareTag("Finish"))
        {
            collision.GetComponent<LevelObject>().MoveToNextLevel();
        }
        if (collision.CompareTag("Enemy"))
        {
            // 거대화 상태이거나 '무적 상태'라면 적을 파괴 (또는 그냥 통과)
            if (isGiant || isInvincible)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                Die();
            }

        }


        if (collision.CompareTag("Item"))
        {
            isGiant = true;
            Invoke(nameof(ResetGiant), 15f);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Item2"))
        {
            // 내(플레이어) 속도를 직접 올리기
            baseSpeed = 12f;
            hasSpeedItem = true; // 스위치 켜기
            Invoke(nameof(ResetSpeedBoosthing), 15f);
            // 부딪힌 아이템 오브젝트를 삭제
            Destroy(collision.gameObject);

        }
        


        if (collision.CompareTag("Item3"))
        {
            isInvincible = true; // 무적 켜기
            Invoke(nameof(ResetInvincibility), 5f); // 5초 뒤 무적 해제
            Destroy(collision.gameObject);
        }
       
    }
    void ResetGiant()
    {
        isGiant = false;
    }
   
    void ResetSpeedBoosthing()
    {
        hasSpeedItem = false;
    }
    void ResetInvincibility()
    {
        isInvincible = false;
    }
    
    }
