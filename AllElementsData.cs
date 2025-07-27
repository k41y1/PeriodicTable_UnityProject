using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "AllElementsData", menuName = "ScriptableObjects/AllElementsData")]
public class AllElementsData : ScriptableObject
{
    public List<ElementData> elements; // List to hold all the element data
}
