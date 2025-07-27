using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelDisplay : MonoBehaviour
{
    public TextMeshProUGUI levelText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string nomScene = SceneManager.GetActiveScene().name;

        // Personnaliser le texte selon la scène
        string texteNiveau = "";

        switch (nomScene)
        {
            case "Level1":
                texteNiveau = "Niveau 1";
                break;
            case "Level2":
                texteNiveau = "Niveau 2";
                break;
            case "Level3":
                texteNiveau = "Niveau 3";
                break;
            default:
                texteNiveau = "Niveau inconnu";
                break;
        }

        if (levelText != null)
            levelText.text = $"{texteNiveau}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
