using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject panelCreditos;
    public GameObject panelConfiguracion;
    public GameObject panelPausa;
    public GameObject panelInstrucciones;

    void Start()
    {
        Time.timeScale = 0f;
        panelInstrucciones.SetActive(true);
    }

    // JUGAR

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    // MENU

    public void GoMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Mainmenu");
    }

    // SALIR

    public void QuitGame()
    {
        Application.Quit();
    }

    // CREDITOS

    public void AbrirCreditos()
    {
        panelCreditos.SetActive(true);
    }

    public void CerrarCreditos()
    {
        panelCreditos.SetActive(false);
    }

    // CONFIGURACION

    public void AbrirConfiguracion()
    {
        panelConfiguracion.SetActive(true);
    }

    public void CerrarConfiguracion()
    {
        panelConfiguracion.SetActive(false);
    }

    // PAUSA

    public void PausarJuego()
    {
        Time.timeScale = 0f;
        panelPausa.SetActive(true);
    }

    public void ReanudarJuego()
    {
        Time.timeScale = 1f;
        panelPausa.SetActive(false);
    }

    // INSTRUCCIONES

    public void CerrarInstrucciones()
    {
        panelInstrucciones.SetActive(false);
        Time.timeScale = 1f;
    }
}