using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MainMenu : MonoBehaviour
{   
   private GameObject player;
     [System.Serializable]
    public class Position
    {
        public float x;
        public float y;
        public float z;
    }
    // Start is called before the first frame update
    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {      
        
        SceneManager.LoadScene(1);

        //    if(File.Exists(Application.persistentDataPath + "/saves/save.sv"))
        // {
        //     FileStream fs = new FileStream(Application.persistentDataPath + "/saves/save.sv", FileMode.Open);
        //     BinaryFormatter formatter = new BinaryFormatter();
        //     try
        //     {
        //         Position pos = (Position)formatter.Deserialize(fs);   
        //                             player = GameObject.Find("Player");
             
        //         player.transform.position = new Vector3(pos.x, pos.y, pos.z);
        //     }
        //     catch (System.Exception e)
        //     {
        //         Debug.Log(e.Message);
        //     }
        //     finally
        //     {
        //         fs.Close();
        //     }
        // }
        // else
        // {
        //     Application.Quit();
        // }
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
