using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopTemplate : MonoBehaviour
{
    public TMP_Text itemName;
    public Image itemIcon;
    public TMP_Text description;
    public TMP_Text itemCost;

    public void SetItemIcon(Sprite sprite)
    {
        itemIcon.sprite = sprite;
    }
}
