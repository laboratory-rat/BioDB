using UnityEngine;
using System.Collections;

[SerializeField]
public class PanelSwitcher : MonoBehaviour {

    [Header("Groups")]
    public GameObject[] UpperPanels;
    public GameObject[] CenterPanels;
    public GameObject[] BottomPanels;

    [Header("Active")]
    public GameObject ActiveUp;
    public GameObject ActiveCenter;
    public GameObject ActiveBottom;

    void Start()
    {
        foreach (GameObject go in UpperPanels)
        {
            bool active = (go == ActiveUp) ? true : false;
            go.SetActive(active);
        }

        foreach (GameObject go in CenterPanels)
        {
            bool active = (go == ActiveCenter) ? true : false;
            go.SetActive(active);
        }

        foreach (GameObject go in BottomPanels)
        {
            bool active = (go == ActiveBottom) ? true : false;
            go.SetActive(active);
        }
    }

    public void SwitchUp()
    {

    }

    public void SwitchCenter(GameObject NewCenter)
    {
        if (ActiveCenter != null) ActiveCenter.SetActive(false);
        if (NewCenter == ActiveCenter)
        {
            ActiveCenter.SetActive(!ActiveCenter.activeInHierarchy);
            return;
        }
        ActiveCenter = NewCenter;
        ActiveCenter.SetActive(true);
    }

}
