using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiveAttackManager : MonoBehaviour
{
    public List<GameObject> enemigos = new List<GameObject>();
    public Transform playerTransform;
    public float diveSpeed = 250f;
    public float returnSpeed = 300f;

    private Dictionary<GameObject, Vector2> posicionesIniciales = new Dictionary<GameObject, Vector2>();

    void Start()
    {
        foreach (GameObject enemigo in enemigos)
        {
            if (enemigo != null)
                posicionesIniciales[enemigo] = enemigo.transform.position;
        }

        StartCoroutine(IniciarAtaques());
    }

    IEnumerator IniciarAtaques()
    {
        yield return new WaitForSeconds(3f); // Espera 3 segundos antes de comenzar

        while (true)
        {
            GameObject enemigo = enemigos[Random.Range(0, enemigos.Count)];
            if (enemigo != null)
                StartCoroutine(HacerPicada(enemigo));

            yield return new WaitForSeconds(2f); // Ataca uno cada 2 segundos
        }
    }

    IEnumerator HacerPicada(GameObject enemigo)
    {
        if (enemigo == null || playerTransform == null)
            yield break;

        Vector2 destino = playerTransform.position;

        // Baja hacia el jugador
        while (enemigo != null && Vector2.Distance(enemigo.transform.position, destino) > 0.1f)
        {
            enemigo.transform.position = Vector2.MoveTowards(enemigo.transform.position, destino, diveSpeed * Time.deltaTime);
            yield return null;
        }

        // Si no colisionó con la nave, sigue bajando hasta salir de pantalla
        if (enemigo != null)
        {
            Vector2 fueraDePantalla = new Vector2(enemigo.transform.position.x, -100f);
            while (enemigo.transform.position.y > fueraDePantalla.y)
            {
                enemigo.transform.position = Vector2.MoveTowards(enemigo.transform.position, fueraDePantalla, diveSpeed * Time.deltaTime);
                yield return null;
            }

            // Reaparece arriba
            Vector2 arribaPantalla = new Vector2(posicionesIniciales[enemigo].x, 500f);
            enemigo.transform.position = arribaPantalla;

            // Regresa a su posición inicial
            while (Vector2.Distance(enemigo.transform.position, posicionesIniciales[enemigo]) > 0.1f)
            {
                enemigo.transform.position = Vector2.MoveTowards(enemigo.transform.position, posicionesIniciales[enemigo], returnSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }
}
