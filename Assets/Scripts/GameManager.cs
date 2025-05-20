using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    //Prefabs
    public GameObject abeja;
    public GameObject mariposa;
    public GameObject boss;

    //Velocidades
    public float velocidad = 300f;

    //Lista de Enemigos
    private List<GameObject> enemigos = new List<GameObject>();

    public List<Vector2> posiciones = new List<Vector2>();

    public List<Vector2> posicionesFormacion = new List<Vector2>()
    {
    new Vector2(120, 298), new Vector2(-1, 3), new Vector2(0, 3),
    new Vector2(1, 3), new Vector2(2, 3), new Vector2(3, 3)
    };



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        for (int i = 0; i < 6; i++)
        {
            GameObject enemigo = Instantiate(abeja, new Vector2(0, 455), Quaternion.identity); //Quaternion (X, Y, Z, W)
            //x = 120
            enemigos.Add(enemigo); //añadir enemigos
                                   //StartCoroutine(Ejercito(enemigos, posi, i));
            Vector2 destino = posicionesFormacion[i];
            StartCoroutine(Movimiento(enemigo, destino, i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(Ejercito(enemigos));
    }

    private IEnumerator Movimiento(GameObject enemigo, Vector2 destino, int i)
    {
        yield return new WaitForSeconds(0.5f * i); // Para escalonar la entrada
        while (Vector2.Distance(enemigo.transform.position, destino) > 0.001f)
        {
            enemigo.transform.position = Vector2.MoveTowards(enemigo.transform.position, destino,velocidad * Time.deltaTime);
            yield return null;
        }
    }


}
