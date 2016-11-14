using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourcesView : MonoBehaviour {

    private Text text;
    public PlayerScript player;

	// Use this for initialization
	void Start () {
        text = transform.FindChild("Text").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

        text.text = "Current Lumber: " + player.CurrentLumber;
	}
}
