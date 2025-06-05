using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Threading;

public class Deflect : MonoBehaviour
{
    private bool isActive = false;

    [SerializeField]  private float blockCooldown = 3;
    
    [SerializeField] private float blockDuration = 0.25f;

    [SerializeField] private int ammunitionsAdded;

    public Image cooldownImage;

    private float timer;


    void Update()
    {
        timer += Time.deltaTime;
        cooldownImage.fillAmount = timer / blockCooldown;
        if (Input.GetKeyDown(KeyCode.LeftShift) && timer > blockCooldown)
        {
            Debug.Log("Parried");
            Parry();
            Debug.Log("Cooldown");
            Invoke("BlockDuration", blockDuration);
            // GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
            Debug.Log("Finished");
        }
        
    }


    private void Parry()
    {
        isActive = true;
        Debug.Log("Deflected");
        timer = 0;
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyProjectiles") && isActive == true)
        {
            // Vector3 direction = ((other.transform.position + other.transform.forward) - other.transform.position).normalized;
            // Vector3 inverse = direction * -1;
            // Vector3 position = other.transform.position;

            //  Debug.DrawRay(position, Vector3.Reflect(direction, transform.forward), Color.magenta, 100f);
            // Vector3 reflected = Vector3.Reflect(direction, transform.forward);
            // other.transform.rotation = Quaternion.LookRotation(reflected);
            // float mag = other.transform.GetComponent<Rigidbody2D>().velocity.magnitude;
            // other.GetComponent<Rigidbody2D>().velocity = reflected.normalized * mag;

            other.GetComponent<Rigidbody2D>().velocity = other.GetComponent<Rigidbody2D>().velocity * -2;
            GetComponentInParent<PlayerGun>().AddBullet(ammunitionsAdded);
            Debug.Log(ammunitionsAdded + " were added");
            other.GetComponent<EnemyBulletScript>().Deflected();
        }
    }

    void BlockDuration() {
        isActive = false;
    }



}
