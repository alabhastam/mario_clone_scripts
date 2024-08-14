using UnityEngine;

public class ShowInfoScript : MonoBehaviour
{
    public GameObject infoPanel;  // Reference to the panel with the text

    void Start()
    {
        infoPanel.SetActive(false); // Ensure the panel is hidden initially
    }

    public void OnToggleInfoButtonClick()
    {
        // Toggle the panel's active state
        infoPanel.SetActive(!infoPanel.activeSelf);
    }
}
