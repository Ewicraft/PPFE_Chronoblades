using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            SceneManager.LoadScene(0);
        }
    }
}
