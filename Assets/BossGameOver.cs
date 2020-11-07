using UnityEngine;
using UnityEngine.SceneManagement;  //「2」

public class BossGameOver : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Title");    //「3」
        }

    }
}