using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class OptionsScreen : MonoBehaviour
{
    public Toggle fullscreenTog, vscyncTog;

    public List<ResItem> resolutions = new List<ResItem>();

    private int selectedResoltuion;

    public TMP_Text resolutionLabel;
    
    public AudioMixer mixer;
    public TMP_Text mastLabel, musicLabel, sfxLabel;
    public Slider mastSlider, musicSlider, sfxSlider;

    // Start is called before the first frame update
    void Start()
    {
        fullscreenTog.isOn = Screen.fullScreen;

        if (QualitySettings.vSyncCount == 0)
        {
            vscyncTog.isOn = false;
        }
        else
        {
            vscyncTog.isOn = true;
        }

        bool foundRes = false;
        
        for (int i = 0; i < resolutions.Count; i++)
        {
            if (Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;

                selectedResoltuion = i;
                
                UpdateResLabel();
            }
        }

        if (!foundRes)
        {
            ResItem newRes = new ResItem();
            newRes.horizontal = Screen.width;
            newRes.vertical = Screen.height;
            
            resolutions.Add(newRes);
            selectedResoltuion = resolutions.Count - 1;
            
            UpdateResLabel();
        }

        float vol = 0f;
        mixer.GetFloat("MasterVol", out vol);
        mastSlider.value = vol;
        mixer.GetFloat("MusicVol", out vol);
        musicSlider.value = vol;
        mixer.GetFloat("SFXVol", out vol);
        sfxSlider.value = vol;
        
        mastLabel.text = Mathf.RoundToInt(mastSlider.value + 80).ToString();
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();
    }

    public void ResLeft()
    {
        selectedResoltuion--;

        if (selectedResoltuion < 0)
        {
            selectedResoltuion = 0;
        }
        
        UpdateResLabel();
    }

    public void ResRight()
    {
        selectedResoltuion++;

        if (selectedResoltuion > resolutions.Count - 1)
        {
            selectedResoltuion = resolutions.Count - 1;
        }
        
        UpdateResLabel();
    }

    public void UpdateResLabel()
    {
        resolutionLabel.text = resolutions[selectedResoltuion].horizontal.ToString() + " x " + resolutions[selectedResoltuion].vertical.ToString();
    }

    public void ApplyGraphics()
    {

        if (vscyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
        
        Screen.SetResolution(resolutions[selectedResoltuion].horizontal, resolutions[selectedResoltuion].vertical, fullscreenTog.isOn);
    }
     
    public void SetMasterVol()
    {
        mastLabel.text = Mathf.RoundToInt(mastSlider.value + 80).ToString();
        mixer.SetFloat("MasterVol", mastSlider.value);
        
        PlayerPrefs.SetFloat("MasterVol", mastSlider.value);
    }
    
    public void SetMusicVol()
    {
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();
        mixer.SetFloat("MusicVol", musicSlider.value);
        
        PlayerPrefs.SetFloat("MusicVol", musicSlider.value);
    }
    
    public void SetSFXVol()
    {
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();
        mixer.SetFloat("SFXVol", sfxSlider.value);
        
        PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);
    }
}



[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}
