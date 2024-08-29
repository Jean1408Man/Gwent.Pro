using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LogicalSide;
using System;

namespace LogicalSide 
{ 
    public class CardDataBase: MonoBehaviour
    {

        private void Start() 
        {
            Icons= new Dictionary<string, Sprite>
            {
                {"Ingenieros Celestiales",Resources.Load<Sprite>("Icono")},
                {"Aliens Elementales",Resources.Load<Sprite>("Aliens")},
                {"Mixto",Resources.Load<Sprite>("Mixto")},
                {"Compilado",Resources.Load<Sprite>("Diseño compi")},
            };
            Fondos= new Sprite[]
            {
                Resources.Load<Sprite>("Plantilla1"),
                Resources.Load<Sprite>("Plantilla2"),
                Resources.Load<Sprite>("Plantilla Compilada"),
                Resources.Load<Sprite>("Plantilla G"),
                Resources.Load<Sprite>("Plantilla Aumento"),
                Resources.Load<Sprite>("Plantilla Clima"),
                Resources.Load<Sprite>("Plantilla Leader"),
                Resources.Load<Sprite>("Plantilla Decoy"),
                Resources.Load<Sprite>("Plantilla Mixto")
            };
            ArtWorks = new string[]
            {
                "0", "1", "_03", "4", "6", "7", "9", "11", "12", "13", "14","15","17", "19","20", "22", "23",
                "_01", "_02", "_04", "_05", "_06", "_07", "_08", "_09", "_10", "serpiente", "_12", "_13", "_14", "_15", "_16", "_17", "_18", "_19", "_20"
            };
        }
        private static Dictionary<string,Sprite> Icons;
        private static Sprite[] Fondos;
        private static string[] ArtWorks;
        
