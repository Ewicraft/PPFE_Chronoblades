using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public bool isSaved;

    public Vector3 position;

    public bool isAlive;
    public void Loading()
    {
        if (isSaved)
        {
            Rewind();
        }
        else
        {
            Save();
        }
    }
    public GameObject enemy;
    public void IsKilled()
    {
        enemy.SetActive(false);
    }

    public void IsAlived()
    {
        enemy.SetActive(true);
    }

    private void Rewind()
    {
        if (isAlive == true)
        {
            enemy.transform.position = position;
            IsAlived();
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public void Save()
    {
        isSaved = true;
        position = enemy.transform.position;
        if (enemy.gameObject.activeSelf)
        {
            isAlive = true;
        }
    }
}
