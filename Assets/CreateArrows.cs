using UnityEngine;
using System.Collections;

public class CreateArrows : MonoBehaviour {

    public GameObject Arrow;
    public Transform spawnPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Arrow, spawnPos.position, spawnPos.rotation);
        }
	
	}
}
