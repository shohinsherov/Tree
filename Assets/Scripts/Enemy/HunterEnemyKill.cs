using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterEnemyKill : MonoBehaviour
{
    // Start is called before the first frame update

    public int enemyLifes = 2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemyLifes--;
            collision.gameObject.GetComponent<ButtonMovement>().Jumper();

            if (enemyLifes < 1)
            {
                Destroy(this.transform.parent.gameObject);
            }
        }
            
    }


}
