using UnityEngine;
using System.Collections;

public class PanelSwitcer : MonoBehaviour
{

    public GameObject[] CenterPanels;
    public GameObject[] AddPanels;

    public GameObject CurrentCenterPanel;
    public GameObject CurrentAddPanel;

    void Start()
    {
        foreach (GameObject panel in CenterPanels)
        {
            bool active = (panel == CurrentCenterPanel) ? true : false;
            panel.SetActive(active);
        }

        foreach (GameObject panel in AddPanels)
        {
            bool active = (panel == CurrentAddPanel) ? true : false;
            panel.SetActive(active);
        }
    }

    public void SwitchCenterPanel(GameObject newPanel)
    {
        if(CurrentCenterPanel != null) CurrentCenterPanel.SetActive(false);
        CurrentCenterPanel = newPanel;
        CurrentCenterPanel.SetActive(true);
    }
}
