using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrbitalDisplay : MonoBehaviour
{
    [Header("Panel Control")]
    public GameObject orbitalPanel;

    [Header("UI Components")]
    public Image orbitalImage;
    public TextMeshProUGUI infoText;

    [Header("Orbital Sprites")]
    public Sprite sOrbital;
    public Sprite pOrbital;
    public Sprite dOrbital;
    public Sprite fOrbital;

    /// <summary>
    /// Show orbital info and reveal panel when a block is clicked
    /// </summary>
    public void ShowOrbital(string blockType)
    {
        if (orbitalPanel != null)
            orbitalPanel.SetActive(true);

        Debug.Log("🧪 Orbital selected: " + blockType);

        switch (blockType.ToLower())
        {
            case "s":
                orbitalImage.sprite = sOrbital;
                infoText.text =
                    "s-orbitals\n" +
                    "- Present in every shell (1s, 2s, 3s...). They are spherical.\n" +
                    "- Each s-orbital holds up to 2 electrons.\n\n" +
                    "s-Block Elements\n" +
                    "- Location: Groups 1 (Alkali Metals) and 2 (Alkaline Earth Metals), plus Helium.\n" +
                    "- Orbital Filling: The outermost 's' orbital is being filled (ns¹ or ns²).\n\n" +
                    "Key Properties:\n" +
                    "- Highly reactive metals (except H, He).\n" +
                    "- Soft, silvery-white, low melting points.\n" +
                    "- Tend to lose 1 or 2 electrons → form +1 or +2 ions.\n" +
                    "- Reactivity increases down the group.";
                break;

            case "p":
                orbitalImage.sprite = pOrbital;
                infoText.text =
                    "p-orbitals\n" +
                    "- Appear from shell 2 (2p, 3p, 4p...). Dumbbell-shaped.\n" +
                    "- Three orbitals per shell. Hold up to 6 electrons.\n\n" +
                    "p-Block Elements\n" +
                    "- Location: Groups 13–18 (excluding Helium).\n" +
                    "- Orbital Filling: 'p' orbitals are being filled (ns²np¹–⁶).\n\n" +
                    "Key Properties:\n" +
                    "- Diverse elements: nonmetals, metalloids, metals.\n" +
                    "- Separated from s-block by d-block.\n" +
                    "- Can gain, lose, or share electrons.\n" +
                    "- Non-metallic character increases up and to the right.";
                break;

            case "d":
                orbitalImage.sprite = dOrbital;
                infoText.text =
                    "d-orbitals\n" +
                    "- Appear from shell 3 onward (3d, 4d, 5d...).\n" +
                    "- Five cloverleaf-shaped orbitals. Hold up to 10 electrons.\n\n" +
                    "d-Block Elements (Transition Metals)\n" +
                    "- Location: Groups 3–12 (central block).\n" +
                    "- Orbital Filling: (n–1)d orbitals.\n\n" +
                    "Key Properties:\n" +
                    "- All are metals, often hard and dense.\n" +
                    "- High melting points.\n" +
                    "- Variable oxidation states. Form colored ions.";
                break;

            case "f":
                orbitalImage.sprite = fOrbital;
                infoText.text =
                    "f-orbitals\n" +
                    "- Seven orbitals per shell (starting at 4f, 5f...).\n" +
                    "- Complex shapes. Hold up to 14 electrons.\n\n" +
                    "f-Block Elements\n" +
                    "- Found in Lanthanides & Actinides (bottom rows).\n" +
                    "- Orbital Filling: (n–2)f orbitals.\n\n" +
                    "Key Properties:\n" +
                    "- Rare-earth and radioactive elements.\n" +
                    "- Used in magnets, nuclear tech, and lasers.";
                break;

            default:
                Debug.LogWarning("⚠️ Unknown block type: " + blockType);
                infoText.text = "❓ Unknown orbital block selected.";
                break;
        }
    }

    /// <summary>
    /// Hide the orbital panel (for close button or reset)
    /// </summary>
    public void HidePanel()
    {
        if (orbitalPanel != null)
            orbitalPanel.SetActive(false);
    }
}