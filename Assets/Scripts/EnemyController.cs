using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public ParticleSystem smokeEffect;
    AudioSource audioSource;
    Animator animator;
    public float changeTime = 3.0f;
    float timer;
    int count = 0;
    int direction = 1;
    public float speed = 3.0f;
    public int damage = 1;
    public bool vertical;
    public bool isAdvanceEnemy = false;

    bool broken = true;
    Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        timer = changeTime;

        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;

        if (vertical)
        {
            position.y = position.y + speed * direction * Time.deltaTime;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + speed * direction * Time.deltaTime;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
        rigidbody2d.MovePosition(position);

        if (!broken)
        {
            return;
        }
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
                AdvanceMoveEnemy();
            }
        }
    }

    void AdvanceMoveEnemy()
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

    public void Fix()
    {
        broken = false;
        rigidbody2d.simulated = false;
        animator.SetTrigger("Fixed");
        audioSource.Stop();
        smokeEffect.Stop();
    }

}
