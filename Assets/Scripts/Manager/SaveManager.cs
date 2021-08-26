using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    public static void SaveDataCharacter(ref List<Character> character)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/character.save");
        bf.Serialize(file, character);
        file.Close();
        Debug.Log("Saved");
    }
    public static void LoadDataCharacter(ref List<Character> character)
    {
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + "/character.save"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/character.save", FileMode.Open);
            character = (List<Character>)bf.Deserialize(file);
            file.Close();
            Debug.Log("Load");
        }
        else
        {
            character = new List<Character>();
            character.Add(new Character(PlayerKind.SOLDIER));
            SaveDataCharacter(ref character);
            PlayerPrefs.SetFloat("MONEY", 100);
            PlayerPrefs.SetInt("MAP_LEVEL", 0);
            Debug.Log("null");
        }
    }
}
