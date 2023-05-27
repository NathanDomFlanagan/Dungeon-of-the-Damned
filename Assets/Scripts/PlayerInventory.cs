using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoD;

public class PlayerInventory : MonoBehaviour
{
    private PlayerModel pm = null;

    public Object[] Inventory = new Object[10];
    private Object epicitem;
    public bool update = false;
    public bool removeupdate = false;

    public void pmSet(PlayerModel add)
    {
        if(pm == null)
        {
            pm = add;
        }
    }

    // Start is called before the first frame update
    void Start()//Not nessicary to Initialise anything other than the variables above.
    {
        epicitem = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Data/Items/Weapons/Axe 1.asset", typeof(WeaponData));
        epicitem = AddInventory(epicitem);
        AddInventory(epicitem);
    }

    //mostly for debug
    private void Update()
    {
        if (update)
        {
            // update function used for testing
            EquipItem(0);

            update = false;
        }
        if (removeupdate)
        {
            RemoveInventory(0);
        }
    }

    //
    public Object AddInventory(Object item) // add inventory does not remove it from where it was previously
        //when this function is called you need to at least hide the previously added item otherwise they can just add it again.
    {
        for (int i = 0; i < Inventory.Length; i++)
        {
            if (Inventory[i] == null) // searchs for an empty slot
            { 
                Inventory[i] = item;
                return null;
            }
        }

        //only reached if inventory is full
        return item;
    }

    //deletes from inventory array
    public void RemoveInventory(int i)
    {
        Inventory[i] = new Object();
    }

    public void EquipItem(int i) //swaps the value from the array to the player equipslot which is of the same type as it,
    {   //cannot equip item frame 0;
        Object item = Inventory[i];
        Inventory[i] = pm.AddItem(item);
    }

    public void UseItem() // to add functionality when single use items are implemented
    {
        
    }

}
