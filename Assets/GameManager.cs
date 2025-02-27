using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    [Header("Game Settings")]
    public int initialScore = 50; // Начальное количество очков
    public int playerHealth = 1000; // Здоровье игрока
    public int waveNumber = 1; // Номер текущей волны

    [Header("Game State")]
    public int currentScore; 
    public int currentHealth;

     [Header("References")]
     public UIController uiController; // Ссылка на UIController
     public TurretManager turretManager; // Ссылка на менеджер турелей
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
        currentScore = initialScore;
        currentHealth = playerHealth;
        
        uiController.UpdateScore(currentScore);
        uiController.UpdateHealth(currentHealth);
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        uiController.UpdateScore(currentScore);
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
        Debug.Log("Game Over!");
        if (FindObjectOfType<CastleAttack>() != null)
        {
            FindObjectOfType<CastleAttack>().Die();
        }
    }
    
}
