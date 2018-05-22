using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}