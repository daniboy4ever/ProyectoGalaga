using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocity = 10f;

    private Vector2 movement;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        transform.Translate(movement *  velocity * Time.deltaTime);
    }
}
