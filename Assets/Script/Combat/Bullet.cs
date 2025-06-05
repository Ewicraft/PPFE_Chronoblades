using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();
    // Update is called once per frame
    void Update() => transform.right = rb.velocity;

    void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.CompareTag("Enemy"))
        {
            enemy.GetComponentInParent<EnemyManager>().IsKilled();
            Destroy (gameObject);
        } 
        else if(enemy.CompareTag("Player")){

        } else {
            Destroy (gameObject);
        }
    }
}
