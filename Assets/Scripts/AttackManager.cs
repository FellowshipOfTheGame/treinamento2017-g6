﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script relacionado a ataque/danos
public class AttackManager : MonoBehaviour {

	private StatsManager sm;

	public GameObject Heal;	// spawn hp
	public float Chance;	// chance de cair um um heal do inimigo
	private Vector3 EnemyPosition;

	// Use this for initialization
	void Start () {
		sm = gameObject.GetComponent<StatsManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CalculateDamage(float damage){
		//formula do dano/defesa

		float final = damage - sm.defense;

		if (final < 0)
			final = 0;
	
		//tratar as mortes
		if (!gameObject.GetComponent<HPManager> ().DealDamage (final)) {
			if (gameObject.tag == "Enemy") {
				// spawn hp
				int WillDrop = Random.Range (0, 100);
				if (WillDrop < Chance) {
					EnemyPosition = gameObject.transform.position;
					Instantiate (Heal, EnemyPosition, Quaternion.identity);
				}

				Destroy (gameObject);
			}
		}

	}
}