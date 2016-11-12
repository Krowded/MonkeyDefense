using UnityEngine;
using System.Collections;

public class MonkeyMaker : MonoBehaviour {

	public float interval;
	private float lastTick;
	public GameObject monkeyType;
	public GameObject monkeyTarget;

	// Use this for initialization
	void Start () {
		lastTick = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > lastTick + interval)
		{
			CreateMonkey();
			lastTick = Time.time;
		}
	}

	void CreateMonkey()
	{
		Vector3 pos = gameObject.transform.position;
		pos.y = 0;
		GameObject monkey = Instantiate(monkeyType, pos, Quaternion.identity) as GameObject;
		monkey.GetComponent<NavigationScript>().target = monkeyTarget.transform;
		monkey.transform.SetParent(gameObject.transform.parent);
	}
}
