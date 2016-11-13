using UnityEngine;
using System.Collections;

public class MonkeyMaker : MonoBehaviour {

	public float interval;
	private float lastTick;
	public GameObject monkeyType;
	public GameObject monkeyTarget;
	public GameObject enemyList;

	public int MaxLevel = 3;
	public int DifficultyLevel = 1;
	public int MonkeyCounter = 0;

	// Use this for initialization
	void Start () {
		lastTick = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (DifficultyLevel > MaxLevel)
		{
			if (enemyList.transform.childCount == 0)
			{
				SendMessageUpwards("OnWin");
			}

			return;
		}


		if(Time.time > lastTick + interval)
		{
			CreateMonkey();
			MonkeyCounter++;
			lastTick = Time.time;
		}

		if(MonkeyCounter > 30) //One wave of 30 monkeys
		{
			MonkeyCounter = 0;
			lastTick = Time.time + 5;
			DifficultyLevel++;
		}
	}

	void CreateMonkey()
	{
		Vector3 pos = gameObject.transform.position;
		pos.y = 0;
		GameObject monkey = Instantiate(monkeyType, pos, Quaternion.identity) as GameObject;
		NavigationScript monkeyMovementScript = monkey.GetComponent<NavigationScript>();
		monkeyMovementScript.target = monkeyTarget.transform;
		monkey.transform.SetParent(enemyList.transform);

		HealthComponent h;
		switch(DifficultyLevel)
		{
			case 1:
				break;
			case 2:
				h = monkey.GetComponent<HealthComponent>();
				h.life = 20;
				monkeyMovementScript.DamagePotential = 2;
				interval = 1f;
				break;
			case 3:
				h = monkey.GetComponent<HealthComponent>();
				h.life = 20;
				interval = 0.5f;
				monkeyMovementScript.DamagePotential = 2;
				break;
			default:
				Debug.Log("Impossible level!");
				break;
		}

	}
}
