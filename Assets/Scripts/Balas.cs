using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balas : MonoBehaviour
{
    public float velocidad = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0f, moveY, 0f);
        transform.position += movement * velocidad * Time.deltaTime;
    }
}
