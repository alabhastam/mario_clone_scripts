using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject fireBullet;
    public float cooldownTime = 1.3f; // Time in seconds between shots

    private float nextFireTime = 0.0f; // Time when the player can shoot again

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && Time.time >= nextFireTime)
        {
            ShootBullet();
            nextFireTime = Time.time + cooldownTime; // Update next available shot time
        }
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(fireBullet, transform.position, Quaternion.identity);
        bullet.GetComponent<FireBullet>().Speed *= transform.localScale.x;
    }
}