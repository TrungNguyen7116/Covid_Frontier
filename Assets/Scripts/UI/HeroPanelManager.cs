using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroPanelManager : MonoBehaviour
{
    public static HeroPanelManager instance;
    public List<GameObject> listSlotHero;
    [SerializeField]
    private GameObject content;
    [SerializeField]
    private GameObject slot;
    void Start()
    {
        if (instance == null) instance = this;
        listSlotHero = new List<GameObject>();
        DisplayHeroInHeroPanel();
    }
    void DisplayHeroInHeroPanel()
    {
        if (GameManager.instance != null)
        {
            for (int i = 0; i < GameManager.instance.character.Count; i++)
            {
                GameObject hero = Instantiate(slot, content.transform);
                hero.GetComponent<SlotHero>().SetCharacter(GameManager.instance.character[i]);
                listSlotHero.Add(hero);
            }
        }
    }
    public void BuyHero()
    {
        GameObject hero = Instantiate(slot, content.transform);
        hero.GetComponent<SlotHero>().SetCharacter(GameManager.instance.character[GameManager.instance.character.Count - 1]);
        listSlotHero.Add(hero);
        Debug.Log(GameManager.instance.character[GameManager.instance.character.Count - 1].atk);
    }
}
