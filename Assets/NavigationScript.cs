using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NavigationScript : MonoBehaviour {


	private NavMeshAgent agent;
	private List<Transform> destinationPoints;
	private int currentTarget = 0;

	// Use this for initialization
	void Start () {
		agent = gameObject.GetComponent<NavMeshAgent>();
		destinationPoints = new List<Transform>();

		Transform parentTransform = gameObject.transform.parent.gameObject.transform;
		foreach(Transform child in parentTransform)
		{
			if (child.name.Contains("DestinationPoint"))
				destinationPoints.Add(child);
		}

		agent.SetDestination(destinationPoints[currentTarget].transform.position);

	}
	
	void ArrivedAtTarget()
	{
		currentTarget = (currentTarget + 1) % destinationPoints.Count;
		agent.SetDestination(destinationPoints[currentTarget].transform.position);
	}

	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(gameObject.transform.position, agent.destination) < 30)
			ArrivedAtTarget();
	}
}
