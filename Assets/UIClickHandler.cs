using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

//Function used to determine if the user did a left or right click
public class UIClickHandler : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent onLeftClick;
    public UnityEvent onRightClick;
    public UnityEvent onMiddleClick;

    private ItemInventoryController im;

    void Awake()
    {
        im = GetComponent<ItemInventoryController>();       //Grabs local ItemInventoryController
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        //For left click
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (im.item.isEquipped == false)
            {
                onLeftClick.Invoke();
                im.item.isEquipped = true;  
            } else
            {
                return;
            }
        }

        //For right click
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            onRightClick.Invoke();
            im.item.isEquipped = false;
        }
    }
}