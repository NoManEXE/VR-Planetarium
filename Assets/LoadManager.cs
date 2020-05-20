using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LoadManager : MonoBehaviour
{
    public Transform player;
    public static LoadManager instance;
    public Data data;

    public GameObject SaveGame;
    public GameObject LoadGame;
    string dataFile = "64617465.dat";
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);

        }

    }

    private void Start()
    {
        Load();
        player.position = LoadManager.instance.data.pos.toVector();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Save();
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }

        // if(SaveGame.onClick)
        // {
        //     Save();
        // }
        // else if(LoadGame.onClick)
        // {
        //     Load();
        // }
    }

    public void Save()
    {
        string filePath = Application.persistentDataPath + "/" + dataFile;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(filePath);
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        string filePath = Application.persistentDataPath + "/" + dataFile;
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(filePath))
        {
            FileStream file = File.Open(filePath, FileMode.Open);
            Data loaded = (Data)bf.Deserialize(file);
            data = loaded;
            file.Close();
        }
    }

}

[System.Serializable]
public class Data
{
    public Point pos;
    public int lvl = 1;
    public int health = 20;
    public Data()
    {
        lvl = 1;
        health = 30;
    }
}

[System.Serializable]
public class Point
{
    public float x;
    public float y;
    public float z;

    public Point(Vector3 p)
    {
        x = p.x;
        y = p.y;
        z = p.z;
    }

    public Vector3 toVector()
    {
        return new Vector3(x, y, z);
    }
}

