using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NavigationScript : MonoBehaviour {

	public Transform target;
	public int DamagePotential = 1;
	public float Speed = 1;
	private NavMeshAgent agent;

	public float reachedGoal;

	// Use this for initialization
	void Start () {
		agent = gameObject.GetComponent<NavMeshAgent>();
		agent.SetDestination(target.position);
		agent.speed = Speed * 50;
	}


	// Update is called once per frame
	void Update() {
		if (Vector3.Distance(target.position, transform.position) < reachedGoal)
		{
			HealthComponent h = target.gameObject.transform.parent.GetComponent<HealthComponent>();
			if (h)
			{
				h.Damage(DamagePotential);
			} else
			{
				Debug.Log("No HealthComponent in " + target.gameObject.transform.parent.name);
			}

			Destroy(gameObject);
		}
	}
}
