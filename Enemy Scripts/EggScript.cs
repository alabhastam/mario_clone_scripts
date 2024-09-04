using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D traget) {
        if(traget.gameObject.tag == Tags.PLAYER_TAG){
            //DAMAGE WILL BE ADDed ASAP
            traget.gameObject.GetComponent<PlayerDamage>().DealDamage();
        }
        gameObject.SetActive(false);
    }
}
