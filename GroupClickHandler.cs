using UnityEngine;

public class GroupClickHandler : MonoBehaviour
{
    private GameObject[] groupPanels = new GameObject[18];
    private GameObject panelParent;

    public string groupName; // e.g. "Group4"

    void Start()
    {
        panelParent = GameObject.Find("GroupButtonCanvas");

        if (panelParent == null)
        {
            Debug.LogError("❌ GroupButtonCanvas not found.");
            return;
        }

        for (int i = 1; i <= 18; i++)
        {
            string panelName = $"Group{i}Panel";
            Transform panelTransform = panelParent.transform.Find(panelName);

            if (panelTransform != null)
            {
                groupPanels[i - 1] = panelTransform.gameObject;
                groupPanels[i - 1].SetActive(false);
            }
        }
    }

    public void OnGroupClicked(GameObject clickedCube)
    {
        // Hide all existing panels
        foreach (var panel in groupPanels)
        {
            if (panel != null)
                panel.SetActive(false);
        }

        string name = clickedCube.name; // Should be "Group4", etc.

        if (name.StartsWith("Group") && int.TryParse(name.Substring(5), out int groupNum))
        {
            int index = groupNum - 1;
            if (index >= 0 && index < groupPanels.Length && groupPanels[index] != null)
            {
                GameObject panel = groupPanels[index];
                panel.SetActive(true);

                // Position in front of the cube and slightly above
                Vector3 offset = new Vector3(0, 0.6f, 1.5f);
                Vector3 camForward = Camera.main.transform.forward;
                camForward.y = 0;

                panel.transform.position = clickedCube.transform.position + offset;
                panel.transform.rotation = Quaternion.LookRotation(camForward);
                panel.transform.localScale = Vector3.one * 0.01f;

                Debug.Log($"📊 Showing panel: {panel.name}");
            }
        }
    }
}
