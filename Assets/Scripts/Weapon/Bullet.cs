using System.Collections;
using System.Collections.Generic;
using FirstGearGames.SmoothCameraShaker;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Weapon.Weapons type;

    public float bulletDamage;

    public GameObject fireBallPrefab;
    public EnemyCybercore eCyber;

    public ShakeData onHitShaker;

    public AudioClip onHitSfx;

        
    

    public void SetBulletType(Weapon.Weapons typeOfWeapon) 
    {
        type = typeOfWeapon;
    }

    void Start()
    {
        gameObject.tag = "Bullet";
    }
    void Update()
    {
        BulletValues();
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //add animation
        //Check if it's enemy then do enemy things

        if (collision.gameObject.tag == "Enemy")
        {
            switch(collision.gameObject.name)
            {
                case "EnemyCybercore":
                    var eScript = collision.gameObject.GetComponent<EnemyCybercore>();
                    eScript.TakeDamage(bulletDamage);
                    AudioSource.PlayClipAtPoint(onHitSfx, this.gameObject.transform.position);
                    break;
                case "EnemyCrystal":
                    var eScript2 = collision.gameObject.GetComponent<EnemyCrystal>();
                    eScript2.TakeDamage(bulletDamage);
                    AudioSource.PlayClipAtPoint(onHitSfx, this.gameObject.transform.position);
                    break;
            }
            if (type == Weapon.Weapons.Wind)
            {
                var rb = collision.gameObject.GetComponent<Rigidbody2D>();

                rb.AddForce(new Vector2(), ForceMode2D.Impulse);

            }
            else if (type == Weapon.Weapons.Fire)
            {
                var bulletCurrentPosition = gameObject.transform;
                var fireball =
                    Instantiate(fireBallPrefab, bulletCurrentPosition.position,
                        bulletCurrentPosition
                            .rotation);
                var fireballScript = fireball.AddComponent<Fireball>();
            }
            else if (type == Weapon.Weapons.Ice)
            {
                var player = GameObject.Find("Player");
                var playerScript = player.GetComponent<PlayerHealth>();
                if (playerScript.health < playerScript.maxHealth)
                {
                    playerScript.health += 3; //idk change number
                    var playerObject = GameObject.Find("Player");
                    var healthbarscript = playerObject.GetComponent<PlayerHealthBar>();
                    healthbarscript.ChangeLife(-3);
                }
                //Get health and increase it
            }   
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Wall")
        {
            if (type == Weapon.Weapons.Wind)
            {
                var anim = gameObject.GetComponent<Animator>();
                anim.SetBool("Hit_Something", true);

            }
            if (type == Weapon.Weapons.Ice)
            {
                var anim = gameObject.GetComponent<Animator>();
                anim.SetBool("Hit_Something", true);
            }
            if (type == Weapon.Weapons.Fire)
            {
                var anim = gameObject.GetComponent<Animator>();
                CameraShakerHandler.Shake(onHitShaker);
                anim.SetBool("Hit_Something", true);
            }
            var rb = gameObject.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Static;
            Invoke("Destroyer", 0.3f);

        }
        else if (collision.gameObject.tag == "Door")
        {
            if (type == Weapon.Weapons.Wind)
            {
                var anim = gameObject.GetComponent<Animator>();
                anim.SetBool("Hit_Something", true);

            }
            if (type == Weapon.Weapons.Ice)
            {
                var anim = gameObject.GetComponent<Animator>();
                anim.SetBool("Hit_Something", true);
            }
            if (type == Weapon.Weapons.Fire)
            {
                var anim = gameObject.GetComponent<Animator>();
                CameraShakerHandler.Shake(onHitShaker);
                anim.SetBool("Hit_Something", true);
            }
            var rb = gameObject.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Static;
            Invoke("Destroyer", 0.3f);
        }
        else if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        //Destroy(gameObject);
    }


    void BulletValues()
    {
        switch (type)
        {
            case Weapon.Weapons.Fire:
                bulletDamage = 10;
                break;
            case Weapon.Weapons.Ice:
                bulletDamage = 20;
                break;
            case Weapon.Weapons.Wind:
                
                var critChance = Random.Range(1, 11);
                var critDmg = 1.0;
                if (critChance > 6) critDmg = 1.5;
                bulletDamage = (float)(20 * critDmg);
                break;
        }
    }


    private void Destroyer()
    {
        Destroy(gameObject);
    }
}
