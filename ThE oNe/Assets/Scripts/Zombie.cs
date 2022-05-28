using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField]
    Transform Player;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

        Rigidbody2D rb2d;
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, Player.position);

        if(distToPlayer < agroRange)
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        moveSpeed = Random.Range(3, 5);

    }

    void ChasePlayer()
    {
        if(transform.position.x < Player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(2, 2);
        }
        else
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-2, 2);
        }
    }
    void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
    }
    
}