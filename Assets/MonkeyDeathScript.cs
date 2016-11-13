using UnityEngine;
using System.Collections;

public class MonkeyDeathScript : MonoBehaviour {

	public HealthComponent health;
	public PlayerScript player;

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
	}

	void OnDestroyed()
	{
		player.NotifyMonkeyKill();
		Destroy(gameObject);
	}
}
