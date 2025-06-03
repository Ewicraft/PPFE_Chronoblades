using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlash : MonoBehaviour
{
    public Transform slashOrigin;
    public float slashRadius = 1f;
    public LayerMask EnemyLayer;

    public float cooldownTime = .5f;

    public float cooldownTimer = 0f;


    private void Update()
    {
        if (cooldownTimer <= 0)
        {
            if (Input.GetKey(KeyCode.K))
            {
                Debug.Log("Slash");
                Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(slashOrigin.position, slashRadius, EnemyLayer);
                foreach (var enemy in enemiesInRange)
                {
                    enemy.GetComponent<EnemyManager>().IsKilled();
                }
            }
            cooldownTimer = cooldownTime;
        }
        else
        {
            cooldownTimer -= Time.deltaTime;
        }


    }


    // private void OnDrawGizmos()
    // {
    //     Gizmos.DrawWireSphere(slashOrigin.position, slashRadius);
    // }
   

}
