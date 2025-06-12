using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int damageOnTouch = 10; // Damage from enemy
    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        if (playerHealth == null)
        {
            Debug.LogError("PlayerHealth script not found on Player!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.CompareTag("deathzone"))
        {
            Debug.Log("Touched Deathzone!");

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(playerHealth.currentHealth); 
            }

            gameObject.SetActive(false); 
        }

       
        else if (collision.collider.CompareTag("Enemy"))
        {
            Debug.Log("Touched Enemy - taking damage!");

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageOnTouch);
            }
        }
    }
}
