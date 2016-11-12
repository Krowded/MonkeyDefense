using UnityEngine;
using System.Collections;

public class CreateArrows : MonoBehaviour {

    public float Range;
    public float shootDelay;
    public GameObject Projectile;
    private float lastTick;

	// Use this for initialization
	void Start () {
        lastTick = Time.time;
	
	}

    // Update is called once per frame
    void Update() {
        if (Time.time > lastTick + shootDelay)
        {
            for (int indexia = 0; indexia < gameObject.transform.parent.childCount; indexia++)
            {
                Transform enemyTransform = gameObject.transform.parent.GetChild(indexia);
                if (Vector3.Distance(enemyTransform.position, gameObject.transform.position) < Range)
                {
                    Shoot(enemyTransform);
                    //break;
                }
            }
            lastTick = Time.time;
        }
    }
    void Shoot(Transform enemyTransform)
    {
        //Vector3 direction = (enemyTransform.position - gameObject.transform.position);
        GameObject arrow = Instantiate(Projectile, gameObject.transform.position, Quaternion.Euler(100, 0, 0)) as GameObject;
        arrow.GetComponent<ArrowMovement>().enemyTransform = enemyTransform;
    }
    //Vector3.Angle(gameObject.transform.position, direction)
}
