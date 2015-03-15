using UnityEngine;
using System.Collections;

namespace Lab70_Manager
{
    public class Manager : MonoBehaviour
    {

        public static Manager Instance = null;
        private Manager _instance
        {
            get { return Instance; }
            set
            {
                if (Instance == null)
                {
                    Instance = this;
                    DontDestroyOnLoad(this);
                }
                else
                {
                    Destroy(this);
                }
            }
        }

        public delegate void VoidAction();
        public static event VoidAction ConnectionSave;

        public Config config { get; private set; }
        public Connection connection { get; private set; }
        public User user { get; private set; }

        private string ConnectionPath = "Data/Connection/";
        private string UserPath = "Data/Users/";

        void Awake()
        {
            Instance = this;

            config = new Config();
            connection = new Connection(ConnectionPath);
        }

        public void CreateNewUser(string name, string pass)
        {
            user = new User(name, pass, UserPath, true);
        }

        public void LoadUser(string name, string pass)
        {
            user = new User(name, pass, UserPath);
        }
    }
}