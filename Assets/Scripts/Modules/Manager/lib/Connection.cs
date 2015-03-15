using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab70_Manager
{
    public class Connection
    {
        public string ServerDomen;
        public string UserName;
        public string UserPassword;
        
        private string Path;
        private string FileName = "ConnectionData";

        public Connection(string path)
        {
            this.Path = path;
            Load();
        }

        public void Save()
        {
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
                return;
            }
            
            Dictionary<string, string> data = new Dictionary<string,string>
            {
                {"ServerDomen", ServerDomen},
                {"UserName", UserName},
                {"UserPassword", UserPassword},
            };

            FileStream fs = new FileStream(Path + FileName, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                bf.Serialize(fs, data);
            }
            catch
            {
                Debug.Log("Cant save connection data!");
            }
            finally
            {
                fs.Close();
            }
        }

        public void Load()
        {
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
                return;
            }
            if (!File.Exists(Path + FileName)) return;

            FileStream fs = new FileStream(Path + FileName, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                Dictionary<string, string> data = (Dictionary<string, string>)bf.Deserialize(fs);
                ServerDomen = data["ServerDomen"];
                UserName = data["UserName"];
                UserPassword = data["UserPassword"];
            }
            catch
            {
                Debug.Log("Cant Load Connection Data!");
            }
            finally
            {
                fs.Close();
            }
        }

        public void SetParams(string sn, string un, string up)
        {
            ServerDomen = sn;
            UserName = un;
            UserPassword = up;
        }

        public bool ConnectTest()
        {
            if (ServerDomen == null || UserName == null || UserPassword == null)
            {
                return false;
            }

            return true;
        }
    }
}