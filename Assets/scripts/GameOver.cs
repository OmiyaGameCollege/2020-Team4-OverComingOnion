using UnityEngine;
using UnityEngine.SceneManagement;  //「2」

public class GameOver : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Title");    //「3」
        }

    }
}