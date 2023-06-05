using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Function used for the description in the inventory
public class ItemDescriptionController : MonoBehaviour
{
    //Variables
    public Transform itemImage;
    public Transform itemName;
    public Transform itemDesc;

    //Private reference to the ItemInventoryController
    private ItemInventoryController im;

    void Awake()
    {
        //Grabs the transform components and GameObject for the variables and private reference
        itemImage = GameObject.Find("Description/ItemImage").transform;
        itemName = GameObject.Find("Description/ItemName").transform;
        itemDesc = GameObject.Find("Description/ItemDesc").transform;
        im = GetComponent<ItemInventoryController>();
    }
    
    //Public function that sets the description in the inventory
    //Data that it takes is stored in the item's data
    public void setDescription()
    {
            itemImage.GetComponent<Image>().sprite = im.item.itemIcon;
            itemName.GetComponent<TMP_Text>().text = im.item.itemName;
            itemDesc.GetComponent<TMP_Text>().text = im.item.description;
    }
}
