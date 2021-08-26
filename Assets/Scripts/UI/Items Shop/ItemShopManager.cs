using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemShopManager : MonoBehaviour
{
    private List<Items> items;
    private InfoHeroPanel infoHero;
    [SerializeField]
    private ItemSpace itemSpace;

    private Items itemSelected;

    [SerializeField]
    private Image avatar;
    [SerializeField]
    private Text description;
    [SerializeField]
    private Text price;

    [SerializeField]
    private List<Image> itemBoughtUI;
    private List<Items> itemBought;
    
    void Start()
    {
        items = new List<Items>();
        for (int i = 0; i < 12; i++)
        {
            items.Add(new Items((ItemKind)i));
        }
        itemSpace.DrawSlotItem(items);
    }

    public void SetItemBought(ref List<Items> value, InfoHeroPanel panel)
    {
        itemBought = value;
        infoHero = panel;
        DisplayItemBought();
    }
    public void DisplayItemBought()
    {
        for (int i = 0; i < itemBought.Count; i++)
        {
            this.itemBoughtUI[i].sprite = Resources.Load<Sprite>("Items/" + itemBought[i].name);
            itemBoughtUI[i].gameObject.GetComponent<SlotItem>().SetItem(itemBought[i]);
        }
        for (int i = itemBought.Count; i < itemBoughtUI.Count; i++)
        {
            this.itemBoughtUI[i].sprite = Resources.Load<Sprite>("Items/null");
            itemBoughtUI[i].gameObject.GetComponent<SlotItem>().SetItem(null);
        }
    }

    public void Close()
    {
        infoHero.ReloadPanel();
        Time.timeScale = 1;
        SelectItem(null);
        this.gameObject.GetComponent<CanvasGroup>().alpha = 0;
        this.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void SelectItem(Items item)
    {
        if (item == null)
        {
            avatar.gameObject.SetActive(false);
            return;
        }
        if (item.price == 0)
        {
            avatar.gameObject.SetActive(false);
            return;
        }
        else
        {
            if (!avatar.gameObject.activeInHierarchy)
            {
                avatar.gameObject.SetActive(true);
            }
            itemSelected = item;
            avatar.sprite = Resources.Load<Sprite>("Items/" + item.name);
            description.text = item.description;
            price.text = item.price.ToString();
            Items target = itemBought.Find(obj => obj == item);
            if (target != null)
            {
                price.text = "Sell";
            }
        }
    }
    public void BuyOrSell()
    {
        this.gameObject.GetComponent<AudioSource>().Play();
        if (price.text == "Sell")
        {
            PlayerPrefs.SetFloat("MONEY", PlayerPrefs.GetFloat("MONEY") + 0.8f * itemSelected.price);
            Debug.Log("Sell");
            itemBought.Remove(itemSelected);
            SelectItem(null);
        }
        else
        {
            if (itemBought.Count < 4)
            {
                if (PlayerPrefs.GetFloat("MONEY") >= itemSelected.price)
                {
                    itemBought.Add(itemSelected);
                    PlayerPrefs.SetFloat("MONEY", PlayerPrefs.GetFloat("MONEY") - itemSelected.price);
                }
            }
        }
        DisplayItemBought();
        GameManager.instance.SaveData();
    }
}
