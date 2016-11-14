using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthView : MonoBehaviour {

    public HealthComponent health;
    private Text text;

	// Use this for initialization
	void Start () {
        text = transform.FindChild("Text").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        text.text = "Lives left: " + health.life;
	}
}
