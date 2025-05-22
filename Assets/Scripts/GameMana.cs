using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMana : MonoBehaviour
{
    public GameObject abeja;
    public GameObject mariposa;
    public GameObject boss;

    private float velocidad = 300f;

    private List<Vector2> posicionesIniciales = new List<Vector2>();
    private List<Vector2> posicionesEntrada = new List<Vector2>();
    private List<GameObject> enemigos = new List<GameObject>();

    void Start()
    {
        // Ola 1 - Abejas (entran desde arriba centro)
        posicionesIniciales.AddRange(new List<Vector2>() {
            new Vector2(100, 270), new Vector2(130, 270),
            new Vector2(100, 300), new Vector2(130, 300)
        });
        posicionesEntrada.AddRange(new List<Vector2>() {
            new Vector2(100, 455), new Vector2(100, 455),
            new Vector2(100, 455), new Vector2(100, 455)
        });

        // Ola 1 - Mariposas (entran desde arriba derecha)
        posicionesIniciales.AddRange(new List<Vector2>() {
            new Vector2(100, 330), new Vector2(130, 330),
            new Vector2(100, 360), new Vector2(130, 360)
        });
        posicionesEntrada.AddRange(new List<Vector2>() {
            new Vector2(140, 455), new Vector2(140, 455),
            new Vector2(140, 455), new Vector2(140, 455)
        });

        // Ola 2 - Bosses (entran desde izquierda)
        posicionesIniciales.AddRange(new List<Vector2>() {
            new Vector2(70, 390), new Vector2(100, 390),
            new Vector2(130, 390), new Vector2(160, 390)
        });
        posicionesEntrada.AddRange(new List<Vector2>() {
            new Vector2(-44, 76), new Vector2(-44, 76),
            new Vector2(-44, 76), new Vector2(-44, 76)
        });

        // Ola 2 - Mariposas (izquierda también)
        posicionesIniciales.AddRange(new List<Vector2>() {
            new Vector2(70, 330), new Vector2(160, 330),
            new Vector2(70, 360), new Vector2(160, 360)
        });
        posicionesEntrada.AddRange(new List<Vector2>() {
            new Vector2(-44, 76), new Vector2(-44, 76),
            new Vector2(-44, 76), new Vector2(-44, 76)
        });

        // Ola 3 - Mariposas (derecha)
        posicionesIniciales.AddRange(new List<Vector2>() {
            new Vector2(40, 330), new Vector2(190, 330),
            new Vector2(40, 360), new Vector2(190, 360)
        });
        posicionesEntrada.AddRange(new List<Vector2>() {
            new Vector2(271, 76), new Vector2(271, 76),
            new Vector2(271, 76), new Vector2(271, 76)
        });

        // Ola 4 - Abejas (mitad izquierda)
        posicionesIniciales.AddRange(new List<Vector2>() {
            new Vector2(10, 300), new Vector2(40, 300), new Vector2(70, 300),
            new Vector2(160, 300), new Vector2(190, 300), new Vector2(220, 300),
            new Vector2(10, 270), new Vector2(40, 270), new Vector2(70, 270),
            new Vector2(160, 270), new Vector2(190, 270), new Vector2(220, 270)
        });
        posicionesEntrada.AddRange(new List<Vector2>() {
            // los primeros 6 desde izquierda
            new Vector2(-44, 76), new Vector2(-44, 76), new Vector2(-44, 76),
            new Vector2(-44, 76), new Vector2(-44, 76), new Vector2(-44, 76),
            // los siguientes 6 desde derecha
            new Vector2(271, 76), new Vector2(271, 76), new Vector2(271, 76),
            new Vector2(271, 76), new Vector2(271, 76), new Vector2(271, 76)
        });

        StartCoroutine(FormarYAtacar());
    }

    IEnumerator FormarYAtacar()
    {
        for (int i = 0; i < posicionesIniciales.Count; i++)
        {
            Vector2 destino = posicionesIniciales[i];
            Vector2 entrada = posicionesEntrada[i];
            GameObject prefab;

            if (i < 4) prefab = abeja; // Ola 1 Abejas
            else if (i < 8) prefab = mariposa; // Ola 1 Mariposas
            else if (i < 12) prefab = boss; // Ola 2 Bosses
            else if (i < 16) prefab = mariposa; // Ola 2 Mariposas
            else if (i < 20) prefab = mariposa; // Ola 3 Mariposas
            else prefab = abeja; // Ola 4 Abejas

            GameObject enemigo = Instantiate(prefab, entrada, Quaternion.identity);
            enemigos.Add(enemigo);
            StartCoroutine(MoverAlInicio(enemigo, destino));
        }

        yield return new WaitForSeconds(3f);

        while (true)
        {
            if (enemigos.Count > 0)
            {
                int index = Random.Range(0, enemigos.Count);
                GameObject atacante = enemigos[index];
                StartCoroutine(DiveAttack(atacante, posicionesIniciales[index]));
            }

            yield return new WaitForSeconds(2f);
        }
    }
IEnumerator MoverAlInicio(GameObject enemigo, Vector2 destino)
{
    Vector2 inicio = enemigo.transform.position;
    float duracion = 2f;
    float tiempo = 0f;

    while (tiempo < duracion)
    {
        float t = tiempo / duracion;

        // Movimiento lineal vertical hacia el destino
        float newY = Mathf.Lerp(inicio.y, destino.y, t);

        // Movimiento en zig-zag (horizontal)
        float waveAmplitude = 20f; // qué tanto se mueve a los lados
        float waveFrequency = 4f;  // cuántas oscilaciones hace
        float newX = Mathf.Lerp(inicio.x, destino.x, t) + Mathf.Sin(t * Mathf.PI * waveFrequency) * waveAmplitude;

        enemigo.transform.position = new Vector2(newX, newY);

        // Rotación sobre sí mismo
        enemigo.transform.Rotate(0f, 0f, 720f * Time.deltaTime);

        tiempo += Time.deltaTime;
        yield return null;
    }

    enemigo.transform.position = destino;
    enemigo.transform.rotation = Quaternion.identity; // Reinicia rotación
}


    IEnumerator DiveAttack(GameObject enemigo, Vector2 posicionInicial)
    {
        Vector2 abajo = new Vector2(enemigo.transform.position.x, -100f);

        while (Vector2.Distance(enemigo.transform.position, abajo) > 0.1f)
        {
            enemigo.transform.position = Vector2.MoveTowards(enemigo.transform.position, abajo, velocidad * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);
        enemigo.transform.position = new Vector2(posicionInicial.x, 600f);

        while (Vector2.Distance(enemigo.transform.position, posicionInicial) > 0.1f)
        {
            enemigo.transform.position = Vector2.MoveTowards(enemigo.transform.position, posicionInicial, velocidad * Time.deltaTime);
            yield return null;
        }
    }
}
