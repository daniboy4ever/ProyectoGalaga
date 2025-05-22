using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Si la bala choca con un enemigo
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            Destroy(collision.gameObject); // Destruye al enemigo
            Destroy(gameObject); // Destruye la bala
        }
    }
}
