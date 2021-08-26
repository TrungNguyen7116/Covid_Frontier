using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject content;
    [SerializeField]
    private GameObject slot;
    private List<Character> list;
    void Start()
    {
        list = new List<Character>();
        list.Add(new Character(PlayerKind.SOLDIER));
        list.Add(new Character(PlayerKind.POLICE));
        list.Add(new Character(PlayerKind.RIOTPOLICE));
        list.Add(new Character(PlayerKind.INVESTOR));
        list.Add(new Character(PlayerKind.NURSE));
        list.Add(new Character(PlayerKind.DOCTOR));
        list.Add(new Character(PlayerKind.PARACHUTIST));
        list.Add(new Character(PlayerKind.RAMBO));
        list.Add(new Character(PlayerKind.GENERAL));
        DisplayListHeroInShop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DisplayListHeroInShop()
    {
        foreach (Character element in list)
        {
            GameObject hero = Instantiate(slot, content.transform);
            hero.GetComponent<SlotShop>().SetCharacter(element);
        }
    }
}
