using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}