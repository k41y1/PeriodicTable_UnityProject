using UnityEditor;
using UnityEngine;

public class AutoAssignElementData : EditorWindow
{
    [MenuItem("Tools/Auto-Assign Element Data")]
    public static void AssignElementDataToQuads()
    {
        GameObject wall = GameObject.Find("Periodic table wall"); // Rename if different
        if (wall == null)
        {
            Debug.LogError("Cannot find 'Periodic table wall' GameObject.");
            return;
        }

        int count = 0;

        foreach (Transform child in wall.transform)
        {
            string elementName = child.name;

            // Try to load matching ElementData asset
            ElementData data = Resources.Load<ElementData>($"PT Elements/{elementName}");
            if (data == null)
            {
                Debug.LogWarning($"No ElementData found for: {elementName}");
                continue;
            }

            // Add the ElementClickHandler script if missing
            ElementClickHandler handler = child.GetComponent<ElementClickHandler>();
            if (handler == null)
            {
                handler = child.gameObject.AddComponent<ElementClickHandler>();
            }

            handler.elementData = data;

            // Add collider if missing
            if (child.GetComponent<Collider>() == null)
            {
                child.gameObject.AddComponent<BoxCollider>();
            }

            count++;
        }

        Debug.Log($"✅ Auto-assigned ElementData to {count} elements.");
    }
}
