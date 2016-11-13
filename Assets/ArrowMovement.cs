using UnityEngine;
using System.Collections;

public class ArrowMovement : MonoBehaviour
{

    private Transform body;
    public float speed;
    public Transform enemyTransform;
    public float proximity;
    public int killPower;

    // Use this for initialization
    void Start()
    {
        body = gameObject.transform;

    }   

    // Update is called once per frame
    void Update()
    {
		if (!enemyTransform) //If target stops existing, destroy arrow and exit
		{
			Destroy(gameObject);
			return;
		}

        Vector3 direction = (enemyTransform.position - body.position);

        body.position += direction.normalized * speed * Time.deltaTime;
        Quaternion rotation = Quaternion.LookRotation(direction);
        rotation = Quaternion.Slerp(transform.rotation, rotation, 1);
        transform.rotation = rotation * transform.rotation;
        //Vector3.Slerp(body.forward, direction.normalized, 1);
        if (direction.magnitude < proximity)
        {
            HealthComponent enemyHealth = enemyTransform.gameObject.GetComponent<HealthComponent>();
            if (enemyHealth)
            {
                enemyHealth.Damage(killPower);
            }
            Destroy(gameObject);
        }
    }
}
