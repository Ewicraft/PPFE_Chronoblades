using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlash : MonoBehaviour
{
    public Transform slashOrigin;
    public float slashRadius = 1f;
    public LayerMask EnemyLayer;

    public float cooldownTime = 0.75f;

    public float timer;

    // public SpriteRenderer SlashSprite;
    public Animator SlashAnim;

    void Start()
    {
        // SlashSprite.enabled = false;   
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > cooldownTime && Input.GetKeyDown(KeyCode.K)||Input.GetKeyDown(KeyCode.Mouse1))
        {
            timer = 0;
            Attack();
        }
    }


    private void Attack()
    {
        Debug.Log("slash");
        SlashAnim.SetTrigger("Slash");
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(slashOrigin.position, slashRadius, EnemyLayer);
        foreach (Collider2D enemy in enemiesInRange)
        {
            enemy.GetComponentInParent<EnemyManager>().IsKilled();
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(slashOrigin.position, slashRadius);
    }
   

}
