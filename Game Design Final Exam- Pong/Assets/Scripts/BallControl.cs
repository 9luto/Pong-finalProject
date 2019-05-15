using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D ballRB;

    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            ballRB.AddForce(new Vector2(20, -15));
        }
        else
        {
            ballRB.AddForce(new Vector2(-20, -15));
        }
    }

    void Start()
    {
        ballRB = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
    }

    void ResetBall()
    {
        ballRB.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = ballRB.velocity.x;
            vel.y = (ballRB.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
            ballRB.velocity = vel;
        }
    }

}
