using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private bool isGrounded;
    private bool canMove = true;
    private Rigidbody2D rigidbody2D;
    private Animator anim;
    private Transform transform;

    private float normalSpeed;


    private Tween _attackTween;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        transform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (normalSpeed != 0f)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

    }

    private void FixedUpdate()
    {
        if(!canMove)
            return;

        Vector3 position = transform.position;

        // Debug.Log($"{Input.GetAxis("Horizontal")}");

       
        position.x += normalSpeed;
        //position.y += Input.GetAxis("Vertical");

        transform.position = position;

    }

    public void Jump()
    {
        if (isGrounded)
        {
            anim.SetBool("isJumping", true);

            isGrounded = false;
            rigidbody2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }


    public void Right()
    {
        transform.localRotation = new Quaternion(0, 0, 0, 0);
        normalSpeed = speed;
    }

    public void Left()
    {
        transform.localRotation = new Quaternion(0, 180f, 0, 0);
        normalSpeed = -speed;
    }

    public void Stop()
    {
        normalSpeed = 0f;
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("isJumping", false);
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            canMove = false;
            var enemyMove = collision.gameObject.GetComponent<EnemyMove>();
            enemyMove.RevesreMove();
            _attackTween = transform.DOMoveX(transform.position.x  - (3f * enemyMove.GetDirection()), 1f).OnComplete(() =>
            {
                canMove = true;
            });
            GetComponent<PlayerController>().LifeMinus();
        }

        if (collision.gameObject.CompareTag("Trap"))
        {
            canMove = false;

            int dir = transform.position.x < collision.transform.position.x ? 1 : -1;
            
            _attackTween = transform.DOMoveX(transform.position.x  - (3f * dir), 1f).OnComplete(() =>
            {
                canMove = true;
            });
            GetComponent<PlayerController>().LifeMinus();
        }
        
        if (collision.gameObject.CompareTag("Hunter"))
        {
            canMove = false;

            int dir = transform.position.x < collision.transform.position.x ? 1 : -1;
            
            _attackTween = transform.DOMoveX(transform.position.x  - (3f * dir), 1f).OnComplete(() =>
            {
                canMove = true;
            });
            GetComponent<PlayerController>().LifeMinus();
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }



    public void Jumper()
    {
        anim.SetBool("isJumping", true);
        rigidbody2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
    


}
