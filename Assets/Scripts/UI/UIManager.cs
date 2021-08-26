using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup HeroPanel;
    [SerializeField]
    private CanvasGroup ShopPanel;

    public void SelectHeroPanel()
    {
        ShopPanel.alpha = 0;
        ShopPanel.blocksRaycasts = false;
        HeroPanel.alpha = 1;
        HeroPanel.blocksRaycasts = true;
    }
    public void SelectShopPanel()
    {
        HeroPanel.alpha = 0;
        HeroPanel.blocksRaycasts = false;
        ShopPanel.alpha = 1;
        ShopPanel.blocksRaycasts = true;
    }
}
