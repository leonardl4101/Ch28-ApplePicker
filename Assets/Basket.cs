﻿using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour {

	public GUIText scoreGT;

	// Update is called once per frame
	void Update () 
	{
		Vector3 mousePos2D = Input.mousePosition;

		mousePos2D.z = -Camera.main.transform.position.z;

		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);

		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
	}

	void Start()
	{
		GameObject scoreGO = GameObject.Find ("ScoreCounter");
		scoreGT = scoreGO.GetComponent<GUIText> ();
		scoreGT.text = "0";
	}

	void OnCollisionEnter(Collision col1)
	{
		GameObject collidedWith = col1.gameObject;
		if (collidedWith.tag == "Apple") 
		{
			Destroy (collidedWith);
		}

		int score = int.Parse (scoreGT.text);
		score += 100;
		scoreGT.text = score.ToString ();

		if (score > HighScore.score) {
						HighScore.score = score;
				}
	}
}
