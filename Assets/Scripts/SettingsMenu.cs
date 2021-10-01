 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMainVolume;
    public Dropdown resolutionDropDown;
    Resolution[] resolutions;

    public Slider musicSlider;
    public Slider soundSlider;

    //avaible resolutions
    private void Start()
    {
        audioMainVolume.GetFloat("Music", out float musicValueForSlider);
        musicSlider.value = musicValueForSlider;

        audioMainVolume.GetFloat("Sound", out float soundValueForSlider);
        soundSlider.value = soundValueForSlider;

        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        resolutionDropDown.ClearOptions();
        List<string> resolutionsOptions = new List<string>();

        int currentResolutionIdex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            resolutionsOptions.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIdex = i;
            }
        }

        resolutionDropDown.AddOptions(resolutionsOptions);
        resolutionDropDown.value = currentResolutionIdex;
        resolutionDropDown.RefreshShownValue();

        Screen.fullScreen = true;
    }


    public void SetResolution( int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetMusicVolume (float musicVolume)
    {
        audioMainVolume.SetFloat("Music", musicVolume);
    }

    public void SetSoundVolume(float SoundVolume)
    {
        audioMainVolume.SetFloat("Sound",SoundVolume);
    }

    public void SetFullScreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }


   
    
        
}
