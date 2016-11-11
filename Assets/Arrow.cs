using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

    private Transform body;
    public float speed;


	// Use this for initialization
	void Start () {
        body = gameObject.transform;
	
	}
	
	// Update is called once per frame
	void Update () {
        body.position += body.up*speed*Time.deltaTime;
	}
}
