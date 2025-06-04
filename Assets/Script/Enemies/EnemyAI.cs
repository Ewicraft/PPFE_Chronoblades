using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyAI : MonoBehaviour
{
    //Reference to waypoints
    public List<Transform> points;
    //The int value for next point index
    public int nextID = 0;
    //The value of that applies to ID for changing
    int idChangeValue = 1;
    //Speed of movement or flying
    public float speed = 2;

    public Animator enemyAnim;

    private bool isPlayerInSight = false;
    public GameObject player;
    public float timer;

    public float range;

    public float shootCooldown = 4f;
    public Transform gunPos;
    [SerializeField] private GameObject enemyBulletPrefab;




    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < range)
        {
            isPlayerInSight = true;
            timer += Time.deltaTime;
            if (timer > shootCooldown-0.75f)
            {
                timer = 0;
                enemyAnim.SetBool("Shooting", true);
                Invoke("shoot",0.75f);
            }
        }
        else
        {
            isPlayerInSight = false;
        }

        if (isPlayerInSight == false)
        {
            MoveToNextPoint();
            enemyAnim.SetBool("Running", true);
        }
        else
        {
            enemyAnim.SetBool("Running", false);
        }
    }

    void MoveToNextPoint()
    {
        Transform goalPoint = points[nextID];
        if (goalPoint.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-7, 7, 7);
        }
        else
        {
            transform.localScale = new Vector3(7, 7, 7);
        }
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, goalPoint.position) < 0.2f)
        {
            if (nextID == points.Count - 1)
            {
                idChangeValue = -1;
            }
            if (nextID == 0)
            {
                idChangeValue = 1;
            }
            nextID += idChangeValue;
        }
    }

    void shoot()
    {
        GameObject newBullet = Instantiate(enemyBulletPrefab, gunPos.position, Quaternion.identity);
        Invoke("ShootingStop", 0.75f);
    }

    void ShootingStop()
    {
        enemyAnim.SetBool("Shooting", false);
    }
}
