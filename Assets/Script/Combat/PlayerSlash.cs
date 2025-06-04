using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlash : MonoBehaviour
{
    public Transform slashOrigin;
    public float slashRadius = 1f;
    public LayerMask EnemyLayer;

    public float cooldownTime = 0.5f;

    public float cooldownTimer = 0f;

    // public SpriteRenderer SlashSprite;
    public Animator SlashAnim;

    void Start()
    {
        // SlashSprite.enabled = false;   
    }

    private void Update()
    {
        if (cooldownTimer <= 0)
        {
            if (Input.GetKey(KeyCode.K))
            {
                Debug.Log("Slash");
                SlashAnim.SetBool("Slash",true);
                Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(slashOrigin.position, slashRadius, EnemyLayer);
                // SlashSprite.enabled = true;
                foreach (var enemy in enemiesInRange)
                {
                    enemy.GetComponent<EnemyManager>().IsKilled();
                }
                Invoke("SlashAnimEnd", 1.75f);

            }
            cooldownTimer = cooldownTime;
        }
        else
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    void SlashAnimEnd(){
        SlashAnim.SetBool("Slash",false);
    }


    // private void OnDrawGizmos()
    // {
    //     Gizmos.DrawWireSphere(slashOrigin.position, slashRadius);
    // }
   

}
