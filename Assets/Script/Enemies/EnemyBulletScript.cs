using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;

    public bool hasBeenDeflected =false;

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
        if(other.gameObject.layer == 10 && hasBeenDeflected == false){
            other.GetComponent<PlayerReloadController>().IsKilled();
            Destroy(this.gameObject);
        } else if(other.gameObject.layer == 8){
            Destroy(this.gameObject);
        } else if(other.gameObject.layer == 9 && hasBeenDeflected){
            other.GetComponentInParent<EnemyManager>().IsKilled();
            Destroy(this.gameObject);
        }
    }

    public void Deflected(){
        hasBeenDeflected =true;
    }
    
}
