using UnityEngine;
using System.Collections;

public class MonkeyDeathScript : MonoBehaviour {

	public HealthComponent health;

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
		Destroy(gameObject);
	}
}
