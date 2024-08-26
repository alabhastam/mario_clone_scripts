using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerDamage playerDamage = collision.gameObject.GetComponent<PlayerDamage>();
            if (playerDamage != null)
            {
                playerDamage.DealDamage();

                if (playerDamage.GetLifeCount() > 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
    }
}
