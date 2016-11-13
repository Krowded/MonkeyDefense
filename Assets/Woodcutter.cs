using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Woodcutter : MonoBehaviour {

    public float Range;
    public float cutDelay;
    private float lastTick;
	public GameObject TreeList;
	public PlayerScript player;

	private AudioSource sound;

	// Use this for initialization
	void Start () {
		sound = GetComponent<AudioSource>();
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
		int lumberReward = treeTransform.gameObject.GetComponent<ClickableTreeScript>().CutDownTree();
		player.CurrentLumber += lumberReward;
		sound.Play();
}
}
