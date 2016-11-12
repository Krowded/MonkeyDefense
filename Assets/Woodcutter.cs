using UnityEngine;
using System.Collections;

public class Woodcutter : MonoBehaviour {

    public float Range;
    public float cutDelay;
    private float lastTick;

	// Use this for initialization
	void Start () {
        lastTick = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > lastTick + cutDelay)
        {
            for (int i = 0; i < gameObject.transform.parent.childCount; i++)
            {
                Transform treeTransform = gameObject.transform.parent.GetChild(i);
                if (Vector3.Distance(treeTransform.position, gameObject.transform.position) < Range)
                {
                    Cutting(treeTransform);
                }
            }
            lastTick = Time.time;
        }
    }
    void Cutting(Transform treeTransform)
    { }
}
