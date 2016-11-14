using UnityEngine;
using UnityEngine.UI;

public class LevelView : MonoBehaviour {

    private Text text;
    public MonkeyMaker monkeyMaker;
    
    // Use this for initialization
    void Start ()
    {
        text = transform.FindChild("Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update ()
    {
        text.text = "Wave\n\n" + monkeyMaker.DifficultyLevel;
    }
}
