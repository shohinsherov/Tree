using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public int lifeCount = 5;

    public GameObject LifesContent;
    public GameObject LifePrefab;




    void Start()
    {
        InitLifes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void InitLifes()
    {
        for (int i = 0; i < lifeCount; i++)
        {
            Instantiate(LifePrefab, LifesContent.transform);
        }
        
    }

    public void LifeMinus()
    {
        
        var life  = LifesContent.transform.GetChild(lifeCount-1);
        life.GetComponent<LifeManager>().DisableLife();
        lifeCount = lifeCount - 1;

        if (lifeCount == 0)
        {
            // todo GAME OVER !!!!

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        }
    }

}
