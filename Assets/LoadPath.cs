using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class LoadPath : MonoBehaviour {

	public int treesPerTile;
	private List<Transform> treeList;
	private int worldScale = 50;

	// Use this for initialization
	void Start () {
		treeList = new List<Transform>();
		Transform TreeListObject = gameObject.transform.FindChild("TreeList");
		for (int i = 0; i < TreeListObject.childCount; i++)
		{
			treeList.Add(TreeListObject.GetChild(i));
		}

		List<string> text = new List<string>(System.IO.File.ReadAllLines("Map.txt"));
		int xcounter = 0;
		int ycounter = 0;
		int treeCounter = 0;
		foreach(string line in text)
		{
			xcounter = 0;
			foreach(char c in line)
			{
				switch(c) {
					case ' ':
						//path

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
						transform.FindChild("MonkeyTower").transform.position = worldScale * (new Vector3(xcounter, 0, ycounter));
						break;
					case 'E':
						//tower
						transform.FindChild("BaseTower").transform.position = worldScale * (new Vector3(xcounter, 0, ycounter));
						transform.FindChild("DestinationPoint").transform.position = worldScale * (new Vector3(xcounter, 0, ycounter));
					break;
				}

				xcounter++;
			}
			ycounter++;
		}

	}	
}
