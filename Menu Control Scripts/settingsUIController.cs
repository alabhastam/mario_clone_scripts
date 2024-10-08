using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsUIController : MonoBehaviour
{
    public Slider volumeSlider;
    public Button backButton;
    public Toggle fullscreenToggle;
    public Button applyButton;

    void Start()
    {
        // Set the toggle to the current fullscreen state
        fullscreenToggle.isOn = Screen.fullScreen;

        // Add listener to the apply button
        applyButton.onClick.AddListener(ApplySettings);
        // Load the saved volume level
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
        
        // Add listener to the slider
        volumeSlider.onValueChanged.AddListener(SetVolume);
        
        // Add listener to the back button
        backButton.onClick.AddListener(BackToMainMenu);
    }

    void SetVolume(float value)
    {
        // Set the volume of the AudioListener
        AudioListener.volume = value;
        
        // Save the volume setting
        PlayerPrefs.SetFloat("Volume", value);
    }

    void BackToMainMenu()
    {
        // Load the MainMenu scene
        SceneManager.LoadScene("Main Menu");
    }
    public void ApplySettings()
    {
        // Set the fullscreen mode based on the toggle state
        Screen.fullScreen = fullscreenToggle.isOn;
    }
}
