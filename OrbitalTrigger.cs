using UnityEngine;

public class OrbitalTrigger : MonoBehaviour
{
    public string blockType = "s"; // Set per cube in Inspector

    private void OnMouseDown()
    {
        // For mouse/trackpad testing in desktop mode
        var display = FindObjectOfType<OrbitalDisplay>();
        if (display != null)
        {
            display.ShowOrbital(blockType);
            Debug.Log("🖱️ Clicked: " + blockType);
        }
    }

    private void Update()
    {
        // For basic VR controller raycast-style testing
        if (Input.GetMouseButtonDown(0)) // Trigger or click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    var display = FindObjectOfType<OrbitalDisplay>();
                    if (display != null)
                    {
                        display.ShowOrbital(blockType);
                        Debug.Log("🎮 VR-style click: " + blockType);
                    }
                }
            }
        }
    }
}