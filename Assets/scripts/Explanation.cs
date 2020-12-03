using UnityEngine;
using UnityEngine.SceneManagement;  //「2」

public class Explanation : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Game");    //「3」
        }

    }
}