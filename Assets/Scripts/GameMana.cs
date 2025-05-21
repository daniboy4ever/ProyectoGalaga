using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class GameMana : MonoBehaviour
{

    //Prefabs
    public GameObject abeja;
    public GameObject mariposa;
    public GameObject boss;

    //Velocidades
    private float velocidad = 300f;

    //Contadores
    int abejas, mariposas, bosses;

    //Lista de Enemigos
    private List<GameObject> enemies = new List<GameObject>();

    //Posiciones
    //Ola 1
    private List<Vector2> posisAbejO1 = new List<Vector2>()
    {
    new Vector2(100, 270), new Vector2(130, 270), new Vector2(100, 300), new Vector2(130, 300)
    };

    private List<Vector2> posisMaripO1 = new List<Vector2>()
    {
    new Vector2(100, 330), new Vector2(130, 330), new Vector2(100, 360), new Vector2(130, 360)
    };

    //Ola2
    private List<Vector2> posisBoss = new List<Vector2>()
    {
    new Vector2(70, 390), new Vector2(100, 390), new Vector2(130, 390), new Vector2(160, 390)
    };

    private List<Vector2> posisMaripO2 = new List<Vector2>()
    {
    new Vector2(70, 330), new Vector2(160, 330), new Vector2(70, 360), new Vector2(160, 360)
    };

    //Ola3
    private List<Vector2> posisMaripO3 = new List<Vector2>()
    {
    new Vector2(40, 330), new Vector2(190, 330), new Vector2(40, 360), new Vector2(190, 360)
    };

    //Ola4
    private List<Vector2> posisAbejO4_1 = new List<Vector2>()
    {
    new Vector2(10, 300), new Vector2(40, 300), new Vector2(70, 300), new Vector2(160, 300), new Vector2(190, 300), new Vector2(220, 300)
    };
    private List<Vector2> posisAbejO4_2 = new List<Vector2>()
    {
    new Vector2(10, 270), new Vector2(40, 270), new Vector2(70, 270), new Vector2(160, 270), new Vector2(190, 270), new Vector2(220, 270)
    };
    void Start()
    {
        //x = 120
        //Instanciar Ejercito//
        /*PRIMERA OLA*/

        for (int i = 0; i < 4; i++)
        {
            GameObject abejaTemp = Instantiate(abeja, new Vector2(100, 455), Quaternion.identity);
            Vector2 destino = posisAbejO1[i];

            StartCoroutine(Movimiento(abejaTemp, destino, i));
        }
        for (int i = 0; i < 4; i++)
        {
            GameObject mariposaTemp = Instantiate(mariposa, new Vector2(140, 455), Quaternion.identity);
            Vector2 destino = posisMaripO1[i];

            StartCoroutine(Movimiento(mariposaTemp, destino, i));
        }

        /*SEGUNDA OLA*/
        for (int i = 0; i < 4; i++)
        {
            GameObject bossTemp = Instantiate(boss, new Vector2(-44, 76), Quaternion.identity);
            Vector2 destino = posisBoss[i];

            StartCoroutine(Movimiento2(bossTemp, destino, i));
        }
        
        for (int i = 0; i < 4; i++)
        {
            GameObject mariposaTemp = Instantiate(mariposa, new Vector2(-44, 76), Quaternion.identity);
            Vector2 destino = posisMaripO2[i];

            StartCoroutine(Movimiento2(mariposaTemp, destino, i));
        }

        /*TERCERA OLA*/
        for (int i = 0; i < 4; i++)
        {
            GameObject mariposaTemp = Instantiate(mariposa, new Vector2(271, 76), Quaternion.identity);
            Vector2 destino = posisMaripO3[i];

            StartCoroutine(Movimiento3(mariposaTemp, destino, i));
        }

        /*CUARTA OLA*/
        for (int i = 0; i < 6; i++)
        {
            GameObject abejaTemp = Instantiate(abeja, new Vector2(-44, 76), Quaternion.identity);
            Vector2 destino = posisAbejO4_1[i];

            StartCoroutine(Movimiento4(abejaTemp, destino, i));
        }
        for (int i = 0; i < 6; i++)
        {
            GameObject abejaTemp = Instantiate(abeja, new Vector2(271, 76), Quaternion.identity);
            Vector2 destino = posisAbejO4_2[i];

            StartCoroutine(Movimiento4(abejaTemp, destino, i));
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Movimiento(GameObject enemigo, Vector2 destino, int i)
    {
        yield return new WaitForSeconds(0.5f * i); // Para escalonar la entrada
        while (Vector2.Distance(enemigo.transform.position, destino) > 0.001f)
        {
            enemigo.transform.position = Vector2.MoveTowards(enemigo.transform.position, destino, velocidad * Time.deltaTime);
            yield return null;
        }
    }
    
    private IEnumerator Movimiento2(GameObject enemigo, Vector2 destino, int i)
    {
        yield return new WaitForSeconds(1.5f + (0.3f * i));
        while (Vector2.Distance(enemigo.transform.position, destino) > 0.001f)
        {
            enemigo.transform.position = Vector2.MoveTowards(enemigo.transform.position, destino, velocidad * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator Movimiento3(GameObject enemigo, Vector2 destino, int i)
    {
        yield return new WaitForSeconds(2.5f + (0.3f * i));
        while (Vector2.Distance(enemigo.transform.position, destino) > 0.001f)
        {
            enemigo.transform.position = Vector2.MoveTowards(enemigo.transform.position, destino, velocidad * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator Movimiento4(GameObject enemigo, Vector2 destino, int i)
    {
        yield return new WaitForSeconds(3.5f + (0.3f * i));
        while (Vector2.Distance(enemigo.transform.position, destino) > 0.001f)
        {
            enemigo.transform.position = Vector2.MoveTowards(enemigo.transform.position, destino, velocidad * Time.deltaTime);
            yield return null;
        }
    }

}
