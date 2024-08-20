using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.CodeDom.Compiler;
using JetBrains.Annotations;

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
        public TMP_InputField Path;
        public bool debug = false;

        public List<Card> CartasCompiladas1;
        public string FilePath1 = @"C:\Users\luisj\Desktop\Compiler\Gwent-Compiler\Input.txt";
        public string FilePath2 = @"C:\Users\luisj\Desktop\Compiler\Gwent-Compiler\Input.txt";
        public List<Card> CartasCompiladas2;

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
        }

        public void Simulation()
        {
            currentPlayer = 1;
            faction_1 = 4;
            name_1 = "Jean";
            Compile();
            currentPlayer = 2;
            faction_2 = 4;
            name_2 = "Deiny";
            Compile();
        }

        public int currentPlayer;
        public void SetCurrent(int player)
        {
            currentPlayer = player;
        }
        public void PathCompleted()
        {
            if (currentPlayer == 1)
            {
                FilePath1 = Path.text;
            }
            else
            {
                FilePath2 = Path.text;
            }
        }
        public void Compile()
        {
            List<ICard> Temporal;
            List<Card> Real;
            bool Downboard;
            try
            {
                if (currentPlayer == 1)//Agregar aqui logica de solo compilar si rellenaste nombre, para debugear puede permanecer asi
                {
                    Temporal = Compiler.Compile(FilePath1);
                    CartasCompiladas1 = new List<Card>();
                    Real = CartasCompiladas1;
                    Downboard = true;
                }
                else
                {
                    Temporal = Compiler.Compile(FilePath2);
                    CartasCompiladas2 = new List<Card>();
                    Real = CartasCompiladas2;
                    Downboard = false;
                } 
           
            EvaluateUtils.Restart();
            if(Temporal != null)
            {
                bool leaderin = false;
                foreach(ICard card in Temporal)
                {
                    Card generated = GenerateCard(card, Downboard);
                    if(generated.Type== "L")
                    {
                        if (leaderin)
                            throw new Exception("You've declared at least two leaders");
                        else
                            leaderin = true;
                    }
                    Real.Add(generated);
                }
            }
            }
            catch (Exception ex)
            {
                CompilerErrors.GetComponent<TextMeshProUGUI>().text = ex.Message; return;
            }
        }


        public GameObject CompilerErrors;


        private Card GenerateCard(ICard card, bool DownBoard)
        {
            #region Finding Out Type Unit
            TypeUnit unit = TypeUnit.None;
            string eff = "None";
            string Type="";
            

            switch (card.Type)
            {
                case "Clima":
                    Type = "C";
                    eff = "Weather";
                    break;
                case "Plata":
                    unit = TypeUnit.Silver;
                    Type = "U";
                    break;
                case "Oro":
                    unit = TypeUnit.Golden;
                    Type = "U";
                    break;
                case "Aumento":
                    unit = TypeUnit.None;
                    foreach(char c in card.Range)
                    {
                        Type += "A"+c;
                    }
                    eff = "Raise";
                    break;
                case "Lider":
                    Type = "L";
                    
                    break;
                case "Despeje":
                    Type = "C";
                    eff = "Light";
                    break;
            }
            #endregion
            if(Type == "C"|| Type.IndexOf("A") != -1|| Type == "L")
            {
                if(card.Power!= 0)
                {
                    throw new Exception($"Las cartas: {card.Type} deben tener poder 0");
                }
            }
            Card UnityCard = new(DownBoard, card.Name, -1, card.Power, "Compilada", null, unit, Type, eff, card.Range, null, true);
            UnityCard.Effects= card.Effects;
            UnityCard.OnConstruction = true;
            UnityCard.Faction= card.Faction;
            UnityCard.OnConstruction = false;
            return UnityCard;
        }
        
        
        

    }
    
    
}
