using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Weapon : ScriptableObject
{
    public int itemID;
    public string weaponName;
    public string description;
    public int damage;
    public Sprite image;
    public AnimationClip animation;
    public string message;
}
