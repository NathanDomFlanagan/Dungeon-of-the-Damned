using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDescriptionController : MonoBehaviour
{
    public Transform itemImage;
    public Transform itemName;
    public Transform itemDesc;

    private ItemInventoryController im;

    void Awake()
    {
        itemImage = GameObject.Find("Description/ItemImage").transform;
        itemName = GameObject.Find("Description/ItemName").transform;
        itemDesc = GameObject.Find("Description/ItemDesc").transform;
        im = GetComponent<ItemInventoryController>();

    }
    public void setDescription()
    {

        itemImage.GetComponent<Image>().sprite = im.item.itemIcon;
        itemName.GetComponent<TMP_Text>().text = im.item.itemName;
        itemDesc.GetComponent<TMP_Text>().text = im.item.description;

    }
}
