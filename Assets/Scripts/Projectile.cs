using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(transform.position.magnitude > 100.0f)
       {
           Destroy(gameObject);
       }
    }

    public void Launch(Vector2 direction, float force)
    {
        rb.AddForce(direction * force);
        audioSource.PlayOneShot(audioSource.clip);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyController enemy = other.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.Fix();
        }

        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }

}
