using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnPoint;

    public int vidasMaximas = 3;
    private int vidasRestantes;

    private GameObject jugadorActual;

    //UI
    private VidaUI vidaUI;

    void Start()
    {
        vidasRestantes = vidasMaximas;
        vidaUI = FindObjectOfType<VidaUI>();
        vidaUI.InicializarVidas(vidasMaximas);

        vidasRestantes = vidasMaximas;
        InstanciarJugador();
    }

    public void JugadorMuerto()
    {
        vidasRestantes--;
        vidaUI.QuitarVida();

        if (vidasRestantes > 0)
        {
            Invoke(nameof(InstanciarJugador), 2f);
        }
        else
        {
            VolverAlMenu();
        }
    }

    void InstanciarJugador()
    {
        jugadorActual = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
    }

    void VolverAlMenu()
    {
        Debug.Log("Menu");
        //SceneManager.LoadScene("Menu");
    }
}
