using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class CreateArrows : MonoBehaviour {

	public PlayerScript player;
    public float Range;
    public float shootDelay;
    public GameObject Projectile;
	public GameObject enemyList;
    private float lastTick;

	private AudioSource sound;

	// Use this for initialization
	void Start () {
		sound = GetComponent<AudioSource>();
        lastTick = Time.time;
	}

    // Update is called once per frame
    void Update() {
        if (Time.time > lastTick + shootDelay)
        {
            for (int i = 0; i < enemyList.transform.childCount; i++)
            {
                Transform enemyTransform = enemyList.transform.GetChild(i);
                if ( Vector3.Distance(enemyTransform.position, gameObject.transform.position) < Range)
                {
                    Shoot(enemyTransform);
                    break;
                }
            }
            lastTick = Time.time;
        }
    }
    void Shoot(Transform enemyTransform)
    {
		Vector3 spawnPosition = gameObject.transform.position;
        GameObject arrow = Instantiate(Projectile, spawnPosition, Quaternion.Euler(0, 0, 0)) as GameObject;
		ArrowMovement arrowScript = arrow.GetComponent<ArrowMovement>();
		arrowScript.enemyTransform = enemyTransform;
		sound.Play();
    }
}
