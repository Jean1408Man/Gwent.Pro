using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuGM : MonoBehaviour
{
    [Header("Options")]
    public Slider Volume;
    public Slider VolumeFX;
    public AudioMixer mixer;
    [Header("Panels")]
    public GameObject MainPanel;
    public GameObject OptionsPanel;
    public GameObject PanelP1;
    public GameObject PanelP2;
    public AudioClip ClickSound;
    public AudioClip ErrorSound;
    public AudioSource FXsource;
    private void Awake()
    {
        Volume.onValueChanged.AddListener(ChangeVolumeMaster);
        VolumeFX.onValueChanged.AddListener(ChangeVolumeFX);
    }
    public void OpenPanel(GameObject panel)
    {
        MainPanel.SetActive(false);
        OptionsPanel.SetActive(false);
        PanelP1.SetActive(false);
        PanelP2.SetActive(false);
        
        panel.SetActive(true);
        PlaySoundButton();
    }
    
    public void ChangeVolumeMaster(float volume)
    {
        mixer.SetFloat("VolMaster", volume);
    }
    public void ChangeVolumeFX(float volume)
    {
        mixer.SetFloat("VolFX", volume);
    }
    public void PlaySoundButton()
    {
        FXsource.PlayOneShot(ClickSound);
    }
    public void PlayError()
    {
        FXsource.PlayOneShot(ErrorSound);
    }
}
