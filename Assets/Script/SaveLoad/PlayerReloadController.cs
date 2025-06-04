using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerReloadController : MonoBehaviour
{
    public int energyCount;
    public bool hasSaveActive =false ;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        
    }

    public void IsKilled(){
        if(energyCount >= 0 && hasSaveActive){
            this.GetComponent<RewindController>().Rewind();
            energyCount -= energyCount;
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void SaveActive(bool saveState){
        hasSaveActive = saveState;
    }
}
