using UnityEngine;
using TMPro;

public class ElementInfoManager : MonoBehaviour
{
    public static ElementInfoManager Instance { get; private set; }

    [SerializeField] private GameObject infoPanel;
    [SerializeField] private TextMeshProUGUI elementNameText;
    [SerializeField] private TextMeshProUGUI factsText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("Multiple ElementInfoManager instances detected — destroying duplicate.");
            Destroy(gameObject);
            return;
        }

        Instance = this;

        if (infoPanel != null)
        {
            infoPanel.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Info panel reference is missing on ElementInfoManager.");
        }
    }

    public void ShowElementInfo(ElementData elementData)
    {
        if (elementData == null)
        {
            Debug.LogWarning("⚠️ Received null ElementData in ShowElementInfo.");
            return;
        }

        if (infoPanel == null || elementNameText == null || factsText == null)
        {
            Debug.LogError("❌ UI references missing in ElementInfoManager — cannot display element info.");
            return;
        }

        elementNameText.text = elementData.elementName;
        factsText.text = elementData.facts;
        infoPanel.SetActive(true);
    }

    public void HidePanel()
    {
        if (infoPanel != null)
        {
            infoPanel.SetActive(false);
        }
    }
}