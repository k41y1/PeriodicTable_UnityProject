using UnityEngine;

[CreateAssetMenu(fileName = "ElementData", menuName = "ScriptableObjects/ElementData")]
public class ElementData : ScriptableObject
{
    public string elementName;
    [TextArea]
    public string facts;
}
