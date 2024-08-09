using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LogicalSide;

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
                Deck.Add(new Card(P.Turn, "Alarion", 0, 0, "Te permite robar una carta extra por ronda", P, TypeUnit.None, "L", "Planet", "", Resources.Load<Sprite>("0"), true));
                Deck.Add(new Card(P.Turn, "Arqueros Espaciales", 1, 4, "No tienen efecto especial", P, TypeUnit.Silver, "U", "None", "R" + "S", Resources.Load<Sprite>("1"), true));
                Deck.Add(new Card(P.Turn, "Arqueros Espaciales", 2, 4, "No tienen efecto especial", P, TypeUnit.Silver, "U", "None", "R" + "S", Resources.Load<Sprite>("2"), true));
                Deck.Add(new Card(P.Turn, "Campo Gravitatorio", 3, 0, "Carta clima, afecta a Cuerpo a Cuerpo", P, TypeUnit.None, "C", "Weather", "M", Resources.Load<Sprite>("3"), true));
                Deck.Add(new Card(P.Turn, "Catapulta de Estrellas", 4, 8, "Arma de gran rango", P, TypeUnit.Silver, "U", "None", "S", Resources.Load<Sprite>("4"), true));
                Deck.Add(new Card(P.Turn, "Catapulta de Estrellas", 5, 8, "Arma de gran rango", P, TypeUnit.Silver, "U", "None", "S", Resources.Load<Sprite>("5"), true));
                Deck.Add(new Card(P.Turn, "Cientifico Nebular", 6, 3, "Pone un clima en su zona", P, TypeUnit.Golden, "U", "Weather", "S", Resources.Load<Sprite>("6"), true));
                Deck.Add(new Card(P.Turn, "Clon de Combate", 7, 3, "Su poder incrementa en presencia de otro clon", P, TypeUnit.Silver, "U", "Colmena", "M", Resources.Load<Sprite>("7"), true));
                Deck.Add(new Card(P.Turn, "Clon de Combate", 8, 3, "Su poder incrementa en presencia de otro clon", P, TypeUnit.Silver, "U", "Colmena", "M", Resources.Load<Sprite>("8"), true));
                Deck.Add(new Card(P.Turn, "Dragon Espacial", 9, 3, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "M" + "R", Resources.Load<Sprite>("9"), true));
                Deck.Add(new Card(P.Turn, "Dragon Espacial", 10, 3, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "M" + "R", Resources.Load<Sprite>("10"), true));
                Deck.Add(new Card(P.Turn, "Estrella Binaria", 11, 3, "Genera confusi�n en tu adversario, permite robar una carta", P, TypeUnit.Silver, "U", "Steal", "R" + "S", Resources.Load<Sprite>("11"), true));
                Deck.Add(new Card(P.Turn, "Guardian", 12, 3, "Elimina la carta de mayor Poder", P, TypeUnit.Golden, "U", "Most Pwr", "M", Resources.Load<Sprite>("12"), true));
                Deck.Add(new Card(P.Turn, "Ingeniero Estelar", 13, 3, "Eliminar� la carta m�s d�bil", P, TypeUnit.Golden, "U", "Less Pwr", "S", Resources.Load<Sprite>("13"), true));
                Deck.Add(new Card(P.Turn, "Mago del Tiempo", 14, 3, "Iguala el poder d todas las cartas al promedio entre ellas", P, TypeUnit.Silver, "U", "Media", "R" + "S", Resources.Load<Sprite>("14"), true));
                Deck.Add(new Card(P.Turn, "Mago Tecnologico", 15, 3, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "M" + "R", Resources.Load<Sprite>("15"), true));
                Deck.Add(new Card(P.Turn, "Mago Tecnologico", 16, 3, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "M" + "R", Resources.Load<Sprite>("16"), true));
                Deck.Add(new Card(P.Turn, "Nave de Sacrificio", 17, 0, "Efecto Se�uelo,puedes cambiarla por cualquiera que hayas jugado", P, TypeUnit.None, "D", "Decoy", "M" + "R" + "S", Resources.Load<Sprite>("17"), true));
                Deck.Add(new Card(P.Turn, "Nebulosa Energetica", 18, 0, "Carta Clima, afecta Distancia", P, TypeUnit.None, "C", "Weather", "R", Resources.Load<Sprite>("18"), true));
                Deck.Add(new Card(P.Turn, "Tecnologo Cuantico", 19, 3, "Limpia la zona con menos unidades", P, TypeUnit.Silver, "U", "Zone Cleaner", "M" + "R" + "S", Resources.Load<Sprite>("19"), true));
                Deck.Add(new Card(P.Turn, "Tonico Espacial", 20, 0, "Carta Aumento, act�a sobre Distancia", P, TypeUnit.None, "AR", "Raise", "R", Resources.Load<Sprite>("20"), true));
                Deck.Add(new Card(P.Turn, "Tormenta de Gusano", 21, 0, "Carta Clima, afecta a Asedio", P, TypeUnit.None, "C", "Weather", "S", Resources.Load<Sprite>("21"), true));
                Deck.Add(new Card(P.Turn, "Espada Laser", 22, 0, "Carta Aumento, act�a sobre Cuerpo a Cuerpo", P, TypeUnit.None, "AM", "Raise", "M", Resources.Load<Sprite>("22"), true));
                Deck.Add(new Card(P.Turn, "Bendicion de Houla", 23, 0, "Carta Aumento, act�a sobre Asedio", P, TypeUnit.None, "AS", "Raise", "S", Resources.Load<Sprite>("23"), true));
                Deck.Add(new Card(P.Turn, "Luz", 24, 0, "Despeja todo el mal tiempo de la Batalla", P, TypeUnit.None, "C", "Light", "M" + "R" + "S", Resources.Load<Sprite>("24"), true));

                Debug.Log("Cartas a�adidas");
                #endregion
                P.Stealer = true;
            }
            else if(P.faction==2)
            {
                #region Aliens
                Deck.Add(new Card(P.Turn, "Magnus", 0, 0, "Permite conservar una carta en el campo luego de un turno", P, TypeUnit.None, "L", "Planet", "", Resources.Load<Sprite>("_01"), true));
                Deck.Add(new Card(P.Turn, "Meteoro", 1, 4, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "R" + "S", Resources.Load<Sprite>("_02"), true));
                Deck.Add(new Card(P.Turn, "Meteoro", 2, 4, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "R" + "S", Resources.Load<Sprite>("_02"), true));
                Deck.Add(new Card(P.Turn, "Campo Gravitatorio", 3, 0, "Carta Clima, afecta a Cuerpo a Cuerpo", P, TypeUnit.None, "C", "Weather", "M", Resources.Load<Sprite>("_03"), true));
                Deck.Add(new Card(P.Turn, "Razor", 4, 8, "Arma de gran rango", P, TypeUnit.Silver, "U", "None", "S", Resources.Load<Sprite>("_04"), true));
                Deck.Add(new Card(P.Turn, "Razor", 5, 8, "Arma de gran rango", P, TypeUnit.Silver, "U", "None", "S", Resources.Load<Sprite>("_04"), true));
                Deck.Add(new Card(P.Turn, "Desintegrador", 6, 3, "Efecto Clima, afecta a Asedio", P, TypeUnit.Silver, "U", "Weather", "S", Resources.Load<Sprite>("_05"), true));
                Deck.Add(new Card(P.Turn, "Multibrazos", 7, 3, "Su poder incrementa en presencia de otro Multibrazos", P, TypeUnit.Silver, "U", "Colmena", "M" + "R", Resources.Load<Sprite>("_07"), true));
                Deck.Add(new Card(P.Turn, "Multibrazos", 8, 3, "Su poder incrementa en presencia de otro Multibrazos", P, TypeUnit.Silver, "U", "Colmena", "M"+ "R", Resources.Load<Sprite>("_07"), true));
                Deck.Add(new Card(P.Turn, "Reptil Lunar", 9, 3, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "S" + "R", Resources.Load<Sprite>("_21"), true));
                Deck.Add(new Card(P.Turn, "Reptil Lunar", 10, 3, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "S" + "R", Resources.Load<Sprite>("_21"), true));
                Deck.Add(new Card(P.Turn, "Laura", 11, 3, "Genera confusi�n en tu adversario, permite robar una carta", P, TypeUnit.Silver, "U", "Steal", "R" + "S", Resources.Load<Sprite>("_08"), true));
                Deck.Add(new Card(P.Turn, "Golem", 12, 3, "Elimina la carta de mayor Poder", P, TypeUnit.Golden, "U", "Most Pwr", "M", Resources.Load<Sprite>("_06"), true));
                Deck.Add(new Card(P.Turn, "Espectro de Fuego", 13, 3, "Elimina la carta m�s d�bil", P, TypeUnit.Golden, "U", "Less Pwr", "M", Resources.Load<Sprite>("_09"), true));
                Deck.Add(new Card(P.Turn, "Pulpo de Yud", 14, 3, "Iguala el poder d todas las cartas al promedio entre ellas", P, TypeUnit.Silver, "U", "Media", "S", Resources.Load<Sprite>("_10"), true));
                Deck.Add(new Card(P.Turn, "Serpiente de Zitharus", 15, 3, "No tiene efecto especial", P, TypeUnit.Golden, "U", "None", "R" + "S", Resources.Load<Sprite>("_11"), true));
                Deck.Add(new Card(P.Turn, "Fenrir", 16, 3, "Carta de campo, con efecto Aumento", P, TypeUnit.Silver, "U", "Raise", "M" + "R", Resources.Load<Sprite>("_12"), true));
                Deck.Add(new Card(P.Turn, "Teletransportador", 17, 0, "Efecto Se�uelo,puedes cambiarla por cualquiera que hayas jugado", P, TypeUnit.None, "D", "Decoy", "M" + "R" + "S", Resources.Load<Sprite>("_13"), true));
                Deck.Add(new Card(P.Turn, "Nebulosa Energ�tica", 18, 0, "Carta Clima, afecta a Distancia", P, TypeUnit.None, "C", "Weather", "R", Resources.Load<Sprite>("_14"), true));
                Deck.Add(new Card(P.Turn, "Los Trillizos", 19, 3, "Limpia la zona con menos unidades", P, TypeUnit.Silver, "U", "Zone Cleaner", "M" + "R" + "S", Resources.Load<Sprite>("_15"), true));
                Deck.Add(new Card(P.Turn, "Tonico Espacial", 20, 0, "Carta Aumento, act�a sobre Distancia", P, TypeUnit.None, "AR", "Raise", "R", Resources.Load<Sprite>("_16"), true));
                Deck.Add(new Card(P.Turn, "Tormenta de Gusano", 21, 0, "Carta Clima, afecta a Asedio", P, TypeUnit.None, "C", "Weather", "S", Resources.Load<Sprite>("_17"), true));
                Deck.Add(new Card(P.Turn, "Espada Laser", 22, 0, "Carta Aumento, act�a sobre Cuerpo a Cuerpo", P, TypeUnit.None, "AM", "Raise", "M", Resources.Load<Sprite>("_18"), true));
                Deck.Add(new Card(P.Turn, "Bendicion de Houla", 23, 0, "Carta Aumento, act�a sobre Asedio", P, TypeUnit.None, "AS", "Raise", "S", Resources.Load<Sprite>("_19"), true));
                Deck.Add(new Card(P.Turn, "Luz", 24, 0, "Despeja todo el mal tiempo de la Batalla",P, TypeUnit.None, "C", "Light", "M" + "R" + "S", Resources.Load<Sprite>("_20"), true));
                

                Debug.Log("Cartas a�adidas");
                #endregion
                P.RandomizedNotRem = true;
            }
            else
            {
                #region Mixto
                Deck.Add(new Card(P.Turn, "Magnus", 0, 0, "Si empatas la ronda ganas", P, TypeUnit.None, "L", "Planet", "", Resources.Load<Sprite>("_01"), true));
                Deck.Add(new Card(P.Turn, "Arqueros Espaciales", 1, 4, "No tienen efecto especial", P, TypeUnit.Silver, "U", "None", "R" + "S", Resources.Load<Sprite>("1"), true));
                Deck.Add(new Card(P.Turn, "Meteoro", 2, 4, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "R" + "S", Resources.Load<Sprite>("_02"), true));
                Deck.Add(new Card(P.Turn, "Campo Gravitatorio", 3, 0, "Carta Clima, afecta a Cuerpo a Cuerpo", P, TypeUnit.None, "C", "Weather", "M", Resources.Load<Sprite>("_03"), true));
                Deck.Add(new Card(P.Turn, "Razor", 4, 8, "Arma de gran rango", P, TypeUnit.Silver, "U", "None", "S", Resources.Load<Sprite>("_04"), true));
                Deck.Add(new Card(P.Turn, "Catapulta de Estrellas", 5, 8, "Arma de gran rango", P, TypeUnit.Silver, "U", "None", "S", Resources.Load<Sprite>("5"), true));
                Deck.Add(new Card(P.Turn, "Cientifico Nebular", 6, 3, "Pone un clima en su zona", P, TypeUnit.Golden, "U", "Weather", "S", Resources.Load<Sprite>("6"), true));
                Deck.Add(new Card(P.Turn, "Multibrazos", 7, 3, "Su poder incrementa en presencia de otro Multibrazos", P, TypeUnit.Silver, "U", "Colmena", "M" + "R", Resources.Load<Sprite>("_07"), true));
                Deck.Add(new Card(P.Turn, "Multibrazos", 8, 3, "Su poder incrementa en presencia de otro Multibrazos", P, TypeUnit.Silver, "U", "Colmena", "M" + "R", Resources.Load<Sprite>("_07"), true));
                Deck.Add(new Card(P.Turn, "Dragon Espacial", 9, 3, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "M" + "R", Resources.Load<Sprite>("9"), true));
                Deck.Add(new Card(P.Turn, "Dragon Espacial", 10, 3, "No tiene efecto especial", P, TypeUnit.Silver, "U", "None", "M" + "R", Resources.Load<Sprite>("10"), true));
                Deck.Add(new Card(P.Turn, "Laura", 11, 3, "Genera confusi�n en tu adversario, permite robar una carta", P, TypeUnit.Silver, "U", "Steal", "R" + "S", Resources.Load<Sprite>("_08"), true));
                Deck.Add(new Card(P.Turn, "Golem", 12, 3, "Elimina la carta de mayor Poder", P, TypeUnit.Golden, "U", "Most Pwr", "M", Resources.Load<Sprite>("_06"), true));
                Deck.Add(new Card(P.Turn, "Ingeniero Estelar", 13, 3, "Eliminar� la carta m�s d�bil", P, TypeUnit.Golden, "U", "Less Pwr", "S", Resources.Load<Sprite>("13"), true));
                Deck.Add(new Card(P.Turn, "Mago del Tiempo", 14, 3, "Iguala el poder d todas las cartas al promedio entre ellas", P, TypeUnit.Silver, "U", "Media", "R" + "S", Resources.Load<Sprite>("14"), true));
                Deck.Add(new Card(P.Turn, "Serpiente de Zitharus", 15, 3, "No tiene efecto especial", P, TypeUnit.Golden, "U", "None", "R" + "S", Resources.Load<Sprite>("_11"), true));
                Deck.Add(new Card(P.Turn, "Fenrir", 16, 3, "Carta de campo, con efecto Aumento", P, TypeUnit.Silver, "U", "Raise", "M" + "R", Resources.Load<Sprite>("_12"), true));
                Deck.Add(new Card(P.Turn, "Nave de Sacrificio", 17, 0, "Efecto Se�uelo,puedes cambiarla por cualquiera que hayas jugado", P, TypeUnit.None, "D", "Decoy", "M" + "R" + "S", Resources.Load<Sprite>("17"), true));
                Deck.Add(new Card(P.Turn, "Nebulosa Energetica", 18, 0, "Carta Clima, afecta Distancia", P, TypeUnit.None, "C", "Weather", "R", Resources.Load<Sprite>("18"), true));
                Deck.Add(new Card(P.Turn, "Los Trillizos", 19, 3, "Limpia la zona con menos unidades", P, TypeUnit.Silver, "U", "Zone Cleaner", "M" + "R" + "S", Resources.Load<Sprite>("_15"), true));
                Deck.Add(new Card(P.Turn, "Tonico Espacial", 20, 0, "Carta Aumento, act�a sobre Distancia", P, TypeUnit.None, "AR", "Raise", "R", Resources.Load<Sprite>("_16"), true));
                Deck.Add(new Card(P.Turn, "Espada Laser", 22, 0, "Carta Aumento, act�a sobre Cuerpo a Cuerpo", P, TypeUnit.None, "AM", "Raise", "M", Resources.Load<Sprite>("22"), true));
                Deck.Add(new Card(P.Turn, "Bendicion de Houla", 23, 0, "Carta Aumento, act�a sobre Asedio", P, TypeUnit.None, "AS", "Raise", "S", Resources.Load<Sprite>("_19"), true));
                Deck.Add(new Card(P.Turn, "Luz", 24, 0, "Despeja todo el mal tiempo de la Batalla", P, TypeUnit.None, "C", "Light", "M" + "R" + "S", Resources.Load<Sprite>("24"), true));
                #endregion
                P.AlwaysAWinner= true;
            }
            return Deck;
        }




    }

    

}
