using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LogicalSide 
{ 
    public class CardDataBase: MonoBehaviour
    {
        public static List<Card> GetDeck(Player P)
        {
            //Celestials
            List<Card> Deck = new();
            if (P.faction == 1)
            {
                #region Ingenieros
                Deck.Add(new Card(P.P, "Alarion", 0, 0, "Te permite robar una carta extra por ronda", P, TypeUnit.None, "L", "Planet", "", Resources.Load<Sprite>("0"), true));
                Deck.Add(new Card(P.P, "Arqueros Espaciales", 1, 4, "No tienen efecto especial", P, TypeUnit.Silver, "U", "None", "R" + "S", Resources.Load<Sprite>("1"), true));
                Deck.Add(new Card(P.P, "Arqueros Espaciales", 2, 4, "No tienen efecto especial", P, TypeUnit.Silver, "U", "None", "R" + "S", Resources.Load<Sprite>("2"), true));
                Deck.Add(new Card(P.P, "Campo Gravitatorio", 3, 0, "Carta clima, afecta a Cuerpo a Cuerpo", P, TypeUnit.None, "C", "Weather", "M", Resources.Load<Sprite>("3"), true));
                Deck.Add(new Card(P.P, "Catapulta de Estrellas", 4, 8, "Arma de gran rango", P, TypeUnit.Silver, "U", "None", "S", Resources.Load<Sprite>("4"), true));
                Deck.Add(new Card(P.P, "Catapulta de Estrellas", 5, 8, "Arma de gran rango", P, TypeUnit.Silver, "U", "None", "S", Resources.Load<Sprite>("5"), true));
                Deck.Add(new Card(P.P, "Cientifico Nebular", 6, 3, "Pone un clima en su zona", P, TypeUnit.Golden, "U", "Weather", "S", Resources.Load<Sprite>("6"), true));
                Deck.Add(new Card(P.P, "Clon de Combate", 7, 3, "Su poder incrementa en presencia de otro clon", P, TypeUnit.Silver, "U", "Colmena", "M", Resources.Load<Sprite>("7"), true));
                Deck.Add(new Card(P.P, "Clon de Combate", 8, 3, "Su poder incrementa en presencia de otro clon", P, TypeUnit.Silver, "U", "Colmena", "M", Resources.Load<Sprite>("8"), true));
                Deck.Add(new Card(P.P, "Dragon Espacial", 9, 3, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "M" + "R", Resources.Load<Sprite>("9"), true));
                Deck.Add(new Card(P.P, "Dragon Espacial", 10, 3, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "M" + "R", Resources.Load<Sprite>("10"), true));
                Deck.Add(new Card(P.P, "Estrella Binaria", 11, 3, "Genera confusión en tu adversario, permite robar una carta", P, TypeUnit.Silver, "U", "Steal", "R" + "S", Resources.Load<Sprite>("11"), true));
                Deck.Add(new Card(P.P, "Guardian", 12, 3, "Elimina la carta de mayor Poder", P, TypeUnit.Golden, "U", "Most Pwr", "M", Resources.Load<Sprite>("12"), true));
                Deck.Add(new Card(P.P, "Ingeniero Estelar", 13, 3, "Eliminará la carta más débil", P, TypeUnit.Golden, "U", "Less Pwr", "S", Resources.Load<Sprite>("13"), true));
                Deck.Add(new Card(P.P, "Mago del Tiempo", 14, 3, "Iguala el poder d todas las cartas al promedio entre ellas", P, TypeUnit.Silver, "U", "Media", "R" + "S", Resources.Load<Sprite>("14"), true));
                Deck.Add(new Card(P.P, "Mago Tecnologico", 15, 3, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "M" + "R", Resources.Load<Sprite>("15"), true));
                Deck.Add(new Card(P.P, "Mago Tecnologico", 16, 3, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "M" + "R", Resources.Load<Sprite>("16"), true));
                Deck.Add(new Card(P.P, "Nave de Sacrificio", 17, 0, "Efecto Señuelo,puedes cambiarla por cualquiera que hayas jugado", P, TypeUnit.None, "D", "Decoy", "M" + "R" + "S", Resources.Load<Sprite>("17"), true));
                Deck.Add(new Card(P.P, "Nebulosa Energetica", 18, 0, "Carta Clima, afecta Distancia", P, TypeUnit.None, "C", "Weather", "R", Resources.Load<Sprite>("18"), true));
                Deck.Add(new Card(P.P, "Tecnologo Cuantico", 19, 3, "Limpia la zona con menos unidades", P, TypeUnit.Silver, "U", "Zone Cleaner", "M" + "R" + "S", Resources.Load<Sprite>("19"), true));
                Deck.Add(new Card(P.P, "Tonico Espacial", 20, 0, "Carta Aumento, actúa sobre Distancia", P, TypeUnit.None, "AR", "Raise", "R", Resources.Load<Sprite>("20"), true));
                Deck.Add(new Card(P.P, "Tormenta de Gusano", 21, 0, "Carta Clima, afecta a Asedio", P, TypeUnit.None, "C", "Weather", "S", Resources.Load<Sprite>("21"), true));
                Deck.Add(new Card(P.P, "Espada Laser", 22, 0, "Carta Aumento, actúa sobre Cuerpo a Cuerpo", P, TypeUnit.None, "AM", "Raise", "M", Resources.Load<Sprite>("22"), true));
                Deck.Add(new Card(P.P, "Bendicion de Houla", 23, 0, "Carta Aumento, actúa sobre Asedio", P, TypeUnit.None, "AS", "Raise", "S", Resources.Load<Sprite>("23"), true));
                Deck.Add(new Card(P.P, "Luz", 24, 0, "Despeja todo el mal tiempo de la Batalla", P, TypeUnit.None, "C", "Light", "M" + "R" + "S", Resources.Load<Sprite>("24"), true));

                Debug.Log("Cartas añadidas");
                #endregion
                P.Stealer = true;
            }
            else
            {
                #region Aliens
                Deck.Add(new Card(P.P, "Magnus", 0, 0, "Permite conservar una carta en el campo luego de un turno", P, TypeUnit.None, "L", "Planet", "", Resources.Load<Sprite>("_01"), true));
                Deck.Add(new Card(P.P, "Meteoro", 1, 4, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "R" + "S", Resources.Load<Sprite>("_02"), true));
                Deck.Add(new Card(P.P, "Meteoro", 2, 4, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "R" + "S", Resources.Load<Sprite>("_02"), true));
                Deck.Add(new Card(P.P, "Campo Gravitatorio", 3, 0, "Carta Clima, afecta a Cuerpo a Cuerpo", P, TypeUnit.None, "C", "Weather", "M", Resources.Load<Sprite>("_03"), true));
                Deck.Add(new Card(P.P, "Razor", 4, 8, "Arma de gran rango", P, TypeUnit.Silver, "U", "None", "S", Resources.Load<Sprite>("_04"), true));
                Deck.Add(new Card(P.P, "Razor", 5, 8, "Arma de gran rango", P, TypeUnit.Silver, "U", "None", "S", Resources.Load<Sprite>("_04"), true));
                Deck.Add(new Card(P.P, "Desintegrador", 6, 3, "Efecto Clima, afecta a Asedio", P, TypeUnit.Silver, "U", "Weather", "S", Resources.Load<Sprite>("_05"), true));
                Deck.Add(new Card(P.P, "MultiBrazos", 7, 3, "Su poder incrementa en presencia de otro Multibrazos", P, TypeUnit.Silver, "U", "Colmena", "M" + "R", Resources.Load<Sprite>("_07"), true));
                Deck.Add(new Card(P.P, "Multibrazos", 8, 3, "Su poder incrementa en presencia de otro Multibrazos", P, TypeUnit.Silver, "U", "Colmena", "M"+ "R", Resources.Load<Sprite>("_07"), true));
                Deck.Add(new Card(P.P, "Reptil Lunar", 9, 3, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "S" + "R", Resources.Load<Sprite>("_21"), true));
                Deck.Add(new Card(P.P, "Reptil Lunar", 10, 3, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "S" + "R", Resources.Load<Sprite>("_21"), true));
                Deck.Add(new Card(P.P, "Laura", 11, 3, "Genera confusión en tu adversario, permite robar una carta", P, TypeUnit.Silver, "U", "Steal", "R" + "S", Resources.Load<Sprite>("_08"), true));
                Deck.Add(new Card(P.P, "Golem", 12, 3, "Elimina la carta de mayor Poder", P, TypeUnit.Golden, "U", "Most Pwr", "M", Resources.Load<Sprite>("_06"), true));
                Deck.Add(new Card(P.P, "Espectro de Fuego", 13, 3, "Elimina la carta más débil", P, TypeUnit.Golden, "U", "Less Pwr", "M", Resources.Load<Sprite>("_09"), true));
                Deck.Add(new Card(P.P, "Pulpo de Yud", 14, 3, "Iguala el poder d todas las cartas al promedio entre ellas", P, TypeUnit.Silver, "U", "Media", "S", Resources.Load<Sprite>("_10"), true));
                Deck.Add(new Card(P.P, "Serpiente de Zitharus", 15, 3, "No tiene efecto especial", P, TypeUnit.Golden, "U", "None", "R" + "S", Resources.Load<Sprite>("_11"), true));
                Deck.Add(new Card(P.P, "Fenrir", 16, 3, "Carta de campo, con efecto Aumento", P, TypeUnit.Silver, "U", "Raise", "M" + "R", Resources.Load<Sprite>("_12"), true));
                Deck.Add(new Card(P.P, "Teletransportador", 17, 0, "Efecto Señuelo,puedes cambiarla por cualquiera que hayas jugado", P, TypeUnit.None, "D", "Decoy", "M" + "R" + "S", Resources.Load<Sprite>("_13"), true));
                Deck.Add(new Card(P.P, "Nebulosa Energética", 18, 0, "Carta Clima, afecta a Distancia", P, TypeUnit.None, "C", "Weather", "R", Resources.Load<Sprite>("_14"), true));
                Deck.Add(new Card(P.P, "Los Trillizos", 19, 3, "Limpia la zona con menos unidades", P, TypeUnit.Silver, "U", "Zone Cleaner", "M" + "R" + "S", Resources.Load<Sprite>("_15"), true));
                Deck.Add(new Card(P.P, "Tonico Espacial", 20, 0, "Carta Aumento, actúa sobre Distancia", P, TypeUnit.None, "AR", "Raise", "R", Resources.Load<Sprite>("_16"), true));
                Deck.Add(new Card(P.P, "Tormenta de Gusano", 21, 0, "Carta Clima, afecta a Asedio", P, TypeUnit.None, "C", "Weather", "S", Resources.Load<Sprite>("_17"), true));
                Deck.Add(new Card(P.P, "Espada Laser", 22, 0, "Carta Aumento, actúa sobre Cuerpo a Cuerpo", P, TypeUnit.None, "AM", "Raise", "M", Resources.Load<Sprite>("_18"), true));
                Deck.Add(new Card(P.P, "Bendicion de Houla", 23, 0, "Carta Aumento, actúa sobre Asedio", P, TypeUnit.None, "AS", "Raise", "S", Resources.Load<Sprite>("_19"), true));
                Deck.Add(new Card(P.P, "Luz", 24, 0, "Despeja todo el mal tiempo de la Batalla",P, TypeUnit.None, "C", "Light", "M" + "R" + "S", Resources.Load<Sprite>("_20"), true));

                Debug.Log("Cartas añadidas");
                #endregion
                P.RandomizedNotRem = true;
            }
            return Deck;
        }




    }

    

}
