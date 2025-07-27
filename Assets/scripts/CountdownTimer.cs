using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public float tempsRestant = 60f; // Durée totale du timer
    public TextMeshProUGUI timerUI;
    public GameObject gameOverUI;

    private bool timerActif = true;
    private bool objectifAtteint = false;

    void Update()
    {
        if (!timerActif || objectifAtteint) return;

        tempsRestant -= Time.deltaTime;

        if (timerUI != null)
            timerUI.text = "⏱ Temps : " + Mathf.CeilToInt(tempsRestant).ToString() + "s";

        if (tempsRestant <= 0)
        {
            FinDuTemps();
        }
    }

    void FinDuTemps()
    {
        timerActif = false;

        if (!objectifAtteint)
        {
            Debug.Log("Temps écoulé !");
            if (gameOverUI != null)
                gameOverUI.SetActive(true);
            else
                SceneManager.LoadScene("GameOver"); // En option
        }
    }

    public void ValiderObjectif()
    {
        objectifAtteint = true;
    }
}
