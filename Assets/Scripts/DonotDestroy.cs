using UnityEngine;
using System.Collections;

public class DonotDestroy : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(gameObject);
	}
}
