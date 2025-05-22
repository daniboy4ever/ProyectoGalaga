using System.Collections.Generic;
using UnityEngine;

public class VidaUI : MonoBehaviour
{
    public GameObject vidaIconPrefab;
    public Transform vidaPanel;

    private List<GameObject> iconosVidas = new List<GameObject>();

    public void InicializarVidas(int cantidad)
    {
        foreach (var icono in iconosVidas)  // Limpia íconos anteriores
        {
            Destroy(icono);
        }
        iconosVidas.Clear();

        for (int i = 0; i < cantidad; i++)  // Crea nuevos íconos
        {
            GameObject icono = Instantiate(vidaIconPrefab, vidaPanel);
            iconosVidas.Add(icono);
        }
    }

    public void QuitarVida()
    {
        if (iconosVidas.Count > 0)
        {
            Destroy(iconosVidas[iconosVidas.Count - 1]);
            iconosVidas.RemoveAt(iconosVidas.Count - 1);
        }
    }
}
