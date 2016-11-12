using UnityEngine;
using System.Collections;

public class HealthComponent : MonoBehaviour{

    public int maxLife;
    public int life;
    public void Damage(int damage)
    {
        life -= damage;
        if (life <= 0)
            SendMessage("OnDestroyed");
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

