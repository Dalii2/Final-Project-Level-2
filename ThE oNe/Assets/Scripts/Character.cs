using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour

{
    private Rigidbody2D rb;
    private Animator anim;
    private float moveSpeed;
    private float dirX;
    private bool facingRight = true;
    private Vector3 localScale;
    public static float healthAmount;
    

    private void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        moveSpeed = 7f;
        healthAmount = 1;

    }


    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;

        if (Input.GetButtonDown("Jump") && rb.velocity.y == 0)
            rb.AddForce(Vector2.up * 400f);

        if (Mathf.Abs(dirX) > 0 && rb.velocity.y == 0)
            anim.SetBool("IsRunning", true);
        else
            anim.SetBool("IsRunning", false);

        if (rb.velocity.y == 0)
        {
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsFalling", false);
        }
        if (rb.velocity.y > 0)
            anim.SetBool("IsJumping", true);

        if (rb.velocity.y < 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("IsFalling", true);
        }

        if (healthAmount <= 0)
            Destroy(gameObject);

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    private void LateUpdate()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
        facingRight = false;


        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "enemy")
        {
            healthAmount -= 0.1f;
            Debug.Log("hit");
        }
        if (col.gameObject.tag == "monster")
        {
            healthAmount -= 1f;
            Debug.Log("hit");
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "enemy")
        {
            healthAmount -= 0.1f;
            Debug.Log("hit");
        }
    }
}
