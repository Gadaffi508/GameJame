using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(fileName = "Itemler")]
public class Item : ScriptableObject
{
    public string ItemName;
    public Sprite image;
}
