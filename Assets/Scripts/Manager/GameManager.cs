using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<Character> character;
    public int mapLevel;
    public float money;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
        SaveManager.LoadDataCharacter(ref character);
        mapLevel = PlayerPrefs.GetInt("MAP_LEVEL");
        money = PlayerPrefs.GetFloat("MONEY");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Clear();
        }
    }
    public void SaveData()
    {
        SaveManager.SaveDataCharacter(ref character);
    }
    void Clear()
    {
        character.Clear();
        SaveData();
    }
}
