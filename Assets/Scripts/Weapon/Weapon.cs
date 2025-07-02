using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    //TODO
    //1. Make force change per weapon DONE
    //2. Add Charges DONE
    //3. Add UI showcasing the switches
    //4. Make fire boom DONE
    //5. Make wind knockback
    //6. 


    public Weapons myWeapon;
    int weaponRange; //Maybe add so different weapons have different range
    int weaponAttackSpeed;
    int weaponProjectileSpeed;
    int weaponCharges;
    float weaponReloadTime;
    float weaponShootForce;
    private int maxCharges;
    private float timer;
    private float delay;


    public List<GameObject> uiWeaponSprites;

    public List<GameObject> bulletPrefabList;
    public GameObject bulletPrefab;
    public Transform shootingPosition; //This will be at the edge of the wand
    public Transform particlePosition;
    public GameObject Player;
    public GameObject Particle;

    public List<AudioSource> weaponSoundEffects;

    public List<GameObject> weaponLights;

    public int fireBullets;
    public int iceBullets;
    public int windBullets;

    public List<Text> amoTexts;

    public AudioSource noAmoSFX;

    // Start is called before the first frame update
    void Start()
    {
        bulletPrefab = bulletPrefabList[0];
        weaponLights[0].SetActive(true);
        myWeapon = Weapons.Fire;
        timer = 0f;
        delay = 0.25f;

        fireBullets = 10;
        iceBullets = 10;
        windBullets = 10;
    }
    

    // Update is called once per frame
    void Update()
    {
        GetWeapon();
        if (Input.GetButtonDown("Fire1")) //change timer
        {
            var player = Player.GetComponent<PlayerMovement>();
            timer += Time.deltaTime;
            if(!player.isDashing)
            {
                switch (myWeapon)
                {
                    case Weapons.Fire:
                        if (fireBullets > 0)
                        {
                            fireBullets--;
                            Shoot();
                        }
                        else noAmoSFX.Play();
                        break;
                    case Weapons.Ice:
                        if (iceBullets > 0)
                        {
                            iceBullets--;
                            Shoot();
                        }
                        else noAmoSFX.Play();
                        break;
                    case Weapons.Wind:
                        if (windBullets > 0)
                        {
                            windBullets--;
                            Shoot();
                        }
                        else noAmoSFX.Play();
                        break;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadAmo(myWeapon);
        }

        updateChargeText();


    }

    public void Shoot() //Firest bullets from players position, maybe change this so u cna take input on bulletPrefab and shootingPosition/rotation
    {

        //Initiate bullet
        GetWeapon();
        var bullet =
            Instantiate(bulletPrefab, shootingPosition.position,
                shootingPosition //shootingPositio
                    .rotation); //Shooting position will be the wand, change the wand position/rotation depending on mouse hover, and it should follow maybe perhaps perchance 
        var rb = bullet.GetComponent<Rigidbody2D>();
        bullet.GetComponent<Bullet>(); //Remove this when u make a prefab so u can make a prefab with the script and add proper boxcolliders for bullet reference
        var bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.SetBulletType(myWeapon);
        rb.AddForce(shootingPosition.up * weaponShootForce, ForceMode2D.Impulse);

        //particles on usage
        var particleEffecet = Particle.GetComponent<Animator>();
        particleEffecet.SetInteger("ParticleNumber", ((int)myWeapon + 1));
        Invoke("ResetParticle", 0.25f);

        //sound effects
        weaponSoundEffects[(int)myWeapon].Play();
    }

    void ResetParticle()
    {
        var part = Particle.GetComponent<Animator>();
        part.SetInteger("ParticleNumber", 0);
    }
    public void GetWeapon() //Changes the weapon
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var intmyWeapon = (int)myWeapon;
            if (intmyWeapon == 2) intmyWeapon = 0; //Change this if we have more than three weapons
            else intmyWeapon++;
            myWeapon = (Weapons)Enum.ToObject(typeof(Weapons), intmyWeapon); //Convert from int to enum
        }

        switch (myWeapon)
        {
            case Weapons.Fire:
                bulletPrefab = bulletPrefabList[0];
                ChangeLights(0);
                weaponShootForce = 20f;
                weaponCharges = 5;
                maxCharges = 10;
                weaponReloadTime = 0.75f;
                break;
            case Weapons.Ice:
                bulletPrefab = bulletPrefabList[1];
                ChangeLights(1);
                weaponShootForce = 15f;
                weaponCharges = 3;
                maxCharges = 10;
                weaponReloadTime = 1f;
                break;  
            case Weapons.Wind:
                bulletPrefab = bulletPrefabList[2];
                ChangeLights(2);
                weaponShootForce = 25f;
                weaponCharges = 10;
                maxCharges = 10;
                weaponReloadTime = 0.5f;
                break;
        }

        foreach (GameObject sprites in uiWeaponSprites)
        {
            if (sprites != uiWeaponSprites[(int)myWeapon])
            {
                sprites.SetActive(false);
            }
            else sprites.SetActive(true);
        }
    }

    void ChangeLights(int lightIndex)
    {
        foreach(GameObject lights in weaponLights)
        {
            if (lights != weaponLights[lightIndex])
            {
                lights.SetActive(false);
            }
            else
            {
                switch (myWeapon)
                {
                    case Weapons.Fire:
                        if(fireBullets>0) lights.SetActive(true);
                        else lights.SetActive(false);
                        break;
                    case Weapons.Ice:
                        if (iceBullets > 0) lights.SetActive(true);
                        else lights.SetActive(false);
                        break;
                    case Weapons.Wind:
                        if (windBullets > 0) lights.SetActive(true);
                        else lights.SetActive(false);
                        break;
                }
            }
                
        }
    }
    void ShootingParticles()
    {

    }

    void updateChargeText()
    {
        amoTexts[0].text = fireBullets.ToString() + "x";
        amoTexts[1].text = iceBullets.ToString() + "x";
        amoTexts[2].text = windBullets.ToString() + "x";

    }

    void ReloadAmo(Weapons currentWeapon)
    {
        switch (currentWeapon)
        {
            case Weapons.Fire:
                fireBullets = maxCharges;
                break;
            case Weapons.Ice:
                iceBullets = maxCharges;
                break;
            case Weapons.Wind:
                windBullets = maxCharges;
                break;
        }
    }

    public enum Weapons
    {
        Fire,
        Ice,
        Wind
    }


}