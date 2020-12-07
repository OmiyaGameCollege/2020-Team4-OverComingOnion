using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Game2 : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("NextStage");
    }
}