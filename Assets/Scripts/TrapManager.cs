using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    // Start is called before the first frame update

    public float rotateTime = 4f;
    public bool rotate—lockwise = true;

    private Tween rotatorTween;



    void Start()
    {

        Vector3 rotateVector = new Vector3(0f,0f,-360f);

        if(!rotate—lockwise)
            rotateVector = new Vector3(0f,0f,360f);

        rotatorTween = transform.DORotate(rotateVector, rotateTime, RotateMode.FastBeyond360).SetRelative(true)
            .SetEase(Ease.Linear).SetLoops(-1);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