        public static List<ICard> GetDeck(Player P)
        {
            //Celestials
            List<ICard> Deck = new();
            if (P.faction == "Ingenieros Celestiales")
            {
                #region Ingenieros
                Deck.Add(new Card(P.Turn, "Alarion", 0, 0, "Te permite robar una carta extra por ronda", P, TypeUnit.None, "L", "Planet", "", Resources.Load<Sprite>("0"), true, "Lider"));
                Deck.Add(new Card(P.Turn, "Arqueros Espaciales", 1, 4, "No tienen efecto especial", P, TypeUnit.Silver, "U", "None", "R" + "S", Resources.Load<Sprite>("1"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Arqueros Espaciales", 2, 4, "No tienen efecto especial", P, TypeUnit.Silver, "U", "None", "R" + "S", Resources.Load<Sprite>("1"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Campo Gravitatorio", 3, 0, "Carta clima, afecta a Cuerpo a Cuerpo", P, TypeUnit.None, "C", "Weather", "M", Resources.Load<Sprite>("_03"), true, "Clima"));
                Deck.Add(new Card(P.Turn, "Catapulta de Estrellas", 4, 8, "Arma de gran rango", P, TypeUnit.Silver, "U", "None", "S", Resources.Load<Sprite>("4"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Catapulta de Estrellas", 5, 8, "Arma de gran rango", P, TypeUnit.Silver, "U", "None", "S", Resources.Load<Sprite>("4"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Cientifico Nebular", 6, 3, "Pone un clima en su zona", P, TypeUnit.Golden, "U", "Weather", "S", Resources.Load<Sprite>("6"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Clon de Combate", 7, 3, "Su poder incrementa en presencia de otro clon", P, TypeUnit.Silver, "U", "Colmena", "M", Resources.Load<Sprite>("7"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Clon de Combate", 8, 3, "Su poder incrementa en presencia de otro clon", P, TypeUnit.Silver, "U", "Colmena", "M", Resources.Load<Sprite>("7"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Dragon Espacial", 9, 3, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "M" + "R", Resources.Load<Sprite>("9"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Dragon Espacial", 10, 3, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "M" + "R", Resources.Load<Sprite>("9"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Estrella Binaria", 11, 3, "Genera confusi�n en tu adversario, permite robar una carta", P, TypeUnit.Silver, "U", "Steal", "R" + "S", Resources.Load<Sprite>("11"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Guardian", 12, 3, "Elimina la carta de mayor Poder", P, TypeUnit.Golden, "U", "Most Pwr", "M", Resources.Load<Sprite>("12"), true, "Oro"));
                Deck.Add(new Card(P.Turn, "Ingeniero Estelar", 13, 3, "Eliminar� la carta m�s d�bil", P, TypeUnit.Golden, "U", "Less Pwr", "S", Resources.Load<Sprite>("13"), true, "Oro"));
                Deck.Add(new Card(P.Turn, "Mago del Tiempo", 14, 3, "Iguala el poder d todas las cartas al promedio entre ellas", P, TypeUnit.Silver, "U", "Media", "R" + "S", Resources.Load<Sprite>("14"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Mago Tecnologico", 15, 3, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "M" + "R", Resources.Load<Sprite>("15"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Mago Tecnologico", 16, 3, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "M" + "R", Resources.Load<Sprite>("15"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Nave de Sacrificio", 17, 0, "Efecto Se�uelo,puedes cambiarla por cualquiera que hayas jugado", P, TypeUnit.None, "D", "Decoy", "", Resources.Load<Sprite>("17"), true, "Señuelo"));
                Deck.Add(new Card(P.Turn, "Nebulosa Energetica", 18, 0, "Carta Clima, afecta Distancia", P, TypeUnit.None, "C", "Weather", "R", Resources.Load<Sprite>("_14"), true, "Clima"));
                Deck.Add(new Card(P.Turn, "Tecnologo Cuantico", 19, 3, "Limpia la zona con menos unidades", P, TypeUnit.Silver, "U", "Zone Cleaner", "M" + "R" + "S", Resources.Load<Sprite>("19"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Tonico Espacial", 20, 0, "Carta Aumento, act�a sobre Distancia", P, TypeUnit.None, "AR", "Raise", "R", Resources.Load<Sprite>("20"), true, "Aumento"));
                Deck.Add(new Card(P.Turn, "Tormenta de Gusano", 21, 0, "Carta Clima, afecta a Asedio", P, TypeUnit.None, "C", "Weather", "S", Resources.Load<Sprite>("_17"), true, "Clima"));
                Deck.Add(new Card(P.Turn, "Espada Laser", 22, 0, "Carta Aumento, act�a sobre Cuerpo a Cuerpo", P, TypeUnit.None, "AM", "Raise", "M", Resources.Load<Sprite>("22"), true, "Aumento"));
                Deck.Add(new Card(P.Turn, "Bendicion de Houla", 23, 0, "Carta Aumento, act�a sobre Asedio", P, TypeUnit.None, "AS", "Raise", "S", Resources.Load<Sprite>("23"), true, "Aumento"));
                Deck.Add(new Card(P.Turn, "Luz", 24, 0, "Despeja todo el mal tiempo de la Batalla", P, TypeUnit.None, "C", "Light", "", Resources.Load<Sprite>("_20"), true, "Despeje"));

                Debug.Log("Cartas a�adidas");
                #endregion
                P.Stealer = true;
            }
            else if(P.faction=="Aliens Elementales")
            {
                #region Aliens
                Deck.Add(new Card(P.Turn, "Magnus", 0, 0, "Permite conservar una carta en el campo luego de un turno", P, TypeUnit.None, "L", "Planet", "", Resources.Load<Sprite>("_01"), true, "Lider"));
                Deck.Add(new Card(P.Turn, "Meteoro", 1, 4, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "R" + "S", Resources.Load<Sprite>("_02"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Meteoro", 2, 4, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "R" + "S", Resources.Load<Sprite>("_02"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Campo Gravitatorio", 3, 0, "Carta Clima, afecta a Cuerpo a Cuerpo", P, TypeUnit.None, "C", "Weather", "M", Resources.Load<Sprite>("_03"), true, "Clima"));
                Deck.Add(new Card(P.Turn, "Razor", 4, 8, "Arma de gran rango", P, TypeUnit.Silver, "U", "None", "S", Resources.Load<Sprite>("_04"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Razor", 5, 8, "Arma de gran rango", P, TypeUnit.Silver, "U", "None", "S", Resources.Load<Sprite>("_04"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Desintegrador", 6, 3, "Efecto Clima, afecta a Asedio", P, TypeUnit.Silver, "U", "Weather", "S", Resources.Load<Sprite>("_05"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Multibrazos", 7, 3, "Su poder incrementa en presencia de otro Multibrazos", P, TypeUnit.Silver, "U", "Colmena", "M" + "R", Resources.Load<Sprite>("_07"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Multibrazos", 8, 3, "Su poder incrementa en presencia de otro Multibrazos", P, TypeUnit.Silver, "U", "Colmena", "M"+ "R", Resources.Load<Sprite>("_07"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Reptil Lunar", 9, 3, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "S" + "R", Resources.Load<Sprite>("_21"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Reptil Lunar", 10, 3, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "S" + "R", Resources.Load<Sprite>("_21"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Laura", 11, 3, "Genera confusi�n en tu adversario, permite robar una carta", P, TypeUnit.Silver, "U", "Steal", "R" + "S", Resources.Load<Sprite>("_08"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Golem", 12, 3, "Elimina la carta de mayor Poder", P, TypeUnit.Golden, "U", "Most Pwr", "M", Resources.Load<Sprite>("_06"), true, "Oro"));
                Deck.Add(new Card(P.Turn, "Espectro de Fuego", 13, 3, "Elimina la carta m�s d�bil", P, TypeUnit.Golden, "U", "Less Pwr", "M", Resources.Load<Sprite>("_09"), true, "Oro"));
                Deck.Add(new Card(P.Turn, "Pulpo de Yud", 14, 3, "Iguala el poder d todas las cartas al promedio entre ellas", P, TypeUnit.Silver, "U", "Media", "S", Resources.Load<Sprite>("_10"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Serpiente de Zitharus", 15, 3, "No tiene efecto especial", P, TypeUnit.Golden, "U", "None", "R" + "S", Resources.Load<Sprite>("serpiente"), true, "Oro"));
                Deck.Add(new Card(P.Turn, "Fenrir", 16, 3, "Carta de campo, con efecto Aumento", P, TypeUnit.Silver, "U", "Raise", "M" + "R", Resources.Load<Sprite>("_12"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Teletransportador", 17, 0, "Efecto Se�uelo,puedes cambiarla por cualquiera que hayas jugado", P, TypeUnit.None, "D", "Decoy", "", Resources.Load<Sprite>("_13"), true, "Señuelo"));
                Deck.Add(new Card(P.Turn, "Nebulosa Energ�tica", 18, 0, "Carta Clima, afecta a Distancia", P, TypeUnit.None, "C", "Weather", "R"+"S", Resources.Load<Sprite>("_14"), true, "Clima"));
                Deck.Add(new Card(P.Turn, "Los Trillizos", 19, 3, "Limpia la zona con menos unidades", P, TypeUnit.Silver, "U", "Zone Cleaner", "M" + "R" + "S", Resources.Load<Sprite>("_15"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Tonico Espacial", 20, 0, "Carta Aumento, act�a sobre Distancia", P, TypeUnit.None, "AR", "Raise", "M", Resources.Load<Sprite>("_16"), true, "Aumento"));
                Deck.Add(new Card(P.Turn, "Tormenta de Gusano", 21, 0, "Carta Clima, afecta a Asedio", P, TypeUnit.None, "C", "Weather", "S"+"M", Resources.Load<Sprite>("_17"), true, "Clima"));
                Deck.Add(new Card(P.Turn, "Espada Laser", 22, 0, "Carta Aumento, act�a sobre Cuerpo a Cuerpo", P, TypeUnit.None, "AM", "Raise", "M"+"R", Resources.Load<Sprite>("_18"), true, "Aumento"));
                Deck.Add(new Card(P.Turn, "Bendicion de Houla", 23, 0, "Carta Aumento, act�a sobre Asedio", P, TypeUnit.None, "AS", "Raise", "S"+ "R", Resources.Load<Sprite>("_19"), true, "Clima"));
                Deck.Add(new Card(P.Turn, "Luz", 24, 0, "Despeja todo el mal tiempo de la Batalla",P, TypeUnit.None, "C", "Light", "", Resources.Load<Sprite>("_20"), true, "Despeje"));
                

                Debug.Log("Cartas a�adidas");
                #endregion
                P.RandomizedNotRem = true;
            }
            else
            {
                #region Mixto
                Deck.Add(new Card(P.Turn, "Magnus", 0, 0, "Si empatas la ronda ganas", P, TypeUnit.None, "L", "Planet", "", Resources.Load<Sprite>("_01"), true, "Lider"));
                Deck.Add(new Card(P.Turn, "Arqueros Espaciales", 1, 4, "No tienen efecto especial", P, TypeUnit.Silver, "U", "None", "R" + "S", Resources.Load<Sprite>("1"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Meteoro", 2, 4, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "R" + "S", Resources.Load<Sprite>("_02"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Campo Gravitatorio", 3, 0, "Carta Clima, afecta a Cuerpo a Cuerpo", P, TypeUnit.None, "C", "Weather", "M", Resources.Load<Sprite>("_03"), true, "Clima"));
                Deck.Add(new Card(P.Turn, "Razor", 4, 8, "Arma de gran rango", P, TypeUnit.Silver, "U", "None", "S", Resources.Load<Sprite>("_04"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Catapulta de Estrellas", 5, 8, "Arma de gran rango", P, TypeUnit.Silver, "U", "None", "S", Resources.Load<Sprite>("4"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Cientifico Nebular", 6, 3, "Pone un clima en su zona", P, TypeUnit.Golden, "U", "Weather", "S", Resources.Load<Sprite>("6"), true, "Oro"));
                Deck.Add(new Card(P.Turn, "Multibrazos", 7, 3, "Su poder incrementa en presencia de otro Multibrazos", P, TypeUnit.Silver, "U", "Colmena", "M" + "R", Resources.Load<Sprite>("_07"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Multibrazos", 8, 3, "Su poder incrementa en presencia de otro Multibrazos", P, TypeUnit.Silver, "U", "Colmena", "M" + "R", Resources.Load<Sprite>("_07"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Dragon Espacial", 9, 3, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "M" + "R", Resources.Load<Sprite>("9"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Dragon Espacial", 10, 3, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "M" + "R", Resources.Load<Sprite>("9"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Laura", 11, 3, "Genera confusi�n en tu adversario, permite robar una carta", P, TypeUnit.Silver, "U", "Steal", "R" + "S", Resources.Load<Sprite>("_08"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Golem", 12, 3, "Elimina la carta de mayor Poder", P, TypeUnit.Golden, "U", "Most Pwr", "M", Resources.Load<Sprite>("_06"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Ingeniero Estelar", 13, 3, "Eliminar� la carta m�s d�bil", P, TypeUnit.Golden, "U", "Less Pwr", "S", Resources.Load<Sprite>("13"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Mago del Tiempo", 14, 3, "Iguala el poder d todas las cartas al promedio entre ellas", P, TypeUnit.Silver, "U", "Media", "R" + "S", Resources.Load<Sprite>("14"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Serpiente de Zitharus", 15, 3, "No tiene efecto especial", P, TypeUnit.Golden, "U", "None", "R" + "S", Resources.Load<Sprite>("serpiente"), true, "Oro"));
                Deck.Add(new Card(P.Turn, "Fenrir", 16, 3, "Carta de campo, con efecto Aumento", P, TypeUnit.Silver, "U", "Raise", "M" + "R", Resources.Load<Sprite>("_12"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Nave de Sacrificio", 17, 0, "Efecto Se�uelo,puedes cambiarla por cualquiera que hayas jugado", P, TypeUnit.None, "D", "Decoy", "", Resources.Load<Sprite>("17"), true, "Señuelo"));
                Deck.Add(new Card(P.Turn, "Nebulosa Energetica", 18, 0, "Carta Clima, afecta Distancia", P, TypeUnit.None, "C", "Weather", "R", Resources.Load<Sprite>("_14"), true, "Clima"));
                Deck.Add(new Card(P.Turn, "Los Trillizos", 19, 3, "Limpia la zona con menos unidades", P, TypeUnit.Silver, "U", "Zone Cleaner", "M" + "R" + "S", Resources.Load<Sprite>("_15"), true, "Plata"));
                Deck.Add(new Card(P.Turn, "Tonico Espacial", 20, 0, "Carta Aumento, act�a sobre Distancia", P, TypeUnit.None, "AR", "Raise", "R", Resources.Load<Sprite>("_16"), true, "Aumento"));
                Deck.Add(new Card(P.Turn, "Espada Laser", 22, 0, "Carta Aumento, act�a sobre Cuerpo a Cuerpo", P, TypeUnit.None, "AM", "Raise", "M", Resources.Load<Sprite>("22"), true, "Aumento"));
                Deck.Add(new Card(P.Turn, "Bendicion de Houla", 23, 0, "Carta Aumento, act�a sobre Asedio", P, TypeUnit.None, "AS", "Raise", "S", Resources.Load<Sprite>("_19"), true, "Aumento"));
                Deck.Add(new Card(P.Turn, "Luz", 24, 0, "Despeja todo el mal tiempo de la Batalla", P, TypeUnit.None, "C", "Light", "", Resources.Load<Sprite>("_20"), true, "Despeje"));
                #endregion
                P.AlwaysAWinner= true;
            }
            foreach(Card card in Deck)
            {
                card.OnConstruction = true;
                card.Faction = P.faction;
                card.OnConstruction = false;
            }
            CustomizeDeck(Deck);
            return Deck;
        }

        public static void CustomizeDeck(List<ICard> deck)
        {
            foreach(ICard card in deck)
            {
                CustomizeCard((Card)card);
            }
        }
        public static void CustomizeCard(Card card)
        {
            
            //Icono de Faccion
            card.FactionIcon = Icons[((Player)card.Owner).faction];
            //Fondo
            #region Fondo
            if (card.TypeInterno == "C")
            {
                card.Fondo = Fondos[5];
            }
            else if (card.TypeInterno.IndexOf("A") != -1)
            {
                card.Fondo = Fondos[4];
            }
            else if (card.TypeInterno == "L")
            {
                card.Fondo = Fondos[6];
            }
            else if (card.TypeInterno == "D")
            {
                card.Fondo = Fondos[7];
            }
            else if (card.TypeInterno == "U")
            {
                if (card.unit == TypeUnit.Golden)
                {
                    card.Fondo = Fondos[3];
                }
                else
                {
                    if (card.Faction == "Ingenieros Celestiales")
                    {
                        card.Fondo = Fondos[0];
                    }
                    else if (card.Faction == "Aliens Elementales")
                    {
                        card.Fondo = Fondos[1];
                    }
                    else if (card.Faction == "Mixto")
                    {
                        card.Fondo = Fondos[8];
                    }
                    else
                        card.Fondo = Fondos[2];
                }
            }
            #endregion

        }

        internal static List<ICard> CompleteDeck(List<ICard> cartasCompiladas, Player P)
        {
            List<ICard> Deck = new();
            #region Total de Cartas
            Deck.Add(new Card(P.Turn, "Arqueros Espaciales", 1, 4, "No tienen efecto especial", P, TypeUnit.Silver, "U", "None", "R" + "S", Resources.Load<Sprite>("1"), true, "Plata"));
            Deck.Add(new Card(P.Turn, "Arqueros Espaciales", 2, 4, "No tienen efecto especial", P, TypeUnit.Silver, "U", "None", "R" + "S", Resources.Load<Sprite>("1"), true, "Plata"));
            Deck.Add(new Card(P.Turn, "Campo Gravitatorio", 3, 0, "Carta clima, afecta a Cuerpo a Cuerpo", P, TypeUnit.None, "C", "Weather", "M", Resources.Load<Sprite>("_03"), true, "Clima"));
            Deck.Add(new Card(P.Turn, "Catapulta de Estrellas", 4, 8, "Arma de gran rango", P, TypeUnit.Silver, "U", "None", "S", Resources.Load<Sprite>("4"), true, "Plata"));
            Deck.Add(new Card(P.Turn, "Catapulta de Estrellas", 5, 8, "Arma de gran rango", P, TypeUnit.Silver, "U", "None", "S", Resources.Load<Sprite>("4"), true, "Plata"));
            Deck.Add(new Card(P.Turn, "Cientifico Nebular", 6, 3, "Pone un clima en su zona", P, TypeUnit.Golden, "U", "Weather", "S", Resources.Load<Sprite>("6"), true, "Plata"));
            Deck.Add(new Card(P.Turn, "Clon de Combate", 7, 3, "Su poder incrementa en presencia de otro clon", P, TypeUnit.Silver, "U", "Colmena", "M", Resources.Load<Sprite>("7"), true, "Plata"));
            Deck.Add(new Card(P.Turn, "Clon de Combate", 8, 3, "Su poder incrementa en presencia de otro clon", P, TypeUnit.Silver, "U", "Colmena", "M", Resources.Load<Sprite>("7"), true, "Plata"));
            Deck.Add(new Card(P.Turn, "Dragon Espacial", 9, 3, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "M" + "R", Resources.Load<Sprite>("9"), true, "Plata"));
            Deck.Add(new Card(P.Turn, "Dragon Espacial", 10, 3, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "M" + "R", Resources.Load<Sprite>("9"), true, "Plata"));
            Deck.Add(new Card(P.Turn, "Estrella Binaria", 11, 3, "Genera confusi�n en tu adversario, permite robar una carta", P, TypeUnit.Silver, "U", "Steal", "R" + "S", Resources.Load<Sprite>("11"), true, "Plata"));
            Deck.Add(new Card(P.Turn, "Guardian", 12, 3, "Elimina la carta de mayor Poder", P, TypeUnit.Golden, "U", "Most Pwr", "M", Resources.Load<Sprite>("12"), true, "Oro"));
            Deck.Add(new Card(P.Turn, "Ingeniero Estelar", 13, 3, "Eliminar� la carta m�s d�bil", P, TypeUnit.Golden, "U", "Less Pwr", "S", Resources.Load<Sprite>("13"), true, "Oro"));
            Deck.Add(new Card(P.Turn, "Mago del Tiempo", 14, 3, "Iguala el poder d todas las cartas al promedio entre ellas", P, TypeUnit.Silver, "U", "Media", "R" + "S", Resources.Load<Sprite>("14"), true, "Plata"));
            Deck.Add(new Card(P.Turn, "Mago Tecnologico", 15, 3, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "M" + "R", Resources.Load<Sprite>("15"), true, "Plata"));
            Deck.Add(new Card(P.Turn, "Mago Tecnologico", 16, 3, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "M" + "R", Resources.Load<Sprite>("15"), true, "Plata"));
            Deck.Add(new Card(P.Turn, "Nave de Sacrificio", 17, 0, "Efecto Se�uelo,puedes cambiarla por cualquiera que hayas jugado", P, TypeUnit.None, "D", "Decoy", "M" + "R" + "S", Resources.Load<Sprite>("17"), true, "Señuelo"));
            Deck.Add(new Card(P.Turn, "Nebulosa Energetica", 18, 0, "Carta Clima, afecta Distancia", P, TypeUnit.None, "C", "Weather", "R", Resources.Load<Sprite>("_14"), true, "Clima"));
            Deck.Add(new Card(P.Turn, "Tecnologo Cuantico", 19, 3, "Limpia la zona con menos unidades", P, TypeUnit.Silver, "U", "Zone Cleaner", "M" + "R" + "S", Resources.Load<Sprite>("19"), true, "Plata"));
            Deck.Add(new Card(P.Turn, "Tonico Espacial", 20, 0, "Carta Aumento, act�a sobre Distancia", P, TypeUnit.None, "AR", "Raise", "R", Resources.Load<Sprite>("20"), true, "Aumento"));
            Deck.Add(new Card(P.Turn, "Tormenta de Gusano", 21, 0, "Carta Clima, afecta a Asedio", P, TypeUnit.None, "C", "Weather", "S", Resources.Load<Sprite>("_17"), true, "Clima"));
            Deck.Add(new Card(P.Turn, "Espada Laser", 22, 0, "Carta Aumento, act�a sobre Cuerpo a Cuerpo", P, TypeUnit.None, "AM", "Raise", "M", Resources.Load<Sprite>("22"), true, "Aumento"));
            Deck.Add(new Card(P.Turn, "Bendicion de Houla", 23, 0, "Carta Aumento, act�a sobre Asedio", P, TypeUnit.None, "AS", "Raise", "S", Resources.Load<Sprite>("23"), true, "Aumento"));
            Deck.Add(new Card(P.Turn, "Luz", 24, 0, "Despeja todo el mal tiempo de la Batalla", P, TypeUnit.None, "C", "Light", "M" + "R" + "S", Resources.Load<Sprite>("_20"), true, "Despeje"));
            Deck.Add(new Card(P.Turn, "Meteoro", 1, 4, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "R" + "S", Resources.Load<Sprite>("_02"), true, "Plata"));
            Deck.Add(new Card(P.Turn, "Meteoro", 2, 4, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "R" + "S", Resources.Load<Sprite>("_02"), true, "Plata"));
            Deck.Add(new Card(P.Turn, "Campo Gravitatorio", 3, 0, "Carta Clima, afecta a Cuerpo a Cuerpo", P, TypeUnit.None, "C", "Weather", "M", Resources.Load<Sprite>("_03"), true, "Clima"));
            Deck.Add(new Card(P.Turn, "Razor", 4, 8, "Arma de gran rango", P, TypeUnit.Silver, "U", "None", "S", Resources.Load<Sprite>("_04"), true, "Plata"));
            Deck.Add(new Card(P.Turn, "Razor", 5, 8, "Arma de gran rango", P, TypeUnit.Silver, "U", "None", "S", Resources.Load<Sprite>("_04"), true, "Plata"));
            Deck.Add(new Card(P.Turn, "Desintegrador", 6, 3, "Efecto Clima, afecta a Asedio", P, TypeUnit.Silver, "U", "Weather", "S", Resources.Load<Sprite>("_05"), true, "Plata"));
            Deck.Add(new Card(P.Turn, "Multibrazos", 7, 3, "Su poder incrementa en presencia de otro Multibrazos", P, TypeUnit.Silver, "U", "Colmena", "M" + "R", Resources.Load<Sprite>("_07"), true, "Plata"));
            Deck.Add(new Card(P.Turn, "Multibrazos", 8, 3, "Su poder incrementa en presencia de otro Multibrazos", P, TypeUnit.Silver, "U", "Colmena", "M"+ "R", Resources.Load<Sprite>("_07"), true, "Plata"));
            Deck.Add(new Card(P.Turn, "Reptil Lunar", 9, 3, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "S" + "R", Resources.Load<Sprite>("_21"), true, "Plata"));
            Deck.Add(new Card(P.Turn, "Reptil Lunar", 10, 3, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "S" + "R", Resources.Load<Sprite>("_21"), true, "Plata"));
            Deck.Add(new Card(P.Turn, "Laura", 11, 3, "Genera confusi�n en tu adversario, permite robar una carta", P, TypeUnit.Silver, "U", "Steal", "R" + "S", Resources.Load<Sprite>("_08"), true, "Plata"));
            Deck.Add(new Card(P.Turn, "Golem", 12, 3, "Elimina la carta de mayor Poder", P, TypeUnit.Golden, "U", "Most Pwr", "M", Resources.Load<Sprite>("_06"), true, "Oro"));
            Deck.Add(new Card(P.Turn, "Espectro de Fuego", 13, 3, "Elimina la carta m�s d�bil", P, TypeUnit.Golden, "U", "Less Pwr", "M", Resources.Load<Sprite>("_09"), true, "Oro"));
            Deck.Add(new Card(P.Turn, "Pulpo de Yud", 14, 3, "Iguala el poder d todas las cartas al promedio entre ellas", P, TypeUnit.Silver, "U", "Media", "S", Resources.Load<Sprite>("_10"), true, "Plata"));
            Deck.Add(new Card(P.Turn, "Serpiente de Zitharus", 15, 3, "No tiene efecto especial", P, TypeUnit.Golden, "U", "None", "R" + "S", Resources.Load<Sprite>("serpiente"), true, "Oro"));
            Deck.Add(new Card(P.Turn, "Fenrir", 16, 3, "Carta de campo, con efecto Aumento", P, TypeUnit.Silver, "U", "Raise", "M" + "R", Resources.Load<Sprite>("_12"), true, "Plata"));
            Deck.Add(new Card(P.Turn, "Teletransportador", 17, 0, "Efecto Se�uelo,puedes cambiarla por cualquiera que hayas jugado", P, TypeUnit.None, "D", "Decoy", "M" + "R" + "S", Resources.Load<Sprite>("_13"), true, "Señuelo"));
            Deck.Add(new Card(P.Turn, "Nebulosa Energ�tica", 18, 0, "Carta Clima, afecta a Distancia", P, TypeUnit.None, "C", "Weather", "R"+"S", Resources.Load<Sprite>("_14"), true, "Clima"));
            Deck.Add(new Card(P.Turn, "Los Trillizos", 19, 3, "Limpia la zona con menos unidades", P, TypeUnit.Silver, "U", "Zone Cleaner", "M" + "R" + "S", Resources.Load<Sprite>("_15"), true, "Plata"));
            Deck.Add(new Card(P.Turn, "Tonico Espacial", 20, 0, "Carta Aumento, act�a sobre Distancia", P, TypeUnit.None, "AM", "Raise", "M", Resources.Load<Sprite>("_16"), true, "Aumento"));
            Deck.Add(new Card(P.Turn, "Tormenta de Gusano", 21, 0, "Carta Clima, afecta a Asedio", P, TypeUnit.None, "C", "Weather", "S", Resources.Load<Sprite>("_17"), true, "Clima"));
            Deck.Add(new Card(P.Turn, "Espada Laser", 22, 0, "Carta Aumento, act�a sobre Cuerpo a Cuerpo", P, TypeUnit.None, "AMAR", "Raise", "M"+"R", Resources.Load<Sprite>("_18"), true, "Aumento"));
            Deck.Add(new Card(P.Turn, "Bendicion de Houla", 23, 0, "Carta Aumento, act�a sobre Asedio", P, TypeUnit.None, "ASAR", "Raise", "S"+ "R", Resources.Load<Sprite>("_19"), true, "Clima"));
            Deck.Add(new Card(P.Turn, "Luz", 24, 0, "Despeja todo el mal tiempo de la Batalla",P, TypeUnit.None, "C", "Light", "", Resources.Load<Sprite>("_20"), true, "Despeje"));
            #endregion


            List<ICard> Result = new();
            bool leader= false;
            foreach(ICard Card in cartasCompiladas)
            {
                Card card = (Card)Card;
                card.OnConstruction = true;
                if (card.TypeInterno=="L")
                {
                    leader = true;
                }
                card.Owner= P;
                AssignImage(card);
                Result.Add(card);
                card.OnConstruction = false;
            }
            if (!leader)
            {
                Result.Insert(0, GiveMeLeader(P));
            }
            System.Random random = new System.Random();
            int index;
            while (Result.Count < 25)
            {
                index= random.Next(1, Deck.Count-1);
                Card card = (Card)Deck[index];
                card.OnConstruction = true;
                Deck.RemoveAt(index);
                card.Faction = "Compilada";
                card.OnConstruction = false;
                if (Result.Count > 2)
                    Result.Insert(1, card);
                else
                    Result.Add(card);
            }
            CustomizeDeck(Result);
            return Result;
        }

        private static Card GiveMeLeader(Player P)
        {
            System.Random random = new System.Random();
            List<Card> Leaders = new List<Card>()
            {
                new Card(P.Turn, "Alarion", 0, 0, "Te permite robar una carta extra por ronda", P, TypeUnit.None, "L", "Planet", "", Resources.Load<Sprite>("0"), true, "Lider"),
                new Card(P.Turn, "Magnus", 0, 0, "Si empatas la ronda ganas", P, TypeUnit.None, "L", "Planet", "", Resources.Load<Sprite>("_01"), true, "Lider")
            };
            Card leader= Leaders[random.Next(0, Leaders.Count - 1)];
            if (leader.Name == "Alarion")
                P.Stealer = true;
            else
                P.RandomizedNotRem = true;
            return leader;
        }

        private static void AssignImage(Card card)
        {
            if (card.Artwork == null)
            {
                System.Random random = new System.Random();
                int art= random.Next(0, ArtWorks.Length - 1);
                card.Artwork = Resources.Load<Sprite>(ArtWorks[art]);
            }
        }
        
    }

    

}
