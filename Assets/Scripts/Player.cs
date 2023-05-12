using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public float jumpForce;

    private bool isGrounded;
    private Rigidbody2D rigidbody2D;


    private Animator anim;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector3 position = transform.position;

       // Debug.Log($"{Input.GetAxis("Horizontal")}");
       var setPos = Input.GetAxis("Horizontal") * speed;

       if (setPos != 0)
       {
           anim.SetBool("isRunning", true);
       }
       else
       {
           anim.SetBool("isRunning", false);
       }

       
        position.x += setPos ;
        //position.y += Input.GetAxis("Vertical");

        transform.position = position;


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
    }


    private void Jump()
    {
        if (isGrounded)
        {
            anim.SetBool("isJumping",true);
            isGrounded = false;
            rigidbody2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }



    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("isJumping",false);
        }
    } 
}
