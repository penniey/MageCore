using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorContrtoller : MonoBehaviour
{
	public BoxCollider2D doorTriggerCollider;
	private Animator animator;

    public AudioSource doorSoundEffect;

	bool doorTriggerOpen = false;

    public bool doorOpen;

	private void Start()
	{
		doorTriggerCollider = GetComponent<BoxCollider2D>();
		animator = GetComponent<Animator>();
        doorSoundEffect = GetComponent<AudioSource>();
        doorOpen = false;

    }

	private void Update()
	{
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
			doorTriggerCollider.isTrigger = true;
			doorTriggerOpen = true;
			doorSoundEffect.Play();
			animator.SetBool("doorTriggerOpen", doorTriggerOpen);
            doorOpen = true;
        }
	}


	void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.CompareTag("Player"))
        {
            doorOpen = true;
            doorTriggerCollider.isTrigger = true;
            doorTriggerOpen = true;
            doorSoundEffect.Play();
            animator.SetBool("doorTriggerOpen", doorTriggerOpen);
        }
    }

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Player")
        {
            doorOpen = false;
			doorTriggerCollider.isTrigger = false;
			doorTriggerOpen = false;
            doorSoundEffect.Play();
			animator.SetBool("doorTriggerOpen", doorTriggerOpen);
		}
	}
}
