using UnityEngine;
using UnityEngine.UI;

public class ShowInfoScript : MonoBehaviour
{
    public GameObject infoPanel;  

    void Start()
    {
        infoPanel.SetActive(false); 
    }

    public void OnShowInfoButtonClick()
    {
        infoPanel.SetActive(true); 
    }

    public void OnCloseButtonClick()
    {
        infoPanel.SetActive(false); 
    }
}
