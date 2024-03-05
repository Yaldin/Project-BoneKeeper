using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory inventory;
    public List<Weapon> weapons;
    public List<Key> keys;

    // Start is called before the first frame update
    void Awake()
    {
        if (inventory == null)
        {
            inventory = this;
        }
        else if (inventory != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void AddWeapon(Weapon weapon) 
    {
        weapons.Add(weapon);
    }

    public void AddKey(Key key)
    {
        keys.Add(key);
    }
}
