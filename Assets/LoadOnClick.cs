using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour
{
    void Start() {
        Debug.Log("akbdkajdb");
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene("testscene");
    }
}