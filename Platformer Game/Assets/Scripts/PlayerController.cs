using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public bool onGround;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    public GameObject jumpParticle;
    private float moveInput;
    bool facingRight = true;
    public float dashSpeed;
    public float dashDuration;
    public GameObject dashParticle;
    public GameObject dashTrail;
    public float dashCooldown = 1f;
    private float nextDashTime = 0;
    public TrailRenderer tr;
    public int x = 5;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    public LayerMask whatIsGround;
    public float checkRadius;

    public bool isTouchingFront;
    public Transform frontCheck;
    private bool wallSliding;
    public float wallSlidingSpeed;

    bool wallJumping;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpingTime;

    public float hangTime = .2f; //coyote jump için
    private float hangCounter;

    public float jumpBufferLength;
    private float jumpBufferCount;

    private PlayerPos pp;

    GameMaster gm;
    public GameObject gameOverUI;
    public GameObject gameOverEffect;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        onGround = true;
        dashTrail.SetActive(false);
        tr = GetComponent<TrailRenderer>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        gameOverUI.SetActive(false);

    }

    private void Update()
    {
        
        moveInput = Input.GetAxis("Horizontal"); //(-1)-(1) values.

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        //coyote jump 
        if (onGround)
        {
            hangCounter = hangTime;
        }
        else
        {
            hangCounter -= Time.deltaTime;
        }
        //jump buffering
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferCount = jumpBufferLength;
        }
        else
        {
            jumpBufferCount -= Time.deltaTime;
        }


        if (jumpBufferCount >= 0 && hangCounter > 0f) //(Input.GetKeyDown(KeyCode.Space) && onGround)
        {

            isJumping = true;
            jumpTimeCounter = jumpTime;

            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // asıl zıplama buydu
            jumpBufferCount = 0;
            //     CinemachineShake.Instance.ShakeCamera(3f, .1f); // zıplamaya da camera shake eklersek diye kod
            Instantiate(jumpParticle, transform.position, transform.rotation);
            SoundManagerScript.PlaySound("jumpeffect2");

        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;

            }

            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }


        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatIsGround);


        if (isTouchingFront == true && onGround == false && moveInput != 0)
        {
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
        }

        if (wallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

        if (Input.GetKeyDown(KeyCode.Space) && wallSliding == true)
        {
            wallJumping = true;
            Invoke("SetWallJumpingToFalse", wallJumpingTime);
        }

        if (wallJumping == true)
        {
            rb.velocity = new Vector2(xWallForce * -moveInput, yWallForce);
        }




        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Time.time > nextDashTime)
            {
                StartCoroutine(DashMove());
                nextDashTime = Time.time + dashCooldown;
            }


        }
        // düşerken daha hızlı düşmesi için

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0) /// bozulursa sil
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        if (facingRight && moveInput < 0)
        {
            Flip();
            facingRight = !facingRight;

        }

        if (!facingRight && moveInput > 0)
        {
            Flip();
            facingRight = !facingRight;
        }

    }

    IEnumerator DashMove()
    {
        SoundManagerScript.PlaySound("dasheffect");
        Instantiate(dashParticle, transform.position, transform.rotation);
        speed += dashSpeed; //dash için hız kısa süreliğine baya artıyor sonra eski haline dönüyor
        dashTrail.SetActive(true);
        tr.enabled = false;
        CinemachineShake.Instance.ShakeCamera(9f, .3f);
        yield return new WaitForSeconds(dashDuration);
        speed -= dashSpeed;
        yield return new WaitForSeconds(0.2f);
        tr.enabled = true;
        yield return new WaitForSeconds(0.1f);
        dashTrail.SetActive(false);
    }

    public void Flip() // karakteri döndürmek için
    {
        //   facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    IEnumerator GameOverUICoro()
    {
        yield return new WaitForSeconds(0.2f);
        gameOverUI.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Stopper")
        {
            Debug.Log("U DIED");
            // gameObject.SetActive(false);
            transform.position = gm.lastCheckPointPos;
            SoundManagerScript.PlaySound("dieeffect2");
            DeadCount.deadCounter += 1;
        }
        if(collision.tag == "Stopper2")
        {
            transform.position = gm.lastCheckPointPos;
            SoundManagerScript.PlaySound("dieeffect2");
            DeadCount.deadCounter += 0.5f;
        }

        if(collision.tag == "GameOver")
        {
            StartCoroutine(GameOverUICoro());
            Instantiate(gameOverEffect, transform.position, transform.rotation);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("MovingPlatform"))

            this.transform.parent = col.transform;



    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("MovingPlatform"))
            this.transform.parent = null;



    }

    private void SetWallJumpingToFalse()
    {
        wallJumping = false;
    }

    /*  private void OnCollisionEnter2D(Collision2D collision)
      {
          if (collision.gameObject.tag == "Ground")
          {
              onGround = true;
          }
      }

      private void OnCollisionExit2D(Collision2D collision)
      {
          if (collision.gameObject.tag == "Ground")
          {
              onGround = false;
          }
      } */



}
