using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    [Header("Game Settings")]
    public int initialScore = 50;
    public int playerHealth = 1000;
    public int waveNumber = 1;
    public int killedZombies = 0;
    private bool gameOver = false;

    [Header("Game State")]
    public int currentScore; 
    public int currentHealth;

    [Header("References")]
    public UIController uiController;
     public TurretManager turretManager;
    public static GameManager instance { get; private set; }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
        if (uiController == null)
        {
            uiController = FindObjectOfType<UIController>();
        }
        
        currentScore = initialScore;
        currentHealth = playerHealth;
        
        uiController.UpdateScore(currentScore);
        uiController.UpdateHealth(currentHealth);
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        uiController.UpdateScore(currentScore);
        killedZombies += 1;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        uiController.UpdateHealth(currentHealth);
        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    public void UpgradeTurret(GameObject turret)
    {
        turretManager.UpgradeTurret(turret);
    }

    public void GameOver()
    {
        if (gameOver) return;
        gameOver = true;
        Debug.Log("Game Over!");
        if (FindObjectOfType<CastleAttack>() != null)
        {
            FindObjectOfType<CastleAttack>().Die();
        }
    }
    
}
