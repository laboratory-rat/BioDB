using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Loader : MonoBehaviour {

    public static Loader Instance = null;
    private Loader _instace
    {
        get
        {
            return Instance;
        }
        set
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                GameObject.DestroyImmediate(this.gameObject);
            }
        }
    }


    public Config config;

    private string ConfigPath = "Data/config";

    void Awake()
    {
        Instance = this;
        
        config = LoadConfig();
        if (config.AutoConnect)
        {

        }
    }

    private Config LoadConfig()
    {
        if(!Directory.Exists("Data"))
            Directory.CreateDirectory("Data");
        if(File.Exists(ConfigPath))
        {
            FileStream fs = new FileStream(ConfigPath, FileMode.Open);
            Config newConfig;
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                newConfig = (Config)bf.Deserialize(fs);
                return newConfig;
            }
            catch 
            {
                Debug.Log("Error");
                return null;
            }
        }
        else
        {
            Config newConfig = new Config();
            SaveConfig(newConfig);
            return newConfig;
        }
    }

    public void SaveConfig(Config newConfig)
    {
        if (!Directory.Exists("Data"))
            Directory.CreateDirectory("Data");

        FileStream fs = new FileStream(ConfigPath, FileMode.OpenOrCreate);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, newConfig);
        config = newConfig;
    }

    public void Connect()
    {
        FTPConnector f = new FTPConnector(config.ServerAddres, config.UserName, config.UserPass);
        f.ListDir();
    }
}
