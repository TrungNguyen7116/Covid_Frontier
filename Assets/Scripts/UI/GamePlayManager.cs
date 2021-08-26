using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager instance;
    private int mapLevel;
    [SerializeField]
    private Text mapText;
    [SerializeField]
    private TextMeshProUGUI money;
    [SerializeField]
    private CameraFollow main;
    [SerializeField]
    private GameObject startPoint;
    [SerializeField]
    private GameObject endPoint;
    //Hero
    [SerializeField]
    private GameObject soldier;
    [SerializeField]
    private GameObject police;
    [SerializeField]
    private GameObject riot_police;
    [SerializeField]
    private GameObject investor;
    [SerializeField]
    private GameObject nurse;
    [SerializeField]
    private GameObject doctor;
    [SerializeField]
    private GameObject parachutist;
    [SerializeField]
    private GameObject rambo;
    [SerializeField]
    private GameObject general;

    
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        mapLevel = PlayerPrefs.GetInt("MAP_LEVEL");
        StartCoroutine(WaitingLoad());
    }

    // Update is called once per frame
    void Update()
    {
        mapText.text = mapLevel.ToString();
        money.text = Math.Round(PlayerPrefs.GetFloat("MONEY"), 2).ToString();
    }
    public void StartGame()
    {
        startPoint.GetComponent<StartPoint>().Reset();
        endPoint.GetComponent<EndPoint>().Reset();
        for (int i = 0; i < GameManager.instance.character.Count; i++)
        {
            GameObject hero = CreateHero(GameManager.instance.character[i].kind);
            hero.GetComponent<Player>().InitPlayer(GameManager.instance.character[i]);
            HeroPanelManager.instance.listSlotHero[i].GetComponent<SlotHero>().SetPlayer(hero.GetComponent<Player>());
            RandomPosition(hero);
        }
        MapLevelManager.instance.SetLevel(mapLevel);
        main.StartGame();
    }
    IEnumerator WaitingLoad()
    {
        yield return new WaitForSeconds(1);
        StartGame();
    }
    public void NextMap()
    {
        if (mapLevel < 50) mapLevel++;
        PlayerPrefs.SetInt("MAP_LEVEL", mapLevel);
        PlayerPrefs.SetFloat("MONEY", PlayerPrefs.GetFloat("MONEY") + 50);
        main.EndGame();
        StartCoroutine(WaitingLoad());
    }
    public void PreMap()
    {
        if (mapLevel > 0) mapLevel--;
        PlayerPrefs.SetInt("MAP_LEVEL", mapLevel);
        main.EndGame();
        StartCoroutine(WaitingLoad());
    }
    GameObject CreateHero(PlayerKind playerKind)
    {
        GameObject hero = null;
        switch (playerKind)
        {
            case PlayerKind.SOLDIER:
                hero = Instantiate(soldier, startPoint.transform.position, Quaternion.identity);
                break;
            case PlayerKind.POLICE:
                hero = Instantiate(police, startPoint.transform.position, Quaternion.identity);
                break;
            case PlayerKind.RIOTPOLICE:
                hero = Instantiate(riot_police, startPoint.transform.position, Quaternion.identity);
                break;
            case PlayerKind.INVESTOR:
                hero = Instantiate(investor, startPoint.transform.position, Quaternion.identity);
                break;
            case PlayerKind.NURSE:
                hero = Instantiate(nurse, startPoint.transform.position, Quaternion.identity);
                break;
            case PlayerKind.DOCTOR:
                hero = Instantiate(doctor, startPoint.transform.position, Quaternion.identity);
                break;
            case PlayerKind.PARACHUTIST:
                hero = Instantiate(parachutist, startPoint.transform.position, Quaternion.identity);
                break;
            case PlayerKind.RAMBO:
                hero = Instantiate(rambo, startPoint.transform.position, Quaternion.identity);
                break;
            case PlayerKind.GENERAL:
                hero = Instantiate(general, startPoint.transform.position, Quaternion.identity);
                break;
        }
        return hero;
    }
    void RandomPosition(GameObject target)
    {
        float x = x = UnityEngine.Random.Range(-0.5f, 0.5f);
        float y = UnityEngine.Random.Range(-0.3f, 0.3f);
        target.transform.position = new Vector2(target.transform.position.x + x, target.transform.position.y + y);
    }
}
