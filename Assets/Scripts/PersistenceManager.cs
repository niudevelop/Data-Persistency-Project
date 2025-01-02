using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;


public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance;
    public string playerName;
    public string currentPlayer;
    public int highScore;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
    }
    public void PersistData()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.playerName = playerName;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);


    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScore = data.highScore;
            Debug.Log("Current HighScore: "+ highScore);
            playerName = data.playerName;
        }
    }
}
