using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GroupButtonXRBridge : MonoBehaviour
{
    public GroupClickHandler clickHandler;

    void Awake()
    {
        if (clickHandler == null)
        {
            clickHandler = FindObjectOfType<GroupClickHandler>();
        }
    }

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (clickHandler != null)
        {
            clickHandler.OnGroupClicked(gameObject);
        }
    }
}
