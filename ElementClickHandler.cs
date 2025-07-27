using UnityEngine;

[RequireComponent(typeof(Collider))] // Ensure collider exists
public class ElementClickHandler : MonoBehaviour
{
    public ElementData elementData;

    private void OnMouseDown() // For mouse input (Editor/PC)
    {
        ShowInfo();
    }

    // This is the universal method both mouse & XR will call
    public void ShowInfo()
    {
        if (elementData != null)
        {
            ElementInfoManager.Instance.ShowElementInfo(elementData);
        }
        else
        {
            Debug.LogWarning($"No ElementData assigned on {gameObject.name}");
        }
    }

    // This is what XR Simple Interactable calls
    public void ShowInfoXR()
    {
        ShowInfo(); // Just call the same logic
    }
}
