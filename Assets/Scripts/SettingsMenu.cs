﻿using System.Collections;
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

    //avaible resolutions
    private void Start()
    {
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
    public void SetVolume (float volume)
    {
        audioMainVolume.SetFloat("Volume", volume);
    }

    public void SetFullScreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }


   
    
        
}