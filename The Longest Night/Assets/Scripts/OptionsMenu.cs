using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] GameObject VisualPanel;
    [SerializeField] GameObject SoundPanel;
    [SerializeField] GameObject HelpPanel;
    [SerializeField] GameObject TipsPanel;
    [SerializeField] GameObject DifficultyPanel;
    [SerializeField] GameObject BackToMenuPanel;
    public Slider LightSlider;
    public Toggle fogToggle;

    //aa
    public Toggle toggleAAoFF;
    public Toggle toggleFXAA;
    public Toggle toggleSMAA;
    public Toggle toggleTAA;
    private int antiState = 4;

    [SerializeField] PostProcessLayer myPPLayer;
    private bool fogOn = true;

    public Toggle fpsToggle;
    [SerializeField] GameObject FPSdisplay;
    private bool FPSOn = false;

    public Slider ambianceLevel;
    public Slider SFXLevel;
    public AudioMixer ambienceMixer;
    public AudioMixer sfxMixer;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = true;
        //Time.timeScale = 0;

        VisualPanel.gameObject.SetActive(true);
        SoundPanel.gameObject.SetActive(false);
        HelpPanel.gameObject.SetActive(false);
        DifficultyPanel.gameObject.SetActive(false);
        BackToMenuPanel.gameObject.SetActive(false);


        if (PlayerPrefs.HasKey("AAstate"))
        {
            int aa = PlayerPrefs.GetInt("AAstate");
            switch (aa)
            {
                case 1:
                    toggleAAoFF.isOn = true;
                    antiAliasingOFF();
                    break;
                case 2:
                    toggleFXAA.isOn = true;
                    antiAliasingFXAA();
                    break;
                case 3:
                    toggleSMAA.isOn = true;
                    antiAliasingSMAA();
                    break;
                case 4:
                    toggleTAA.isOn = true;
                    antiAliasingTAA();
                    break;
            }
        }
    }

    // Update is called once per frame

    public void fogState()
    {
        if (fogToggle.isOn == true)
        {
            if (fogOn)
            {
                myPPLayer.fog.enabled = false;
                fogOn = false;
            }
            else if (fogOn == false)
            {
                myPPLayer.fog.enabled = true;
                fogOn = true;
            }
        }
        if (fogToggle.isOn == false)
        {
            if (fogOn)
            {
                myPPLayer.fog.enabled = false;
                fogOn = false;
            }
            else if (fogOn == false)
            {
                myPPLayer.fog.enabled = true;
                fogOn = true;
            }
        }
    }

    public void FPSState()
    {
        if (fpsToggle.isOn == true)
        {
            if (FPSOn)
            {
                //myPPLayer.fog.enabled = false;
                FPSdisplay.gameObject.SetActive(false);
                FPSOn = false;
            }
            else if (FPSOn == false)
            {
                // myPPLayer.fog.enabled = true;
                FPSdisplay.gameObject.SetActive(true);
                FPSOn = true;
            }
        }
        if (fpsToggle.isOn == false)
        {
            if (FPSOn)
            {
                // myPPLayer.fog.enabled = false;
                FPSdisplay.gameObject.SetActive(false);
                FPSOn = false;
            }
            else if (FPSOn == false)
            {
                //myPPLayer.fog.enabled = true;
                FPSdisplay.gameObject.SetActive(true);
                FPSOn = true;
            }
        }
    }

    public void ambianceVolume()
    {
        ambienceMixer.SetFloat("Volume", ambianceLevel.value);
    }
    public void SFXVolume()
    {
        sfxMixer.SetFloat("Volume", SFXLevel.value);
    }

    public void antiAliasingOFF()
    {
        if (antiState != 1)
        {
            if (toggleAAoFF.isOn == true)
            {
                myPPLayer.antialiasingMode = PostProcessLayer.Antialiasing.None;
                toggleFXAA.isOn = false;
                toggleSMAA.isOn = false;
                toggleTAA.isOn = false;
                antiState = 1;
                PlayerPrefs.SetInt("AAstate", 1);
            }
        }
    }

    public void antiAliasingFXAA()
    {
        if (antiState != 2)
        {
            if (toggleFXAA.isOn == true)
            {
                myPPLayer.antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
                toggleAAoFF.isOn = false;
                toggleSMAA.isOn = false;
                toggleTAA.isOn = false;
                antiState = 2;
                PlayerPrefs.SetInt("AAstate", 2);
            }
        }
    }

    public void returnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void antiAliasingSMAA()
    {
        if (antiState != 3)
        {
            if (toggleSMAA.isOn == true)
            {
                myPPLayer.antialiasingMode = PostProcessLayer.Antialiasing.SubpixelMorphologicalAntialiasing;
                toggleAAoFF.isOn = false;
                toggleFXAA.isOn = false;
                toggleTAA.isOn = false;
                antiState = 3;
                PlayerPrefs.SetInt("AAstate", 3);
            }
        }
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void antiAliasingTAA()
    {
        if (antiState != 4)
        {
            if (toggleTAA.isOn == true)
            {
                myPPLayer.antialiasingMode = PostProcessLayer.Antialiasing.TemporalAntialiasing;
                toggleAAoFF.isOn = false;
                toggleFXAA.isOn = false;
                toggleSMAA.isOn = false;
                antiState = 4;
                PlayerPrefs.SetInt("AAstate", 4);
            }
        }
    }

    public void LightValue()
    {
        RenderSettings.ambientIntensity = LightSlider.value;
    }

    public void Visuals()
    {
        VisualPanel.gameObject.SetActive(true);
        SoundPanel.gameObject.SetActive(false);
        HelpPanel.gameObject.SetActive(false);
        TipsPanel.gameObject.SetActive(false);
        DifficultyPanel.gameObject.SetActive(false);
        BackToMenuPanel.gameObject.SetActive(false);
    }

    public void Sounds()
    {
        VisualPanel.gameObject.SetActive(false);
        SoundPanel.gameObject.SetActive(true);
        HelpPanel.gameObject.SetActive(false);
        TipsPanel.gameObject.SetActive(false);
        DifficultyPanel.gameObject.SetActive(false);
        BackToMenuPanel.gameObject.SetActive(false);
    }

    public void Help()
    {
        VisualPanel.gameObject.SetActive(false);
        SoundPanel.gameObject.SetActive(false);
        HelpPanel.gameObject.SetActive(true);
        TipsPanel.gameObject.SetActive(false);
        DifficultyPanel.gameObject.SetActive(false);
        BackToMenuPanel.gameObject.SetActive(false);
    }

    public void Tips()
    {
        VisualPanel.gameObject.SetActive(false);
        SoundPanel.gameObject.SetActive(false);
        HelpPanel.gameObject.SetActive(false);
        TipsPanel.gameObject.SetActive(true);
        DifficultyPanel.gameObject.SetActive(false);
        BackToMenuPanel.gameObject.SetActive(false);
    }

    public void Difficulty()
    {
        VisualPanel.gameObject.SetActive(false);
        SoundPanel.gameObject.SetActive(false);
        HelpPanel.gameObject.SetActive(false);
        TipsPanel.gameObject.SetActive(false);
        DifficultyPanel.gameObject.SetActive(true);
        BackToMenuPanel.gameObject.SetActive(false);
    }

    public void BackToMenu()
    {
        VisualPanel.gameObject.SetActive(false);
        SoundPanel.gameObject.SetActive(false);
        HelpPanel.gameObject.SetActive(false);
        TipsPanel.gameObject.SetActive(false);
        DifficultyPanel.gameObject.SetActive(false);
        BackToMenuPanel.gameObject.SetActive(true);
    }
}
