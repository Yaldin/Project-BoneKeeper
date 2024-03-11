using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class ConsumableItem : ScriptableObject
{
    public int itemID;
    public string itemName;
    public string itemDescription;
    public Sprite image;
    public int healthGain;
    public int manaGain;
    public string itemMessage;
}
