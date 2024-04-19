using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using LogicalSide;
using TMPro;
using Unity.VisualScripting;

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
    public SavedData SoundGM;
    public GameObject ButtonCelestial2;
    public GameObject ButtonAliens2;
    public GameObject ButtonAliens1;
    public GameObject ButtonCelestial1;
    public GameObject Mixto1;
    public GameObject Mixto2;
    private void Awake()
    {
        Volume.onValueChanged.AddListener(ChangeVolumeMaster);
        VolumeFX.onValueChanged.AddListener(ChangeVolumeFX);
        FXsource = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        SoundGM = GameObject.Find("SoundManager").GetComponent<SavedData>();
        FXsource = SoundGM.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(MainPanel.activeSelf)
            {
                MainPanel.SetActive(false);
            }
            else
            OpenPanel(MainPanel);
        }
    }

    public void OpenPanel(GameObject panel)
    {
        MainPanel.SetActive(false);
        OptionsPanel.SetActive(false);
        if(PanelP1 != null)
        PanelP1.SetActive(false);
        if(PanelP2 != null)
        PanelP2.SetActive(false);
        
        panel.SetActive(true);
        PlaySoundButton();
        if (panel == PanelP1)
            SoundGM.Name1= GameObject.Find("Name1").GetComponent<TMP_InputField>();
        else if (panel == PanelP2)
            SoundGM.Name2 = GameObject.Find("Name2").GetComponent<TMP_InputField>();
    }
    public void NextBtn(GameObject Panel)
    {//Llamado si se termina con exito el primer Player
        if (SoundGM.faction_1 != 0 && SoundGM.name_1 != "")
            OpenPanel(Panel);
        else
            PlayError();
    }
    public void Play(bool debug)
    {
        if ((SoundGM.faction_2 != 0 && SoundGM.name_2 != ""))
            SceneManager.LoadScene(1);
        else if (debug)
        {
            SoundGM.debug = true;
            SceneManager.LoadScene(1);
        }
        else
            PlayError();
    }
    public void Faction2OnClick(int Faction)
    {
        SoundGM.faction_2 = Faction;
        if(Faction == 1)
        {
            ButtonCelestial2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icono1");
            ButtonAliens2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Aliens");
            ButtonAliens2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Mixto");
        }
        else if (Faction == 2)
        {
            ButtonCelestial2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icono");
            ButtonAliens2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Aliens1");
            ButtonAliens2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Mixto");
        }
        else if (Faction == 3)
        {
            ButtonCelestial2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icono");
            ButtonAliens2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Aliens");
            ButtonAliens2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Mixto1");
        }

    }
    public void Faction1OnClick(int Faction)
    {
        SoundGM.faction_1 = Faction;
        if (Faction == 1)
        {
            ButtonCelestial1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icono1");
            ButtonAliens1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Aliens");
            ButtonAliens1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Mixto");
        }
        else if (Faction == 2)
        {
            ButtonCelestial1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icono");
            ButtonAliens1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Aliens1");
            ButtonAliens1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Mixto");
        }
        else if (Faction == 3)
        {
            ButtonCelestial1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icono");
            ButtonAliens1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Aliens");
            ButtonAliens1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Mixto1");
        }
    }
    public void NameCompleted(int P)
    {
        if (P == 1)
        {
            SoundGM.name_1 = SoundGM.Name1.text;
        }
        else
        {
            SoundGM.name_2 = SoundGM.Name2.text;
        }
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
    public void GoToMain()
    {
        SceneManager.LoadScene(0);
    }
    void HandleKeyPressed(KeyCode key)
    {
        if (key == KeyCode.Escape)
        {
            // Aquí puedes agregar la lógica que deseas ejecutar cuando se presiona Escape
            Debug.Log("Se presionó la tecla Escape");
        }
    }
}
