using UnityEngine;
//using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour
{
 
    public void LoadScene(string level)
    {
        //Map, Map2 Map3
        SceneManager.LoadScene("level1");

    }
}