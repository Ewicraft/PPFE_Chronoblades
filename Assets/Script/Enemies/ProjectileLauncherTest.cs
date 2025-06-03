using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncherTest : MonoBehaviour
{

    public Rigidbody2D projectilePrefab;

    public float projectileSpeed = 500;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Fire();
        }
    }

    void Fire()
    {
        Rigidbody2D star = Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);

        star.GetComponent<Rigidbody2D>().AddForce(transform.right * projectileSpeed);
    }
}
