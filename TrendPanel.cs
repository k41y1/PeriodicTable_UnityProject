using TMPro;
using UnityEngine;

public class TrendPanel : MonoBehaviour
{
    public static TrendPanel Instance;

    public GameObject panelObject;
    public TextMeshProUGUI trendText;

    void Awake()
    {
        // Assign this instance for static access
        Instance = this;

        // Hide the panel on start
        panelObject.SetActive(false);
    }

    public static void ShowMessage(string message)
    {
        if (Instance == null)
        {
            Debug.LogWarning("TrendPanel instance not found.");
            return;
        }

        Instance.panelObject.SetActive(true);
        Instance.trendText.text = message;
    }
}