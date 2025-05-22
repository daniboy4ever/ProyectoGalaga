using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float velocidad = 5f;
    private Vector2 movement;

    //Delimitar borde
    public float xMin = -8f;
    public float xMax = 8f;
    public float yMin = -4.5f;
    public float yMax = 4.5f;

    void Update()
    {
        //Moviemiento del jugador
        movement.x = Input.GetAxisRaw("Horizontal");
        transform.Translate(movement * velocidad * Time.deltaTime);

        //Bordes
        float clampedX = Mathf.Clamp(transform.position.x, xMin, xMax);
        transform.position = new Vector2(clampedX, transform.position.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            Debug.Log("¡La nave ha sido destruida!");
            Destroy(gameObject);
            
            FindObjectOfType<PlayerLifeManager>().JugadorMuerto();
            Destroy(gameObject); 
        }
    }

    
}

/*using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float velocidad = 5f;

    private Vector2 movement;

    private Rigidbody rb;

    //Delimitar borde
    public float xMin = -8f;
    public float xMax = 8f;
    public float yMin = -4.5f;
    public float yMax = 4.5f;


    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Moviemiento del jugador
        movement.x = Input.GetAxisRaw("Horizontal");
        transform.Translate(movement * velocidad * Time.deltaTime);

        //Bordes
        float clampedX = Mathf.Clamp(transform.position.x, xMin, xMax);//Mathf.Clamp, que es una función que limita un valor dentro de un rango.
        transform.position = new Vector2(clampedX, transform.position.y);
    }

 
}*/

