using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotItem : MonoBehaviour
{
    public Items item = null;

    public void SetItem(Items target)
    {
        if (target == null)
        {
            item = null;
            return;
        }
        this.item = target;
        this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/" + item.name);
    }
    public void SelectItem()
    {
        GameObject shop = GameObject.Find("Item Shop Panel");
        if (this.gameObject.tag == "ItemBought")
        {
            shop.GetComponent<ItemShopManager>().SelectItem(item);
        }
        else
        {
            shop.GetComponent<ItemShopManager>().SelectItem(new Items(item));
        }
    }
}
