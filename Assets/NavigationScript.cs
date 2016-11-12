using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AggregatGames.AI.Pathfinding;

public class NavigationScript : MonoBehaviour {

	public Transform target;
	private NavMeshAgent agent;


	public float speed = 0.5f;
	public float reachedKnot = 2f;

	// Use this for initialization
	void Start () {
		agent = gameObject.GetComponent<NavMeshAgent>();
		agent.SetDestination(target.position);
	}


	// Update is called once per frame
	void Update() {

	}
}
