using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    public float baseSpeed = 6f;
    public float moveSpeed = 3f;
    public float jumpForce = 3f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator pAni;
    private bool isGrounded;

    private bool isGiant = false;
    private bool isMoving = false;

    private float moveInput;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pAni = GetComponent<Animator>();
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(moveInput * baseSpeed, rb.linearVelocity.y);

        float moveX = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * moveX * moveSpeed * Time.deltaTime);

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

        /*if (isMoving)
        {
            if (moveInput < 0)
                moveSpeed = 6f;
            else if (moveInput > 0)
                moveSpeed = 6f;
        }
        else
        {
            if (moveInput < 0)
                moveSpeed = 6f;
            else if (moveInput > 0)
                moveSpeed = 6f;
        }*/


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    /*public void OnMove(InputValue value)
    {
        Vector2 intput = value.Get<Vector2>();
        moveInput = intput.x;
    }*/

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (collision.CompareTag("Finish"))
        {
            collision.GetComponent<LevelObject>().MoveToNextLevel();
        }
        if (collision.CompareTag("Enemy"))
        {
            if (isGiant)
                Destroy(collision.gameObject);
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

        if (collision.CompareTag("Item"))
        {
            isGiant = true;
            Invoke(nameof(ResetGiant), 6f);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Item2"))
        {
            isMoving = true;
            Invoke(nameof(ResetMoving), 6f);
            Destroy(collision.gameObject);
        }
    }

   void ResetGiant()
    {
        isGiant = false;
    }
    void ResetMoving()
    {
        isMoving = false;
    }

}
