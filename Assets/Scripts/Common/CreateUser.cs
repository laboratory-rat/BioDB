using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Lab70_Manager;

[SerializeField]
public class CreateUser : MonoBehaviour {

    [Header("Input")]
    public InputField UserName;
    public InputField UserPass;
    public InputField UserPass2;

    [Header("Out")]
    public GameObject PanelSwitcher;
    public GameObject NewUpPanel;
    public GameObject NewCenterPanel;
    public GameObject NewBottomPanel;

    public void CreateNewUser()
    {
        if (UserName == null || UserName.text == "" || UserPass == null || UserPass.text == "" || UserPass2 == null || UserPass2.text == "")
            return;
        
        string pass1 = UserPass.text;
        string pass2 = UserPass2.text;

        if (pass1 != pass2)
        {
            Debug.Log("Passwords not mach!");
            return;
        }
        Manager.Instance.CreateNewUser(UserName.text, UserPass.text);
        if (Manager.Instance.user.Name == UserName.text)
        {
            PanelSwitcher ps = PanelSwitcher.GetComponent<PanelSwitcher>();
            ps.SwitchCenter(NewCenterPanel);
        }
    }
}
