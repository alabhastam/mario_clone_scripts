using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject stone; 
    public Transform attackInstantiate; 
    private Animator anim; 
    private string coroutine_name = "StartAttack"; 
    private Transform player; 
    public float attackForce = 600f; 
    public float verticalForceMultiplier = 0.25f; 

    private void Awake() {
        anim = GetComponent<Animator>(); 
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(coroutine_name);
    }

    void Attack(){
        GameObject obj = Instantiate(stone, attackInstantiate.position, Quaternion.identity); 

        Vector2 direction = (player.position - attackInstantiate.position).normalized;

        direction.y += verticalForceMultiplier;

        obj.GetComponent<Rigidbody2D>().AddForce(direction * attackForce);
    }

    void BackToIdle(){
        anim.Play("BossIdle"); 
    }

    public void DeactivateBossScript(){
        StopCoroutine(coroutine_name);
        enabled = false;
    }

    // Update is called once per frame
    IEnumerator StartAttack (){
        yield return new WaitForSeconds(Random.Range(2f,5f));
        anim.Play("BossAttack"); 
        StartCoroutine(coroutine_name);
    }
}
