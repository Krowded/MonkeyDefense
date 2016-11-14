using UnityEngine;
using System.Collections;

public class MonkeyMaker : MonoBehaviour {

	public float interval;
	private float lastTick;
	public GameObject monkeyType;
    public GameObject resourceMonkeyType;
    public GameObject cavalleryMonkeyType;
	public GameObject monkeyTarget;
	public GameObject enemyList;
	public PlayerScript player;

	public int MaxLevel = 3;
	public int DifficultyLevel = 1;
	public int MonkeyCounter = 0;
	public int MonkeysPerWave = 30;
	public int secondsBetweenWaves = 6;

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
            switch (MonkeyCounter)
            {
                case 5:
                case 10:
                case 15:
                case 20:
                case 25:
                    CreateResourceMonkey();
                    break;
                case 12:
                case 24:
                    CreateCavalleryMonkey();
                    break;
                default:
                    CreateMonkey();
                    break;
            }
			MonkeyCounter++;
			lastTick = Time.time;
		}

		if(MonkeyCounter > MonkeysPerWave)
		{
			MonkeyCounter = 0;
			lastTick = Time.time + secondsBetweenWaves;
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

		MonkeyDeathScript monkeyDeathScript = monkey.GetComponent<MonkeyDeathScript>();
		monkeyDeathScript.player = player;

		monkey.transform.SetParent(enemyList.transform);

		HealthComponent h;
		switch(DifficultyLevel)
		{
			case 1:
				h = monkey.GetComponent<HealthComponent>();
				h.life = 10;
				monkeyMovementScript.DamagePotential = 1;
				monkeyMovementScript.Speed = 1f;
				interval = 2.0f;
				break;
			case 2:
				h = monkey.GetComponent<HealthComponent>();
				h.life = 10;
				monkeyMovementScript.DamagePotential = 2;
				monkeyMovementScript.Speed = 1f;
				interval = 1.0f;
				break;
			case 3:
				h = monkey.GetComponent<HealthComponent>();
				h.life = 10;
				interval = 0.5f;
				monkeyMovementScript.DamagePotential = 3;
				monkeyMovementScript.Speed = 1f;
				break;
			default:
				Debug.Log("Impossible level!");
				break;
		}

	}
    void CreateResourceMonkey()
    {
        Vector3 pos = gameObject.transform.position;
        pos.y = 0;
        GameObject monkey = Instantiate(resourceMonkeyType, pos, Quaternion.identity) as GameObject;
        NavigationScript monkeyMovementScript = monkey.GetComponent<NavigationScript>();
        monkeyMovementScript.target = monkeyTarget.transform;

        ResourceMonkeyDeathScript monkeyDeathScript = monkey.GetComponent<ResourceMonkeyDeathScript>();
        monkeyDeathScript.player = player;

        monkey.transform.SetParent(enemyList.transform);

        HealthComponent h = monkey.GetComponent<HealthComponent>();
        h.life = 10;
        monkeyMovementScript.DamagePotential = 1;
        monkeyMovementScript.Speed = 1f;
        interval = 2.0f;
    }
     void CreateCavalleryMonkey()
    {
        Vector3 pos = gameObject.transform.position;
        pos.y = 0;
        GameObject monkey = Instantiate(cavalleryMonkeyType, pos, Quaternion.identity) as GameObject;
        NavigationScript monkeyMovementScript = monkey.GetComponent<NavigationScript>();
        monkeyMovementScript.target = monkeyTarget.transform;

        MonkeyDeathScript monkeyDeathScript = monkey.GetComponent<MonkeyDeathScript>();
        monkeyDeathScript.player = player;

        monkey.transform.SetParent(enemyList.transform);

        HealthComponent h = monkey.GetComponent<HealthComponent>();
        h.life = 12;
        monkeyMovementScript.DamagePotential = 1;
        monkeyMovementScript.Speed = 2f;
        interval = 2.0f;
    }
}
