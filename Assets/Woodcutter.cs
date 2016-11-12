using UnityEngine;
using System.Collections;

public class Woodcutter : MonoBehaviour {

    public float Range;
    public float cutDelay;
    private float lastTick;
	public GameObject TreeList;

	// Use this for initialization
	void Start () {
        lastTick = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > lastTick + cutDelay)
        {
            for (int i = 0; i < TreeList.transform.childCount; i++)
            {
				//Transform treeTransform = gameObject.transform.parent.GetChild(i);
				Transform treeTransform = TreeList.transform.GetChild(i).transform;
                if (Vector3.Distance(treeTransform.position, gameObject.transform.position) < Range)
                {
                    Cutting(treeTransform);
					break;
                }
            }
            lastTick = Time.time;
        }
    }
    void Cutting(Transform treeTransform)
    {
		treeTransform.gameObject.GetComponent<ClickableTreeScript>().CutDownTree();
		Debug.Log("Tree cut down!");
		//TODO: Add lumber to player
	}
}
