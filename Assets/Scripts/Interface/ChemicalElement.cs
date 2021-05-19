using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Element", menuName = "Element")]
public class ChemicalElement : ScriptableObject
{
    public new string name;

    public int oxidationLevel;

}
