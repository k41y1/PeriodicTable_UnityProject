using UnityEngine;
using TMPro;

public class ElementDisplay : MonoBehaviour
{
    public ElementData data; // Drag the ScriptableObject with the element's data (name & facts)
    public TextMeshPro labelText; // TextMeshPro component for element name
    public GameObject infoPanel; // Info panel (Canvas) to show when element is clicked
    public TextMeshProUGUI infoText; // TextMeshPro component inside the info panel to display facts

    void Start()
    {
        // If the data and labelText are set, update the label with the element's name
        if (data != null && labelText != null)
        {
            labelText.text = data.elementName; // Update label with element name
        }
    }

    void OnMouseDown() // When the element is clicked
    {
        ShowInfo(); // Show the info panel when clicked
    }

    // Make ShowInfo() public to be accessible by other scripts
    public void ShowInfo()
    {
        // Update the info panel text with the element's facts
        infoText.text = $"<b>{data.elementName}</b>\n\n{data.facts}";

        // Position the info panel near the clicked element (offset a little above the element)
        infoPanel.transform.position = transform.position + new Vector3(0, 0.4f, 0);
        infoPanel.SetActive(true); // Show the info panel
    }

    public void HideInfo() // Optionally, hide the info panel (if needed)
    {
        infoPanel.SetActive(false); // Hide the info panel
    }
}
