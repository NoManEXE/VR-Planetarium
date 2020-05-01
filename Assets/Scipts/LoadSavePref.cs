using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LoadSavePref : MonoBehaviour
{
    public GameObject player;

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
        Position position = new Position();
        position.x = player.transform.position.x;
        position.y = player.transform.position.y;
        position.z = player.transform.position.z;
        
        if(!Directory.Exists(Application.dataPath + "/saves"))
        {
            Directory.CreateDirectory(Application.dataPath + "/saves");
        }
        FileStream fs = new FileStream(Application.dataPath + "/saves/save.sv", FileMode.Create);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(fs, position);
        fs.Close();

    }

    // Update is called once per frame
    public void Load()
    {
        if(File.Exists(Application.dataPath + "/saves/save.sv"))
        {
            FileStream fs = new FileStream(Application.dataPath + "/saves/save.sv", FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                Position pos = (Position)formatter.Deserialize(fs);
                player.transform.position = new Vector3(pos.x, pos.y, pos.z);
            }
            catch (System.Exception e)
            {
                Debug.Log(e.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        else
        {
            Application.Quit();
        }
    }
}
