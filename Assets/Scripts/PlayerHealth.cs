using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private Animator anim;
    public PlayerManager manager;
   


    public HealthBar healthBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxhealth(maxHealth);
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.Sethealth(currentHealth);


        if (currentHealth <= 0)
        {
            currentHealth = 0;
            TriggerGameOver();
        }
        
    }

    public void TriggerGameOver()
    {
        Debug.Log("Triggering Game Over");
        PlayerManager.isGameOver = true;  
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}


