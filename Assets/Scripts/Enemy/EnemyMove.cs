using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public float speed;
    public bool moveRight;


    private float normalSpeed;

    private SpriteRenderer _spriteRenderer;


    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }



    void Start()
    {
        if(moveRight)
            MoveRight();
        else
            MoveLeft();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 position = transform.position;
        position.x += normalSpeed;
        transform.position = position;
    }

    public void MoveRight()
    {
        _spriteRenderer.flipX = true;
        normalSpeed = speed;
    }

    public void MoveLeft()
    {
        _spriteRenderer.flipX = false;
        normalSpeed = -speed;
    }


    public void RevesreMove()
    {
        if (normalSpeed > 0)
        {
            MoveLeft();
        }
        else
        {
            MoveRight();
        }
        
        // normalSpeed > 0 ? MoveLeft() : MoveRight();
    }

    public void Stop()
    {
        normalSpeed = 0f;
    }


    public int GetDirection()
    {
        return normalSpeed > 0 ? 1 : -1;
    }


}
