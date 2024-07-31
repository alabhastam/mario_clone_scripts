using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VolumeSettings : MonoBehaviour
{
    public Slider volumeSlider;
    public Button backButton;

    void Start()
    {
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
        SceneManager.LoadScene("MainMenu");
    }
}
