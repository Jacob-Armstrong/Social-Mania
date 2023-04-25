using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown resDropdown;

    Resolution[] resolutions;
    List<Resolution> filteredRes;

    void Start()
    {
        resolutions = Screen.resolutions;
        filteredRes = new List<Resolution>();

        resDropdown.ClearOptions();
        float currentRefreshRate = Screen.currentResolution.refreshRate;
        int currentRes = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            if(resolutions[i].refreshRate == currentRefreshRate)
            {
                filteredRes.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();

        for (int i = 0; i < filteredRes.Count; i++)
        {
            string option = filteredRes[i].width + " x " + filteredRes[i].height + " " + filteredRes[i].refreshRate + " Hz";
            options.Add(option);

            if (filteredRes[i].width == Screen.currentResolution.width
                && filteredRes[i].height == Screen.currentResolution.height)
            {
                currentRes = i;
            }
        }

        resDropdown.AddOptions(options);
        resDropdown.value = currentRes;
        resDropdown.RefreshShownValue();
    }

    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = filteredRes[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void setQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    public void setFullscreen(bool toggleFullscreen)
    {
        Screen.fullScreen = toggleFullscreen;
    }
}
