﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

	// Use this for initialization
	public Text scoreText;
	public Image backgroundImage;
	private bool isShowned = false;
	private float transition = 0.0f;
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isShowned)
			return;
		transition += Time.deltaTime;
		backgroundImage.color = Color.Lerp (new Color (0, 0, 0, 0), Color.black, transition); 
	}
	public void ToggleEndMenu(float score)
	{
		gameObject.SetActive (true);
		scoreText.text = ((int)score).ToString ();
		isShowned = true;
	}
	public void Restart(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
	public void ToMenu()
	{
		SceneManager.LoadScene ("Menu");
	}
}
