﻿using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public enum TowerType { Nothing = 0, Lumberjack = 1, BananaTower = 2 };

	public TowerType currentlySelected = TowerType.Nothing;

	public int CurrentLumber; // { get; set; }

	// Use this for initialization
	void Start () {
		CurrentLumber = 100; //For testing purposes
	}
	
	// Update is called once per frame
	void Update () {
		HandleKeyboardInput();	
	}

	void HandleKeyboardInput()
	{
		if(Input.GetKeyDown("1"))
		{
			currentlySelected = TowerType.Lumberjack;
		} else if (Input.GetKeyDown("2"))
		{
			currentlySelected = TowerType.BananaTower;
		}
	}
}
