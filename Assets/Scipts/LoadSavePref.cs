using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSavePref : MonoBehaviour
{

    public Text recScore;
    public GameObject player;
    void Start()
    {
        Load();
    }
  
    

    [System.Serializable]
    public class Position
    {
        public float x;
        public float y;
        public float z;
    }
    // Start is called before the first frame update
    public void Save()
    {
        // Position position = new Position();
        // position.x = player.transform.position.x;
        // position.y = player.transform.position.y;
        // position.z = player.transform.position.z;
        

        // if(!Directory.Exists(Application.persistentDataPath + "/saves"))
        // {
        //     Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        // }
        // FileStream fs = new FileStream(Application.persistentDataPath + "/saves/save.sv", FileMode.Create);
        // BinaryFormatter formatter = new BinaryFormatter();
        // formatter.Serialize(fs, position);
        // fs.Close();
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", player.transform.position.z);
        PlayerPrefs.SetString( "Score", recScore.text);
    }

    // Update is called once per frame
    public void Load()
    {
    //     if(File.Exists(Application.persistentDataPath + "/saves/save.sv"))
    //     {
    //         FileStream fs = new FileStream(Application.persistentDataPath + "/saves/save.sv", FileMode.Open);
    //         BinaryFormatter formatter = new BinaryFormatter();
    //         try
    //         {
    //             Position pos = (Position)formatter.Deserialize(fs);
    //             player.transform.position = new Vector3(pos.x, pos.y, pos.z);
    //         }
    //         catch (System.Exception e)
    //         {
    //             Debug.Log(e.Message);
    //         }
    //         finally
    //         {
    //             fs.Close();
    //         }
    //     }
    //     else
    //     {
    //         Application.Quit();
    //     }

        player.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));
        recScore.text = PlayerPrefs.GetString("Score");
    }

}
