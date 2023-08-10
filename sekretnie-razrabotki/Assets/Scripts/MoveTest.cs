using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    [Header("PlayerSettings")]
    Rigidbody2D rb;
    public float speed;
    public float dashSpeed;
    public float jumpheight;
    public bool isGrounded = false;
    Animator anim;
    public float healthPoint = 100;

    void Start()    
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Flip();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.AddForce(transform.up * jumpheight, ForceMode2D.Impulse);
        }
        if(healthPoint <= 0) {
            Destroy(gameObject);
        }
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.C) && isGrounded) {
            rb.AddForce(transform.right * dashSpeed, ForceMode2D.Impulse);
        }
    }

    void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetAxis("Horizontal") < 0)
        transform.localRotation = Quaternion.Euler(0, 180, 0);
    }
    
    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        if(collision.gameObject.tag == "Enemy")
        {
            healthPoint -= 10;
        }
    }
    void OnCollisionExit2D(Collision2D collision) {
        isGrounded = false;
    } 

}