using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class AguaColision : MonoBehaviour
{
    public TextMeshProUGUI notificationText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(notificationText != null)
            {
                notificationText.text =
                    "Caíste al agua";
            }

            Debug.Log("Game Over - Agua");

            Invoke(
                "ReiniciarEscena",
                2f
            );
        }
    }

    void ReiniciarEscena()
    {
        SceneManager.LoadScene(
            SceneManager
            .GetActiveScene()
            .name
        );
    }
}