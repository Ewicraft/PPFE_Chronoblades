using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject self;


    public void IsKilled()
    {
        Debug.Log("Ouch!");
        self.SetActive(false);
    }
}
