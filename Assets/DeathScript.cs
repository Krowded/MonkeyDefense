using UnityEngine;
using System.Collections;

public class DeathScript : MonoBehaviour {

	public HealthComponent health;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnDestroyed()
	{
		SendMessage("OnLoss");
		Destroy(gameObject.transform.root.gameObject);
	}
}
