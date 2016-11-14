using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public enum TowerType { Nothing = 0, Lumberjack = 1, BananaTower = 2, ClusterTower = 3};

	public TowerType currentlySelected = TowerType.Nothing;

	public int CurrentLumber; // { get; set; }
	private int NumberOfDeadMonkeys = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		HandleKeyboardInput();	
	}

	public void NotifyMonkeyKill()
	{
		NumberOfDeadMonkeys++;
		if (NumberOfDeadMonkeys % 5 == 0)
			CurrentLumber++;
	}

    public void SelectLumberjack()
    {
        currentlySelected = TowerType.Lumberjack;
    }

    public void SelectBananatower()
    {
        currentlySelected = TowerType.BananaTower;
    }

    public void SelectClustertower()
    {
        currentlySelected = TowerType.ClusterTower;
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
		else if(Input.GetKeyDown(KeyCode.Escape))
		{
			SendMessageUpwards("OnLoss");
		}
	}
}
