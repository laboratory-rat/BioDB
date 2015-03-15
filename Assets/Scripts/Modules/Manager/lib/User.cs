using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Lab70_Manager
{
    public class User
    {

        public string Name;
        public UserData data;

        private string Path;

        public User(string name, string pass, string path, bool NewUser)
        {
            this.Name = name;
            this.Path = path;
            SaveUser(pass);
        }

        public User(string name, string pass, string path)
        {
            this.Name = name;
            this.Path = path;
            LoadUser(pass);
        }

        public void SaveUser(string pass)
        {
            if (Name == null || Path == null) return;
            if (!Directory.Exists(Path)) Directory.CreateDirectory(Path);


            data = new UserData(pass);

            FileStream fs = new FileStream(Path + Name, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                bf.Serialize(fs, data);
            }
            finally
            {
                fs.Close();
            }
        }

        private void LoadUser(string pass)
        {
            if (!File.Exists(Path + Name)) return;
            FileStream fs = new FileStream(Path + Name, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                data = (UserData)bf.Deserialize(fs);
            }
            finally
            {
                fs.Close();
            }
            if (data.Pass != pass) data = null;
        }
    }

    [System.Serializable]
    public class UserData
    {
        public string Pass;

        public UserData(string pass)
        {
            this.Pass = pass;
        }
    }
}