using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NavigationScript : MonoBehaviour {

	public Transform target;
	private NavMeshAgent agent;

	public float reachedGoal;

	// Use this for initialization
	void Start () {
		agent = gameObject.GetComponent<NavMeshAgent>();
		agent.SetDestination(target.position);
	}


	// Update is called once per frame
	void Update() {
		if(Vector3.Distance(agent.destination, transform.position) < reachedGoal)
		{
			HealthComponent h = target.gameObject.transform.parent.GetComponent<HealthComponent>();
			if (h)
			{
				h.Damage(1);
			} else
			{
				Debug.Log("No HealthComponent in " + target.gameObject.transform.parent.name);
			}

			Destroy(gameObject);
		}
	}
}
