#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEngine.XR.Interaction.Toolkit;

public class AutoXRSetup : MonoBehaviour
{
    [MenuItem("Tools/Periodic Table/Auto Setup XR Interactions")]
    static void SetupXRElementInteractions()
    {
        GameObject tableWall = GameObject.Find("Periodic table wall");
        if (tableWall == null)
        {
            Debug.LogError("❌ 'Periodic table wall' not found in scene.");
            return;
        }

        int count = 0;

        foreach (Transform child in tableWall.transform)
        {
            GameObject element = child.gameObject;

            // Ensure ElementClickHandler exists
            ElementClickHandler handler = element.GetComponent<ElementClickHandler>();
            if (handler == null)
                handler = element.AddComponent<ElementClickHandler>();

            // Ensure XRSimpleInteractable exists
            XRSimpleInteractable interactable = element.GetComponent<XRSimpleInteractable>();
            if (interactable == null)
                interactable = element.AddComponent<XRSimpleInteractable>();

            // Ensure Collider exists
            if (element.GetComponent<Collider>() == null)
                element.AddComponent<BoxCollider>();

            // Add listener using a lambda expression
            interactable.onSelectEntered.AddListener((XRBaseInteractor interactor) =>
            {
                handler.ShowInfoXR();
            });

            count++;
        }

        Debug.Log($"✅ XR setup complete for {count} elements. Listeners are added at runtime.");
    }
}
#endif
