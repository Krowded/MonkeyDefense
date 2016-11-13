using UnityEngine;
using System.Collections;

public class ClickableTreeScript : MonoBehaviour {

	public GameObject TimerjackTower;
	public GameObject BananaTower;
	public GameObject Player;
	private PlayerScript player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		player = Player.GetComponent<PlayerScript>();
	}

	public void CutDownTree()
	{
		Destroy(gameObject);
		//Replace with stump?
	}

	void OnMouseDown()
	{
		Debug.Log(player.currentlySelected);

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
					lumberjack.GetComponent<Woodcutter>().TreeList = gameObject.transform.parent.gameObject;
					lumberjack.transform.SetParent(transform.parent.parent);
					Destroy(gameObject);
				}
				break;
			case PlayerScript.TowerType.BananaTower:
				if (player.CurrentLumber >= 3) //TODO: Add cost of bananaman
				{
					player.CurrentLumber -= 3;
					//SendMessage("Not enough lumber");

					GameObject banana = Instantiate(BananaTower, transform.position, Quaternion.identity) as GameObject;
					banana.transform.SetParent(transform.parent.parent);
					Destroy(gameObject);
				}
				break;
		}
	}
}
