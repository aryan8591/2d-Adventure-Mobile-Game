using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private int damage;
    public Transform pointa;
    public Transform pointb;

    public float movespeed = 2f;

    private Vector3 nextposition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

    void Start()
    {
        nextposition = pointa.position;
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextposition, movespeed * Time.deltaTime);

        if (transform.position == nextposition)
        {
            if (nextposition == pointa.position)
            {
                nextposition = pointb.position;
                // Turn right
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else
            {
                nextposition = pointa.position;
                // Turn left
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
    }
}
