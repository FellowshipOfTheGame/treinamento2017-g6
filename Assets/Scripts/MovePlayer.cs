﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

	private Rigidbody2D Rigid;
	private Animator anim;
	private bool facingRight = true;
	public float MoveSpeed;

	// Use this for initialization
	void Start () {
		Rigid = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move() {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		if (h != 0.0f || v != 0.0f) {
			if (h > 0.0f && !facingRight) {
				facingRight = true;
				transform.localScale = new Vector3 (transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
			} else if (h < 0.0f && facingRight) {
				facingRight = false;
				transform.localScale = new Vector3 (transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
			}
			anim.SetBool ("isWalking", true);
		} else 
			anim.SetBool ("isWalking", false);

		Rigid.velocity = new Vector2 (MoveSpeed * h, MoveSpeed * v);
	}
}
