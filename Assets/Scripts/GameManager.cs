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
    private List<GameObject> enemigosO1 = new List<GameObject>();
    private List<GameObject> enemigosO2 = new List<GameObject>();
    private List<GameObject> enemigosO3 = new List<GameObject>();
    private List<GameObject> enemigosO4 = new List<GameObject>();



    public List<Vector2> posisAbej = new List<Vector2>()
    {
    new Vector2(100, 275), new Vector2(125, 275), new Vector2(100, 300), new Vector2(125, 300)
    };

    public List<Vector2> posisMarip = new List<Vector2>()
    {
    new Vector2(100, 320), new Vector2(125, 320), new Vector2(100, 340), new Vector2(125, 340)
    };

    public List<List<Vector2>> posicionesO1 = new List<List<Vector2>>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicionesO1.Add(posisAbej);
        posicionesO1.Add(posisMarip);

        //Instanciar ejercito

        /*Primera ola*/
        for (int i = 0; i < 4; i++)
        {
            GameObject abejaTemp = Instantiate(abeja, new Vector2(100, 455), Quaternion.identity); 
            enemigosO1.Add(abejaTemp); //añadir abeja
            Vector2 destino = posisAbej[i];

            //StartCoroutine(Movimiento(abejaTemp, destino, i));
        }
        for (int i = 0; i < 4; i++)
        {
            GameObject mariposaTemp = Instantiate(mariposa, new Vector2(140, 455), Quaternion.identity);
            enemigosO1.Add(mariposaTemp); //añadir mariposa
            Vector2 destino = posisMarip[i];

            //StartCoroutine(Movimiento(mariposaTemp, destino, i));
        }



        //StartCoroutine(MovementManager());



        //Movimiento/Acomodo de ejercito
        //StartCoroutine(Movimiento(enemigosO1, posicionesO1,5));

        //for (int i = 0; i < 4; i++)
        //{
        //    GameObject abejaTemp = Instantiate(abeja, new Vector2(100, 455), Quaternion.identity); //Quaternion (X, Y, Z, W)

        //    //x = 120
        //    enemigos.Add(abejaTemp); //añadir abeja
        //    Vector2 destino = posisAbej[i];

        //    StartCoroutine(Movimiento(abejaTemp, destino, i));
        //}
        //for (int i = 0; i < 4; i++)
        //{
        //    GameObject mariposaTemp = Instantiate(mariposa, new Vector2(140, 455), Quaternion.identity); //Quaternion (X, Y, Z, W)

        //    //x = 120
        //    enemigos.Add(mariposaTemp); //añadir mariposa
        //    Vector2 destino = posisMarip[i];

        //    StartCoroutine(Movimiento(mariposaTemp, destino, i));
        //}



    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(Ejercito(enemigos));
    }

    private IEnumerator MovementManager(List<GameObject> enemigos)
    {
        //StartCoroutine(Movimiento(enemigos));
        yield return new WaitForSeconds(20f);
        yield return new WaitForSeconds(20f);
        yield return new WaitForSeconds(20f);
    }



    //private IEnumerator Movimiento(List<GameObject> enemigos)   //, List<List<Vector2>>,int time
    //{
    //    int contAb, contMar, contBos;

    //    yield return new WaitForSeconds(0.5f * time); // Para escalonar la entrada

    //    for (int i = 0; i < enemigos.Count; i++)
    //    {
    //        if (enemigos[i])
    //        while (Vector2.Distance(enemigosO1[i].transform.position, destino) > 0.001f)
    //        {
    //            enemigosO1[i].transform.position = Vector2.MoveTowards(enemigoO1[i].transform.position, destino, velocidad * Time.deltaTime);
    //            yield return null;
    //        }
    //    }
    //}


}
