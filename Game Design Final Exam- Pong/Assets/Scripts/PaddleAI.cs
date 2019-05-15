using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAI : MonoBehaviour
{
    public GameObject theBall;
    public float speed = 20;
    public float boundY = 2.25f;
    private Rigidbody2D PaddleRB;

    void Start()
    {
        PaddleRB = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var vel = PaddleRB.velocity;

            if (theBall.transform.position.y > transform.position.y)
            {
                if (PaddleRB.velocity.y < 0)
                    PaddleRB.velocity = Vector2.zero;
                vel.y = speed * Time.deltaTime;
            }
            else if (theBall.transform.position.y < transform.position.y)
            {
                if (PaddleRB.velocity.y > 0)
                    PaddleRB.velocity = Vector2.zero;
                vel.y = -speed * Time.deltaTime;
            }
            else
            {
                vel.y = 0;
            }



        PaddleRB.velocity = vel;

        var pos = transform.position;
        if (pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }
        transform.position = pos;
    }
}
