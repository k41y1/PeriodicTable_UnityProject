using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class BottomGroups : MonoBehaviour
{
    public enum ElementType { Lanthanide, Actinide }

    [Header("Element Group")]
    public ElementType elementType;

    [Header("Panels")]
    public GameObject lanthanidePanel;
    public GameObject actinidePanel;

    [Header("Text Fields")]
    public TextMeshProUGUI lanthanideText;
    public TextMeshProUGUI actinideText;

    [Header("Visual Feedback")]
    public Color hoverColor = Color.yellow;
    private Renderer rend;
    private Color originalColor;

    void Start()
    {
        // Cache original material color
        rend = GetComponent<Renderer>();
        if (rend != null) originalColor = rend.material.color;

        // Register XR events
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnVRClick);
            interactable.hoverEntered.AddListener(OnVRHoverEnter);
            interactable.hoverExited.AddListener(OnVRHoverExit);
        }

        // Start by hiding both panels
        if (lanthanidePanel != null) lanthanidePanel.SetActive(false);
        if (actinidePanel != null) actinidePanel.SetActive(false);
    }

    void OnMouseDown()
    {
        HandleClick();
    }

    void OnVRClick(SelectEnterEventArgs args)
    {
        HandleClick();
    }

    void HandleClick()
    {
        Debug.Log($"🧪 Selected group: {elementType}");

        // Hide both panels first
        if (lanthanidePanel != null) lanthanidePanel.SetActive(false);
        if (actinidePanel != null) actinidePanel.SetActive(false);

        // Activate the relevant panel and update text
        if (elementType == ElementType.Lanthanide && lanthanidePanel != null)
        {
            lanthanidePanel.SetActive(true);
            Debug.Log("✅ Lanthanide panel activated!");

            if (lanthanideText != null)
                lanthanideText.text = "Information on lanthanides:\r\n\r\nElements: Atomic numbers 57 (Lanthanum) to 71 (Lutetium).\r\n\r\nClassification: F-block elements, inner transition metals, also called \"rare-earth elements.\"\r\n\r\nAppearance: Silvery-white, lustrous metals.\r\n\r\nReactivity: Generally reactive metals.\r\n\r\nOxidation State: Most common is +3.\r\n\r\nLanthanide Contraction: Atomic and ionic radii gradually decrease across the series due to poor 4f shielding, impacting subsequent elements.\r\n\r\nPhysical Properties: Soft metals, high melting/boiling points, good conductors; many have unique magnetic/optical properties.\r\n";
            else
                Debug.LogWarning("⚠️ Lanthanide text reference not assigned.");
        }

        if (elementType == ElementType.Actinide && actinidePanel != null)
        {
            actinidePanel.SetActive(true);
            Debug.Log("✅ Actinide panel activated!");

            if (actinideText != null)
                actinideText.text = "Information on Actinide:\r\n\r\nElements: Atomic numbers 89 (Actinium) to 103 (Lawrencium).\r\n\r\nClassification: F-block elements, inner transition metals.\r\n\r\nRadioactivity: All are radioactive; most are synthetic.\r\n\r\nAppearance: Silvery-white metals.\r\n\r\nReactivity: Highly reactive.\r\n\r\nOxidation States: Exhibit a wide range (though +3 is common).\r\n\r\nActinide Contraction: Atomic/ionic radii gradually decrease across the series due to poor 5f shielding.\r\n\r\nPhysical Properties: Generally dense, malleable, and ductile.";
            else
                Debug.LogWarning("⚠️ Actinide text reference not assigned.");
        }
    }

    void OnVRHoverEnter(HoverEnterEventArgs args)
    {
        if (rend != null) rend.material.color = hoverColor;
    }

    void OnVRHoverExit(HoverExitEventArgs args)
    {
        if (rend != null) rend.material.color = originalColor;
    }
}