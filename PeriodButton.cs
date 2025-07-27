using UnityEngine;

public class PeriodButton : MonoBehaviour
{
    public int periodNumber;  // Set this in Inspector

    private void OnMouseDown()
    {
        Debug.Log($"Clicked on Period {periodNumber}");

        if (PeriodInfoManager.Instance != null)
        {
            // Pass the periodNumber first and the position (transform.position) second
            PeriodInfoManager.Instance.MoveAndShow(periodNumber, transform.position);
        }
        else
        {
            Debug.LogError("PeriodInfoManager.Instance is null");
        }
    }
}
