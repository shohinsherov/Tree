using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Sprite enableLife;

    private Image _image;


    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DisableLife()
    {
        _image.sprite = enableLife;
    }


}
