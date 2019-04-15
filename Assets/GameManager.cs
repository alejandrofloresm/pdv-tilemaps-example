using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string tempJson = "";
    public void SaveAction() {
        PlayerData data = new PlayerData();
        data.position = Player.position;
        data.life = 75;
        string dataString = JsonUtility.ToJson(data);
        // tempJson = dataString;
        GameManager.Save(dataString);
        Debug.Log("Save Action");
        Debug.Log("Data string: " + dataString);
    }

    public void LoadAction() {
        string dataString = GameManager.Load();
        PlayerData data = JsonUtility.FromJson<PlayerData>(dataString);
        Player.position = data.position;
    }

    public static void Save(string jsonString, string filename = "save.json", string storePath = null) {
        if (storePath == null) {
            storePath = Application.dataPath + "/saves";
        }
        if (!Directory.Exists(storePath)) {
            Directory.CreateDirectory(storePath);
        }
        string fullPath = storePath + "/" + filename;
        File.WriteAllText(fullPath, jsonString);
    }

    public static string Load(string filename = "save.json", string storePath = null) {
        if (storePath == null) {
            storePath = Application.dataPath + "/saves";
        }
        string fullPath = storePath + "/" + filename;
        string loaded = null;
        if (File.Exists(fullPath)) {
            loaded = File.ReadAllText(fullPath);
        }
        return loaded;
    }
}

public class PlayerData {
    public Vector3 position;
    public float life;
}