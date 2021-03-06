﻿using UnityEngine;
using System.Collections;

public class ClickableTreeScript : MonoBehaviour {

	public GameObject TimerjackTower;
	public GameObject BananaTower;
    public GameObject ClusterTower;
	public GameObject Player;
	private PlayerScript player;
	public int Lumber = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		player = Player.GetComponent<PlayerScript>();
	}

	public int CutDownTree()
	{
		Destroy(gameObject);
		//Replace with stump?
		return Lumber;
	}

	void OnMouseDown()
	{
		switch (player.currentlySelected)
		{
			case PlayerScript.TowerType.Nothing:
			break;
			case PlayerScript.TowerType.Lumberjack:
				if (player.CurrentLumber >= 1) //TODO: Add cost of lumberjack
				{
					player.CurrentLumber -= 1;
					//SendMessage("Not enough lumber");

					GameObject lumberjack = Instantiate(TimerjackTower, transform.position, Quaternion.identity) as GameObject;
					Woodcutter woodcutterScript = lumberjack.GetComponent<Woodcutter>();
					woodcutterScript.TreeList= gameObject.transform.parent.gameObject;
					woodcutterScript.player = player;

					lumberjack.transform.SetParent(transform.parent.parent);
					Destroy(gameObject);
				}
				break;
			case PlayerScript.TowerType.BananaTower:
				if (player.CurrentLumber >= 3) //TODO: Add cost of bananaman
				{
					player.CurrentLumber -= 3;
					//SendMessage("Not enough lumber");
					Vector3 spawnPosition = transform.position;
					spawnPosition.y += BananaTower.transform.position.y;
					GameObject banana = Instantiate(BananaTower, spawnPosition, Quaternion.identity) as GameObject;
					CreateArrows bananaTowerScript = banana.GetComponent<CreateArrows>();
					bananaTowerScript.enemyList = gameObject.transform.parent.parent.FindChild("EnemyList").gameObject;
					bananaTowerScript.player = player;
					banana.transform.SetParent(transform.parent.parent);
					Destroy(gameObject);
				}
				break;
            case PlayerScript.TowerType.ClusterTower:
                if (player.CurrentLumber >= 5) //TODO: Add cost of bananaman
                {
                    player.CurrentLumber -= 5;
                    //SendMessage("Not enough lumber");
                    Vector3 spawnPosition = transform.position;
                    spawnPosition.y += ClusterTower.transform.position.y;
                    GameObject clusterBanana = Instantiate(ClusterTower, spawnPosition, Quaternion.identity) as GameObject;
                    CreateCluster bananaTowerScript = clusterBanana.GetComponent<CreateCluster>();
                    bananaTowerScript.enemyList = gameObject.transform.parent.parent.FindChild("EnemyList").gameObject;
                    bananaTowerScript.player = player;
                    clusterBanana.transform.SetParent(transform.parent.parent);
                    Destroy(gameObject);
                }
                break;
        }
	}
}
