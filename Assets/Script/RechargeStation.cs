using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using TMPro;

public class RechargeStation : MonoBehaviour
{
    // Start is called before the first frame update
    public int ammoAdd;

    public float energyAdd;

    // public LayerMask playerLayer;

    public GameObject playerCharacter;

    public TextMeshPro textMesh;

    private bool playerInside = false;

    void Start()
    {
        textMesh.enabled = false;   
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            playerInside = true;
            textMesh.enabled = true;
            Debug.Log(playerInside);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            playerInside = false;
            textMesh.enabled = false;   
        }
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Q) && playerInside == true)
        {
            Debug.Log("Added");
            playerCharacter.GetComponent<PlayerReloadController>().addEnergy(energyAdd);
            playerCharacter.GetComponent<PlayerGun>().AddBullet(ammoAdd);
        }
    }
}
