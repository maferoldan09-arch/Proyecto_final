using UnityEngine;

public class Menu : MonoBehaviour
{
    public void LoadMenuScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Mainmenu");
        Time.timeScale = 1f;
    }
}
