using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deflect : MonoBehaviour
{
    private bool isActive = false;

    [SerializeField]  private float blockCooldown = 3;
    private bool isBlockReady =true;
    [SerializeField] private float blockDuration = 0.25f;


    [SerializeField] private float ammunitionsAdded;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && isBlockReady == true)
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
        isBlockReady = false;
        Debug.Log("IsBlockReady");
        isActive = true;
        StartCoroutine(BlockCooldown(blockCooldown));
        Debug.Log("Deflected");
    }


    IEnumerator BlockCooldown(float duration)
    {
        if (isBlockReady)
        {
            yield return new WaitForSeconds(duration);

            isBlockReady = true;
        }
        else
        {
            isBlockReady = false; 
            
            yield return new WaitForSeconds(duration);

            isBlockReady = true;
        }
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

            other.GetComponent<Rigidbody2D>().velocity = other.GetComponent<Rigidbody2D>().velocity * -1;
            GetComponent<PlayerGun>().AddBullet(ammunitionsAdded);
            Debug.Log(ammunitionsAdded + " were added");
        }
    }

    void BlockDuration() {
        isActive = false;
    }



}
