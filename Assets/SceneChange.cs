using UnityEngine;
using UnityEngine.SceneManagement;  

public class SceneChange: MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Debug.Log("hahaha");

            SceneManager.LoadScene("Game");

        }
    }
}