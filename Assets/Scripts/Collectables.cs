using UnityEngine;

public class Collectables : MonoBehaviour
{
    // Store the number of collected items
    public int coins = 0;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

        // Use CompareTag (faster and safer than == "Coin")
        if (collision.gameObject.CompareTag("Coin"))
        {
            coins++;

            // Destroy the collected coin
            Destroy(collision.gameObject);
        }
    }
}