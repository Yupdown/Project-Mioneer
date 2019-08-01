using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class MainDelegate : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("MioneerGame");
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
