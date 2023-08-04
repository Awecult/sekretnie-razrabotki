using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jumpheight;
    public Transform groundCheck;
    public bool isGrounded = false;
    Animator anim;

    void Start()    
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GameObject.FindGameObjectWithTag("Ground").transform;
    }
    void Update()
    {
        Flip();
        CheckGround();
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            rb.AddForce(transform.up * jumpheight, ForceMode2D.Impulse);

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
    }
    void OnCollisionExit2D(Collision2D collision) {
        isGrounded = false;
    }

    void CheckGround()
    {
        /*if (OnCollisionStay2D == true) 
        {
            isGrounded
        }*/
        //Collider2D[] colliders = Physics2D.OverlapBoxAll(groundCheck.position, BoxSize, 0);
        //isGrounded = colliders.Length > 1;
    }
}