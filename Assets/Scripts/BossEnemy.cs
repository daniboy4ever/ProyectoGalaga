using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public int vidas = 2;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            vidas--;

            Debug.Log("Boss recibió un disparo. Vidas restantes: " + vidas);

            Destroy(other.gameObject); // Destruye la bala

            if (vidas <= 0)
            {
                // Aquí puedes poner una animación de explosión si quieres
                Debug.Log("¡Boss destruido!");
                Destroy(gameObject); // Destruye al boss
            }
        }
    }
}

