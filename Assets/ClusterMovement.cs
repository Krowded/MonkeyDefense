using UnityEngine;
using System.Collections;

public class ClusterMovement : MonoBehaviour {

    private Transform body;

    public float speed;
    public float rotationSpeed;
    public Transform enemyTransform;
    public GameObject enemyList;
    public float proximity;
    public float splashRadius;
    public int killPower;

    // Use this for initialization
    void Start () {
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
        rotation = Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        transform.rotation = rotation * transform.rotation;
        if (direction.magnitude < proximity)
        {
            for (int i = 0; i < enemyList.transform.childCount; i++)
            {
                Transform targetTransform = enemyList.transform.GetChild(i);
                if (Vector3.Distance(targetTransform.position, gameObject.transform.position) < splashRadius)
                {
                    HealthComponent targetHealth = targetTransform.gameObject.GetComponent<HealthComponent>();
                    if (targetHealth)
                    {
                        targetHealth.Damage(killPower);
                    }
                }
            }
            Destroy(gameObject);
        }
    }
}
