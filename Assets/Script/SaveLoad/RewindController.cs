using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindController : MonoBehaviour
{
    public Vector3 pos;
    public bool isSaved = false;
    public GameObject player;

    private bool isAlive = false;

    public bool isPlayer =false;


    void Start()
    {
        player = this.gameObject;
    }

    void Update(){

        if(Input.GetKeyDown(KeyCode.E)){
            if(isSaved){
                Rewind();
            } else {
                Save();
            }
        }
    }

    public void Rewind(){
        this.transform.position = pos;
        isSaved = false;
        if(isAlive){
            gameObject.SetActive(true);
        }
        if(isPlayer) GetComponent<PlayerReloadController>().SaveActive(isSaved);
    }

    void Save(){
        pos = this.transform.position;
        if(isActiveAndEnabled){
            isAlive = true;
        }
        isSaved = true;  
        if(isPlayer) GetComponent<PlayerReloadController>().SaveActive(isSaved);
    }

}
