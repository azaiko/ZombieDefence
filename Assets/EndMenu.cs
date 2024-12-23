using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{

    public GameObject endPannel;

    void Update()
    {
        if (CastleAttack.isAlive == false)
        {
            endPannel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Start");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        CastleAttack.isAlive = true;
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
