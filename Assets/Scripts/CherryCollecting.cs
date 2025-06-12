using UnityEngine;

public class CherryCollecting : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            PlayerManager.noOfCherry = PlayerManager.noOfCherry + 1;
            Destroy(gameObject);
        }
    }
}
