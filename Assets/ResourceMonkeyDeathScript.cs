using UnityEngine;
using System.Collections;

public class ResourceMonkeyDeathScript : MonoBehaviour {


    public HealthComponent health;
    public PlayerScript player;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnDestroyed()
    {
        player.NotifyMonkeyKill();
        player.CurrentLumber += 1;
        Destroy(gameObject);
    }
}
