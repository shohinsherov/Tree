using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class HunterEnemyMove : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed = 5f;
    public float rangeToPlayer = 10f;

    private Transform player;
    private Vector3 startingPosition;




    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if(distanceToPlayer < rangeToPlayer) {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y), moveSpeed * Time.deltaTime);
        }else {
            transform.position = Vector3.MoveTowards(transform.position, startingPosition, moveSpeed * Time.deltaTime);
        }

    }



    // public void MoveToPoint(Vector3 point)
    // {
    //     var time = (transform.position.x - point.x) / speed;
    //     Debug.Log($"Time: {time}");
    //
    //     _moveTween.Kill();
    //     _moveTween = transform.DOMove(point, time).SetEase(Ease.Linear);
    // }
    //
    //
    //
    // public void Stop()
    // {
    //     _moveTween.Kill();
    // }







}
