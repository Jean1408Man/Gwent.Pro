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
    internal class CompilationMaster: MonoBehaviour
    {
        SavedData data;
        private void Start()
        {
            data = GameObject.Find("SoundManager").GetComponent<SavedData>();
        }
        public TMP_InputField Path;
        public string FilePath1 = @"C:\Users\luisj\Desktop\Compiler\Gwent-Compiler\Input.txt";
        public string FilePath2 = @"C:\Users\luisj\Desktop\Compiler\Gwent-Compiler\Input.txt";
        public void Simulation()
        {
            currentPlayer = 1;
            data.faction_1 = 4;
            data.name_1 = "Jean";
            Compile();
            currentPlayer = 2;
            data.faction_2 = 4;
            data.name_2 = "Deiny";
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
            List<ICard> Real;
            bool Downboard;
            try
            {
                if (currentPlayer == 1)//Agregar aqui logica de solo compilar si rellenaste nombre, para debugear puede permanecer asi
                {
                    Temporal = Compiler.Compile(FilePath1);
                    data.CartasCompiladas1 = new List<ICard>();
                    Real = data.CartasCompiladas1;
                    Downboard = true;
                }
                else
                {
                    Temporal = Compiler.Compile(FilePath2);
                    data.CartasCompiladas2 = new List<ICard>();
                    Real = data.CartasCompiladas2;
                    Downboard = false;
                }


                if (Temporal != null)
                {
                    bool leaderin = false;
                    foreach (ICard card in Temporal)
                    {
                        Card generated = GenerateCard(card, Downboard);
                        if (generated.TypeInterno == "L")
                        {
                            if (leaderin)
                                throw new Exception("You've declared at least two leaders");
                            else
                                leaderin = true;
                        }
                        Real.Add(generated);
                    }
                }

                CompilerErrors.GetComponent<TextMeshProUGUI>().text = "Cartas compiladas correctamente";

            }
            catch (Exception ex)
            {
                CompilerErrors.GetComponent<TextMeshProUGUI>().text = ex.Message;
            }
            EvaluateUtils.Restart();

        }


        public GameObject CompilerErrors;


        private Card GenerateCard(ICard card, bool DownBoard)
        {
            #region Finding Out Type Unit
            TypeUnit unit = TypeUnit.None;
            string eff = "None";
            string Type = "";


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
                case "Señuelo":
                    unit = TypeUnit.Silver;
                    Type = "D";
                    eff = "Decoy";
                    break;
                case "Aumento":
                    unit = TypeUnit.None;
                    foreach (char c in card.Range)
                    {
                        Type += "A" + c;
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
                default:
                    throw new Exception($"El Tipo: {card.Type} no est� definido en las reglas del juego");
            }
            #endregion
            if (Type == "C" || Type.IndexOf("A") != -1 || Type == "L" || eff == "Light" || Type == "D")
            {
                if (card.Power != 0)
                {
                    throw new Exception($"Las cartas: {card.Type} deben tener poder 0");
                }
                if (Type == "L" || eff == "Light" || Type == "D")
                {
                    if (!(card.Range == ""))
                        throw new Exception($"Las cartas de tipo {card.Type} no deben declarar rango, o este debe ser vacío");
                }
                else
                    if (card.Range == "")
                    throw new Exception($"Las cartas de tipo {card.Type} deben declarar rango, de lo contrario no será posible su uso");
            }
            else
            {
                if (card.Range == "")
                    throw new Exception($"Las cartas de tipo {card.Type} deben declarar rango, de lo contrario no será posible su uso");
            }
            Card UnityCard = new(DownBoard, card.Name, -1, card.Power, "Compilada", null, unit, Type, eff, card.Range, null, true, card.Type);
            UnityCard.Effects = card.Effects;
            UnityCard.OnConstruction = true;
            UnityCard.Faction = card.Faction;
            UnityCard.OnConstruction = false;
            return UnityCard;
        }


        public void ClearConsole()
        {
            CompilerErrors.GetComponent<TextMeshProUGUI>().text = "";
        }

    }

}

