using UnityEngine;

public class Restart : MonoBehaviour
{
   public void LoadCurrentScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;
    }
}
