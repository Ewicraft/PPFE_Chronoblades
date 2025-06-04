using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;

    public float force;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.layer == 10){
            other.GetComponent<PlayerReloadController>().IsKilled();
            Destroy(gameObject);
        } else if(other.gameObject.layer == 8){
            Destroy(gameObject);
        }
    }
    
}
