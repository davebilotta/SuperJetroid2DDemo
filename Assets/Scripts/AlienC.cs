﻿using UnityEngine;
using System.Collections;

public class AlienC : MonoBehaviour {

	public float attackDelay = 3f;
	public Projectile projectile;
	private Animator animator;
	public AudioClip attackSound;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();

		if (attackDelay > 0) { 
			StartCoroutine(OnAttack());

		}
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetInteger("AnimState",0);
	
	}

	IEnumerator OnAttack() { 
		yield return new WaitForSeconds(attackDelay);
		Fire();
		StartCoroutine(OnAttack());
	}

	void Fire() { 
		if (attackSound) {
			AudioSource.PlayClipAtPoint(attackSound,transform.position);
		}
		animator.SetInteger("AnimState",1);
	}

	void OnShoot() { 
		if (projectile) { 
			Projectile clone = Instantiate(projectile, transform.position, Quaternion.identity) as Projectile;
		}
	}

}
