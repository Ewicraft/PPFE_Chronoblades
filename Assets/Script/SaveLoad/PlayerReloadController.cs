using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerReloadController : MonoBehaviour
{
    public float energyCount;
    public float maxEnergyCount;

    public Image EnergyFill;

    public Vector3 pos;
    public bool isSaved = false;

    public Image CanPause;

    public GameObject remnantPrefab;

    public GameObject[] targets;

    private float deathCooldown = 0.15f;
    private float timer;

    public bool hasSaveActive = false;
    // Start is called before the first frame update
    // Update is called once per frame




    void Update()
    {
        EnergyFill.fillAmount = energyCount / maxEnergyCount;
        timer = Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E) && energyCount > 0)
        {
            if (isSaved)
            {
                Rewind();
            }
            else
            {
                Save();
            }

            foreach (GameObject target in targets)
            {
                if (target.layer == 9)
                {
                    target.GetComponent<EnemyManager>().Loading();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            IsKilled();
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            addEnergy(5f);
        }
    }

    public void SaveActive(bool saveState)
    {
        hasSaveActive = saveState;
    }

    public void addEnergy(float addedEnergy)
    {
        energyCount += addedEnergy;
        if (energyCount > maxEnergyCount)
        {
            energyCount = maxEnergyCount;
        }
    }
    
     public void IsKilled()
    {
        if (energyCount > 0 && hasSaveActive && deathCooldown > timer)
        {
            Rewind();
            timer = 0;
            energyCount = energyCount - 1;
        }
        else if (deathCooldown > timer)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    
    public void Rewind()
    {
        transform.position = pos;
        isSaved = false;
        SaveActive(isSaved);
        CanPause.enabled = true;

    }

    void Save(){
        pos = this.transform.position;
        isSaved = true;

        SaveActive(isSaved);
        CanPause.enabled = false;
        GameObject newRemnant = Instantiate(remnantPrefab, this.pos, Quaternion.identity);
        
    }
}
