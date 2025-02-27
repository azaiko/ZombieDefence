using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text healthText;

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
        
    }

    public void UpdateHealth(int health)
    {
        healthText.text = "Health: " + health;
    }
}
