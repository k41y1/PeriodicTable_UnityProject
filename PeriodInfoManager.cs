using UnityEngine;
using TMPro;

public class PeriodInfoManager : MonoBehaviour
{
    public static PeriodInfoManager Instance;

    [Header("UI References")]
    public GameObject trendDisplayPanel;            // Panel GameObject
    public TextMeshProUGUI textComponent;           // Text inside panel

    [Header("Panel Positioning")]
    [SerializeField] private Vector3 defaultPanelPosition = new Vector3(6.5f, 2f, 4f); // Now slightly higher beside the table

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        if (trendDisplayPanel != null)
        {
            trendDisplayPanel.SetActive(false);
        }
        else
        {
            Debug.LogWarning("⚠ trendDisplayPanel reference is missing in PeriodInfoManager!");
        }
    }

    /// <summary>
    /// Show and move the panel to a fixed position with data for the selected period.
    /// </summary>
    public void MoveAndShow(int periodNumber, Vector3 newPosition)
    {
        Debug.Log($"Showing panel for period {periodNumber} at position {defaultPanelPosition}");

        if (trendDisplayPanel == null || textComponent == null)
        {
            Debug.LogError("❌ Missing references on PeriodInfoManager.");
            return;
        }

        // Position the panel beside the periodic table at a fixed height
        trendDisplayPanel.transform.position = defaultPanelPosition;

        // Show the panel
        trendDisplayPanel.SetActive(true);

        // Display the information for the selected period
        textComponent.text = GetTrendInfo(periodNumber);
    }

    private string GetTrendInfo(int period)
    {
        switch (period)
        {
            case 1:
                return "Period 1 Trends (H, He):\n\n- Atomic Radius: Decreases\n- Ionization Energy: Increases\n- Electronegativity: Increases\n- Metallic Character: Decreases";
            case 2:
                return "Period 2 Trends (Li to Ne):\n\n- Atomic Radius: Decreases\n- Ionization Energy: Increases\n- Electronegativity: Increases\n- Metallic Character: Decreases";
            case 3:
                return "Period 3 Trends (Na to Ar):\n\n- Atomic Radius: Decreases\n- Ionization Energy: Increases\n- Electronegativity: Increases\n- Metallic Character: Decreases";
            case 4:
                return "Period 4 Trends (K to Kr):\n\n- Atomic Radius: Decreases\n- Ionization Energy: Irregular (d-block)\n- Electronegativity: Increases\n- Metallic Character: Decreases";
            case 5:
                return "Period 5 Trends (Rb to Xe):\n\n- Similar trends to Period 4 but larger\n- Lanthanides follow afterward";
            case 6:
                return "Period 6 Trends (Cs to Rn):\n\n- Lanthanide contraction\n- Transition metals and heavy p-block";
            case 7:
                return "Period 7 Trends (Fr to Og):\n\n- Actinides & synthetic elements\n- Many properties theoretical";
            default:
                return "Unknown period. Please select a valid period.";
        }
    }
}
