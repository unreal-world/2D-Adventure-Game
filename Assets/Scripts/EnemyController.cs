using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float changeTime = 3.0f;
    float timer;
    int count = 0;
    int direction = 1;
    public float speed = 3.0f;
    public int damage = 1;
    public bool vertical;
    public bool isAdvanceEnemy = false;
    Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;

        if (vertical)
        {
            position.y = position.y + speed * direction * Time.deltaTime;
        }
        else
        {
            position.x = position.x + speed * direction * Time.deltaTime;
        }
        rigidbody2d.MovePosition(position);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
            if (isAdvanceEnemy)
            {
                count++;
                IsAdvanceEnemy();
            }
        }
    }

    void IsAdvanceEnemy()
    {
        if (count == 2)
        {
            vertical = !vertical;
            count = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
           player.ChangeHealth(-damage);
        }
    }

}
