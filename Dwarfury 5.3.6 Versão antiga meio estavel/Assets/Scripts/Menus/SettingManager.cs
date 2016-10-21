using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour {
    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;
    public Dropdown languageDropdown;
    public Slider soundSlider;

    public Resolution[] resolutions;
    public GameSettings gameSettings;

    void OnEnable()
    {
        gameSettings = new GameSettings();

        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle();  });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        qualityDropdown.onValueChanged.AddListener(delegate { OnQualityChange(); });
        languageDropdown.onValueChanged.AddListener(delegate { OnLanguageChange(); });
        soundSlider.onValueChanged.AddListener(delegate { OnSoundChange(); });

        resolutions = Screen.resolutions;
    }

    public void OnFullscreenToggle()
    {
        gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
    }

    public void OnResolutionChange()
    {

    }

    public void OnQualityChange()
    {
        QualitySettings.masterTextureLimit = gameSettings.quality = qualityDropdown.value;

    }

    public void OnLanguageChange()
    {

    }

    public void OnSoundChange()
    {

    }

    public void SaveSettings()
    {

    }

    public void LoadSettings()
    {

    }
}
