using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private Transform gun;
    [SerializeField] Animator gunAnim;
    [SerializeField] private float gunDistance = 1.5f;

    [Header("Bullet")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;

    [SerializeField] private int ammunitions;

    public int maxBullets;

    private GameObject gunObject;
    private bool gunFlipMov = true;
    public Image[] ammoUI;

    public Sprite fullBullet;
    public Sprite emptyBullet;

    void Start()
    {
        gunObject = GameObject.Find("Gun");
        gunObject.SetActive(false);
    }


    private bool gunFacingRight = true;
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - gun.position;

        for (int i = 0; i < ammoUI.Length; i++)
        {

            if (i < ammunitions)
            {
                ammoUI[i].sprite = fullBullet;
            }
            else
            {
                ammoUI[i].sprite = emptyBullet;
            }

            if (i < maxBullets)
            {
                ammoUI[i].enabled = true;
            }
            else
            {
                ammoUI[i].enabled = false;
            }

            if (Input.GetKeyDown(KeyCode.F3))
            {
                AddBullet(maxBullets);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ShootTheGame();
            }
        }


        gun.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gun.position = transform.position + Quaternion.Euler(0, 0, angle) * new Vector3(gunDistance, 0, 0);

        if (Input.GetKeyUp(KeyCode.Mouse0) && gunObject.activeSelf && ammunitions > 0)
        {
            Shoot(direction);
        }
        else if (ammunitions <= 0)
        {
            Debug.Log("NoMoreBullets!");
        }


        if (mousePos.x < gun.position.x && gunFacingRight)
        {
            gunFlip();
        }
        else if (mousePos.x > gun.position.x && !gunFacingRight)
        {
            gunFlip();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && gunObject.activeSelf == false)
        {
            gunObject.SetActive(true);
        }
        else if (ammunitions <= 0)
        {
            gunObject.SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.A) && gunFlipMov)
        {
            Debug.Log("right");
            gunFlipMov = !gunFlipMov;
            gun.localScale = new Vector3(gun.localScale.x * -1, gun.localScale.y, gun.localScale.z);
        }

        if (Input.GetKeyDown(KeyCode.D) && !gunFlipMov)
        {
            Debug.Log("left");
            gunFlipMov = true;
            gun.localScale = new Vector3(gun.localScale.x * -1, gun.localScale.y, gun.localScale.z);
        }

    }


    void gunFlip()
    {
        gunFacingRight = !gunFacingRight;
        gun.localScale = new Vector3(gun.localScale.x, gun.localScale.y * -1, gun.localScale.z);
    }
    void Shoot(Vector3 direction)
    {
        gunAnim.SetTrigger("Shoot");

        GameObject newBullet = Instantiate(bulletPrefab, gun.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;
        ammunitions -= 1;
        Debug.Log(ammunitions + " are left");
        if (isActiveAndEnabled == true)
        {
            Invoke("GunOff", 1);
        }

    }

    private void GunOff() => gunObject.SetActive(false);

    public void AddBullet(int bullets)
    {
        ammunitions += bullets;
        if (ammunitions > maxBullets)
        {
            ammunitions = maxBullets;
        }
    }

    public void ShootTheGame()
    {
        if (ammunitions > 0)
        {
            Application.Quit();
        }
        else
        {
            //il tire quand même 
            Application.Quit();
        }
    }
}
