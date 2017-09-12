﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateArena : MonoBehaviour {

	public GameObject[] tiles;
	public GameObject[] walls;

	private int rows = 18;
	//private int columns = 10;

	private float Xinit = 10.5f;
	private float Yinit = 5.25f;

	private float incX = 0.7f;
	private float incY = 0.35f;

	private float k = -1f;

	public List<Vector3> possiblePositions = new List<Vector3>();
	public bool ArenaFinished = false;

	// Use this for initialization
	void Start () {

		Vector3 newPosition;

		GameObject newTile;

		possiblePositions.Clear ();

		float Xmax = (rows - 1) * incX; //(rows / 2) * incX;
		float Ymax = rows * incY; //(rows / 2) * incY;


		for (int x = 0; x < rows; x++) {
			//wall L
			newTile = walls [0];

			newPosition = new Vector3 (-Xmax + x*incX - 0.35f, x*incY - 0.185f, 0f);
			Instantiate (newTile, newPosition, Quaternion.identity);

			newPosition = new Vector3 (-Xmax + x*incX - 0.35f, x*incY + 1.015f, 0f);
			Instantiate (newTile, newPosition, Quaternion.identity);


			for (float y = 0; y < rows; y++) {
				Xinit = -Xmax + x*incX + y*incX;
				Yinit = 0 + x*incY - y*incY + k;

				newPosition = new Vector3 (Xinit, Yinit, 0f);


				if (Random.Range (0, 9) < 1) {
					//if (Random.Range (0, 9) < 5) {
						newTile = tiles [Random.Range (1, tiles.Length)];
					//} else {
					//	newTile = tiles [26];
					//}
				} else {
					newTile = tiles [0];
				}



				Instantiate (newTile, newPosition, Quaternion.identity);

				possiblePositions.Add (newPosition);

				if (x == rows - 1) {
					newTile = walls [1];

					newPosition = new Vector3 (-Xmax + x*incX + y*incX + 0.35f, x*incY - y*incY - 0.185f, 0f);
					Instantiate (newTile, newPosition, Quaternion.identity);

					newPosition = new Vector3 (-Xmax + x*incX + y*incX + 0.35f, x*incY - y*incY + 1.015f, 0f);
					Instantiate (newTile, newPosition, Quaternion.identity);
				}
			}
		}

		ArenaFinished = true;

	}


	
	// Update is called once per frame
	void Update () {
		
	}
}
