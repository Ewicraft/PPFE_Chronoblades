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

	private SpriteRenderer spriteRenderer;

    public float range;

    public float shootCooldown = 4f;
    public Transform gunPos;

    public float bulletSpeed;
    [SerializeField] private GameObject enemyBulletPrefab;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        timer = shootCooldown / 2;
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < range)
        {
            isPlayerInSight = true;
            timer += Time.deltaTime;
            spriteRenderer.flipX = player.transform.position.x < transform.position.x;
            if (timer > shootCooldown)
            {
                timer = 0;
                shoot();
            }
        }
        else
        {
            isPlayerInSight = false;
            timer = 0;
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
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
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
        enemyAnim.SetTrigger("Shoot");
        GameObject newBullet = Instantiate(enemyBulletPrefab, gunPos.position, Quaternion.identity);
        newBullet.GetComponent<EnemyBulletScript>().force = bulletSpeed;
    }

}
