using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{

    public float speed;
    public Transform player;

    void Start()
    {
        speed = 2;
    }

    void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        if (dist >= 5)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x < -3.41f)
            {
                speed = -speed;
            }
            if (transform.position.x > 4.34f)
            {
                speed = 2;
            }
        }
        else
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        }
        
    }
}
