using UnityEngine;

public class FallDamage : MonoBehaviour
{
    public float fallHeightThreshold = 5f; 
    public int fallDamageAmount = 15;

    private float startY;
    private bool isFalling = false;

    private Rigidbody2D rb;
    private PlayerHealth playerHealth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        
        if (rb.linearVelocityY < 0 && !isFalling)
        {
            isFalling = true;
            startY = transform.position.y; 
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isFalling)
        {
            float fallDistance = startY - transform.position.y;

            if (fallDistance >= fallHeightThreshold)
            {
                playerHealth.TakeDamage(fallDamageAmount);
            }

            isFalling = false;
        }
    }
}
