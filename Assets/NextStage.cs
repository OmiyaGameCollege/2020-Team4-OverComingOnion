using UnityEngine;
using UnityEngine.SceneManagement;  //「2」

public class NextStage : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("BOSS");   
        }
    }
}