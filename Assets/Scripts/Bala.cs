using UnityEngine;

public class Bala : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocidad;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(0, velocidad);
        
    }
}
