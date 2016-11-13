using UnityEngine;
using System.Collections;

public class CreateArrows : MonoBehaviour {

    public float Range;
    public float shootDelay;
    public GameObject Projectile;
	public GameObject enemyList;
    private float lastTick;

	// Use this for initialization
	void Start () {
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
		spawnPosition.y += 50;
        GameObject arrow = Instantiate(Projectile, spawnPosition, Quaternion.Euler(100, 0, 0)) as GameObject;
        arrow.GetComponent<ArrowMovement>().enemyTransform = enemyTransform;
    }
}
