using UnityEngine;

public class Disparos : MonoBehaviour
{
    public Transform puntoBala;
    public GameObject bala;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bala, puntoBala.position, Quaternion.identity);
        }
        
    }
}
