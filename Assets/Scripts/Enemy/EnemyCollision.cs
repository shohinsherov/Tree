using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    // Start is called before the first frame update

    private EnemyMove _enemyMove;


    private void Awake()
    {
        _enemyMove = transform.parent.GetComponent<EnemyMove>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _enemyMove.Stop();

            if(this.name == "left")
                _enemyMove.MoveRight();

            if(this.name == "right")
                _enemyMove.MoveLeft();
        }


        if (collision.gameObject.CompareTag("Player"))
        {

        }

    }
}
