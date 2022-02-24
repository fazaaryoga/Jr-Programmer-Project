using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public Color teamColor;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        LoadColor();

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.teamColor = teamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColor(){
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path)){
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            teamColor = data.teamColor;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public Color teamColor;
    }
}
