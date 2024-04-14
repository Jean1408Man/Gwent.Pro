using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace LogicalSide
{
    public class SavedData : MonoBehaviour
    {
        public string name_1 = "";
        public string name_2 = "";
        public int faction_1 = 0;
        public int faction_2 = 0;

        public static SavedData Instance;
        public TMP_InputField Name1;
        public TMP_InputField Name2;
        public GameObject PanelP1;
        public GameObject PanelP2;


        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
            GameManager GM = GameObject.Find("Game Manager").GetComponent<GameManager>();
            if (GM != null)
            {
                
            }
        }

        public void Faction2OnClick( int Faction)
        {
            faction_2 = Faction;
        }
        public void Faction1OnClick(int Faction)
        {
            faction_1 = Faction;
        }
        public void NameCompleted(int P)
        {
            if(P==1)
            {
                name_1 = Name1.text;
            }
            else
            {
                name_2 = Name2.text;
            }
        }
        public void NextBtn(GameObject Panel)
        {//Llamado si se termina con exito el primer Player
            if (faction_1 != 0 && name_1 != "")
                gameObject.GetComponent<MenuGM>().OpenPanel(Panel);
            else
                gameObject.GetComponent<MenuGM>().PlayError();
        }
        public void Play()
        {
            if(faction_2 != 0 && name_2 != "")
                SceneManager.LoadScene(1);
            else
                gameObject.GetComponent<MenuGM>().PlayError();
        }

    }
    
    
}
