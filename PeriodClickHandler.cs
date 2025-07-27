using UnityEngine;

public class PeriodClickHandler : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GameObject clicked = hit.collider.gameObject;
                if (clicked.CompareTag("PeriodButton"))
                {
                    string periodName = clicked.name;
                    Debug.Log("Mouse Clicked: " + periodName);
                    ShowPeriodTrend(periodName);
                }
            }
        }
    }

    // XR Interactable Hooks (assign these to SelectEntered events)
    public void ShowPeriod1() => ShowPeriodTrend("Period1");
    public void ShowPeriod2() => ShowPeriodTrend("Period2");
    public void ShowPeriod3() => ShowPeriodTrend("Period3");
    public void ShowPeriod4() => ShowPeriodTrend("Period4");
    public void ShowPeriod5() => ShowPeriodTrend("Period5");
    public void ShowPeriod6() => ShowPeriodTrend("Period6");
    public void ShowPeriod7() => ShowPeriodTrend("Period7");

    void ShowPeriodTrend(string periodName)
    {
        Debug.Log("ShowPeriodTrend called for: " + periodName);

        int index = ExtractPeriodIndex(periodName);

        // Define a position where the panel should appear (this is just an example)
        Vector3 panelPosition = new Vector3(0, 1, 2); // You can adjust the position as needed

        // Call the updated method to show and move the panel at the selected position
        PeriodInfoManager.Instance.MoveAndShow(index, panelPosition);

        // Show extra message if needed
        string message = GetTrendMessage(index);
        TrendPanel.ShowMessage(message);
    }

    int ExtractPeriodIndex(string periodName)
    {
        // Expecting names like "Period1", "Period2", etc.
        string number = periodName.Replace("Period", "");
        return int.TryParse(number, out int result) ? result : 0;
    }

    string GetTrendMessage(int index)
    {
        switch (index)
        {
            case 1: return "Period 1: Only H and He — very unique properties.";
            case 2: return "Period 2: Atomic radius decreases →, electronegativity increases →";
            case 3: return "Period 3: Metallic → nonmetallic trend; more complex bonding.";
            case 4: return "Period 4: Transition metals begin — variable oxidation states.";
            case 5: return "Period 5: Bigger atoms; trends repeat with added complexity.";
            case 6: return "Period 6: Lanthanides enter; heavier and less reactive metals.";
            case 7: return "Period 7: Includes synthetic elements and radioactive actinides.";
            default: return "Trend not defined for this period.";
        }
    }
}
