using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(AudioSource))]
public class LoadPath : MonoBehaviour {

	public int treesPerTile;
	private List<Transform> treeList;
	private int worldScale;
	public string Level = "Map.txt";
	private string Level2 = "Map2.txt";

	private AudioSource sound;

	// Use this for initialization
	void Start () {
		sound = GetComponent<AudioSource>();

		treeList = new List<Transform>();
		Transform TreeListObject = gameObject.transform.FindChild("TreeList");
		for (int i = 0; i < TreeListObject.childCount; i++)
		{
			treeList.Add(TreeListObject.GetChild(i));
		}

		//Fake levelselection
		string levelFile;
		int coinFlip = UnityEngine.Random.Range(1, 3);
		if(coinFlip > 1)
		{
			levelFile = Level;
		} else {
			levelFile = Level2;
		}

		List<string> text = new List<string>(System.IO.File.ReadAllLines(levelFile));
		int xcounter = 0;
		int ycounter = 0;
		int treeCounter = 0;
		bool firstLine = true;
		foreach(string line in text)
		{
			if(firstLine)
			{
				worldScale = Int32.Parse(line);
				firstLine = false;
				continue;
			}

			xcounter = 0;
			foreach(char c in line)
			{
				switch(c) {
					case ' ':
						//path
						//Do nothing
					break;
					case '#':
						//trees
						for (int i = 0; i < treesPerTile; i++)
						{
							float offsetx = UnityEngine.Random.value - 0.5f;
							float offsety = UnityEngine.Random.value - 0.5f;
							treeList[treeCounter].position = worldScale * (new Vector3(xcounter+offsetx, 0, ycounter+offsety));
							treeCounter++;
						}
						break;
					case 'S':
						//monkeytower
						Transform monkeyTowerTransform = transform.FindChild("MonkeyTower").transform;
						monkeyTowerTransform.position = new Vector3(worldScale*xcounter, monkeyTowerTransform.position.y, worldScale*ycounter);
						break;
					case 'E':
						//tower
						Transform baseTowerTransform = transform.FindChild("BaseTower").transform;
						baseTowerTransform.position = new Vector3(worldScale * xcounter, baseTowerTransform.position.y, worldScale * ycounter);
						baseTowerTransform.FindChild("DestinationPoint").transform.position = new Vector3(worldScale * xcounter, 0, worldScale * ycounter);
					break;
				}

				xcounter++;
			}
			ycounter++;
		}

		sound.Play();
	}	
}
