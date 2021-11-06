using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;

    // Start is called before the first frame update
    private void Start()
    {
        resolutions=Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();


        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            Debug.Log(option);
            options.Add(option);

            if (resolutions[i].Equals(Screen.currentResolution))
            {
                currentResolutionIndex = i;
            }
           
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
       
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("volume",volume);
    }

    public void SetQuality(int QualityIndex)
    {
        QualitySettings.SetQualityLevel(QualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
    }

    


}
