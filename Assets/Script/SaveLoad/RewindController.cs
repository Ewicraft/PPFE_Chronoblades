using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindController : MonoBehaviour
{
    public Vector3 pos;
    public bool isSaved = false;

    void Update(){

        if(Input.GetKeyDown(KeyCode.E)){
            if(isSaved){
                Rewind();
            } else {
                Save();
            }
        }
    }

    void Rewind(){
        this.transform.position = pos;
        isSaved = false;
    }

    void Save(){
        pos = this.transform.position;
        isSaved = true;  
    }

}
