using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public AudioClip collectedClip;
    //public ParticleSystem collectEffect;
    public int healthAmount = 1;
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if (controller != null && controller.health < controller.maxHealth)
        {
            controller.ChangeHealth(healthAmount);
            controller.PlaySound(collectedClip);
            //Instantiate(collectEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
