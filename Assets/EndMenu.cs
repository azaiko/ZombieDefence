using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndMenu : MonoBehaviour
{

    public GameObject endPannel;
    [SerializeField] private TMP_Text GameOverText;

    void Update()
    {
        if (CastleAttack.isAlive == false)
        {
            endPannel.SetActive(true);
            Time.timeScale = 0f;
            GameOverText.text = $"Game Over! \n You killed: {GameManager.instance.killedZombies} zombies! \n You died at {GameManager.instance.waveNumber} wave!";
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Start");
    }

    public void Restart()
    {
        CastleAttack.isAlive = true;
        Destroy (GameManager.instance?.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
