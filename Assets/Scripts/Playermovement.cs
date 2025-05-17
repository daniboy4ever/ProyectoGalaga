using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float velocidad = 5f;

    
    public float xMin = -8f;
    public float xMax = 8f;
    public float yMin = -4.5f;
    public float yMax = 4.5f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, moveY, 0f) * velocidad * Time.deltaTime;
        transform.position += movement;

    
        float clampedX = Mathf.Clamp(transform.position.x, xMin, xMax);//Mathf.Clamp, que es una función que limita un valor dentro de un rango.


        float clampedY = Mathf.Clamp(transform.position.y, yMin, yMax);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}


/*using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float velocidad = 5f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, moveY, 0f);
        transform.position += movement * velocidad * Time.deltaTime;
    }
}*/

