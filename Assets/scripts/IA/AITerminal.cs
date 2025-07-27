using UnityEngine;
using TMPro;

public class AITerminal : MonoBehaviour
{
    public Inventory playerInventory;
    [Header("Zones à revitaliser")]
    public GameObject[] zonesARevitaliser; // Liste des zones à activer
    [Header("UI")]
    public TextMeshProUGUI messageUI;

    [Header("Ressources requises")]
    public int besoinEau = 2;
    public int besoinGraines = 2;
    public int besoinFertilisant = 1;

    public GameObject iaPictogramme; // Référence au pictogramme IA

    private bool joueurDansZone = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (joueurDansZone && Input.GetKeyDown(KeyCode.E))
        {
            ActiverIA();
        }
    }

    void ActiverIA()
    {
        if (playerInventory == null) return;

        int eau = playerInventory.GetWaterDropCount();
        int graines = playerInventory.GetSeedCount();
        int fertil = playerInventory.GetFertilizerCount();

        Debug.Log($"[DEBUG] Inventaire : Eau={eau}, Graines={graines}, Fertilisant={fertil}");

        if (eau >= besoinEau && graines >= besoinGraines && fertil >= besoinFertilisant)
        {
            foreach (GameObject zone in zonesARevitaliser)
            {
                if (zone != null)
                    zone.SetActive(true);
            }

            if (messageUI != null)
                messageUI.text = "[IA LOG] Ressources suffisantes.\nRevitalisation en cours... \n" +
                "[IA LOG] Dirige-toi vers la porte pour passer au niveau suivant";

            if (iaPictogramme != null)
                iaPictogramme.SetActive(true); // Montre le pictogramme IA

            // Objctif atteint
            CountdownTimer timer = FindFirstObjectByType<CountdownTimer>();
            if (timer != null)
                timer.ValiderObjectif();
        }
        else
        {
            messageUI.text = "[IA LOG] Ressources insuffisantes.\nAnalyse en attente...";
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            joueurDansZone = true;
            if (messageUI != null)
                messageUI.text = "[IA LOG] Appuyer sur E pour interagir.";
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            joueurDansZone = false;
            if (messageUI != null)
                messageUI.text = "";
        }
    }
}