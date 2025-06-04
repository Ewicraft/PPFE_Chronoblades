using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerReloadController : MonoBehaviour
{
    public int energyCount;

    private int maxEnergyCount;

    public Image EnergyFill;
    public bool hasSaveActive =false ;
    // Start is called before the first frame update
    // Update is called once per frame
    void Start()
    {
        maxEnergyCount = energyCount;
    }

    public void IsKilled(){
        if(energyCount >= 0 && hasSaveActive){
            this.GetComponent<RewindController>().Rewind();
            energyCount -= 1;
            EnergyFill.fillAmount = energyCount/maxEnergyCount;
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void SaveActive(bool saveState){
        hasSaveActive = saveState;
    }
}
