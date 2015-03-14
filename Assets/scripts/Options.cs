using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Options : MonoBehaviour {

    public InputField SAHolder;
    public InputField SUHolder;
    public InputField SPHolder;
    public InputField UHolder;
    public InputField PHolder;
    
    [Header("2")]
    public string ServerAddr;
    public string ServerUser;
    public string ServerPass;
    public string User;
    public string Pass;

    private Config config;

    void Awake()
    {
        config = Loader.Instance.config;

        SAHolder.text = config.ServerAddres;
        SUHolder.text = config.ServerUser;
        SPHolder.text = config.ServerPass;
        UHolder.text = config.UserName;
        PHolder.text = config.UserPass;
    }

    public void Save()
    {
        Loader.Instance.SaveConfig(config);
    }

    public void Apply()
    {
        Loader.Instance.SaveConfig(config);
    }

    public void ChangeSeverAdd(InputField go)
    {
        ServerAddr = go.text;
        config.ServerAddres = ServerAddr;
    }
    public void ChangeSeverUser(InputField go)
    {
        ServerUser = go.text;
        config.ServerUser = ServerUser;
    }
    public void ChangeSeverPass(InputField go)
    {
        ServerPass = go.text;
        config.ServerPass = ServerPass;
    }
    public void ChangeUser(InputField go)
    {
        User = go.text;
        config.UserName = User;
    }
    public void ChangePass(InputField go)
    {
        Pass = go.text;
        config.UserPass = Pass;
    }
}
