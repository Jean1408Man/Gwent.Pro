using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LogicalSide 
{ 
    public class CardDataBase: MonoBehaviour
    {
        #region
        public GameObject P1S;
        public GameObject P1R;
        public GameObject P1M;
        public GameObject P2S;
        public GameObject P2R;
        public GameObject P2M;
        public GameObject P1AM;
        public GameObject P1AR;
        public GameObject P1AS;
        public GameObject P2AM;
        public GameObject P2AR;
        public GameObject P2AS;
        public GameObject C;
        #endregion
        public static List<Card> GetDeck(bool b, int faction)
        {
            //Celestials
            List<Card> Deck = new();
            if (faction == 1)
            {
                #region
                Deck.Add(new Card(b, "Alarion", 0, 0, "Brilloso", TypeUnit.None, "L", "Planet", "", Resources.Load<Sprite>("0"), true));
                Deck.Add(new Card(b, "Arqueros Espaciales", 1, 4, "Brilloso", TypeUnit.Silver, "U", "None", "R" + "S", Resources.Load<Sprite>("1"), true));
                Deck.Add(new Card(b, "Arqueros Espaciales", 2, 4, "Brilloso", TypeUnit.Silver, "U", "None", "R" + "S", Resources.Load<Sprite>("2"), true));
                Deck.Add(new Card(b, "Campo Gravitatorio", 3, 0, "Afecta a Melee", TypeUnit.None, "C", "Weather", "M", Resources.Load<Sprite>("3"), true));
                Deck.Add(new Card(b, "Catapulta de Estrellas", 4, 8, "Arma de gran rango", TypeUnit.Silver, "U", "None", "S", Resources.Load<Sprite>("4"), true));
                Deck.Add(new Card(b, "Catapulta de Estrellas", 5, 8, "Arma de gran rango", TypeUnit.Silver, "U", "None", "S", Resources.Load<Sprite>("5"), true));
                Deck.Add(new Card(b, "Cientifico Nebular", 6, 3, "Brilloso", TypeUnit.Silver, "U", "Weather", "S", Resources.Load<Sprite>("6"), true));
                Deck.Add(new Card(b, "Clon de Combate", 7, 3, "Su poder incrementa en presencia de otro clon", TypeUnit.Silver, "U", "Colmena", "M", Resources.Load<Sprite>("7"), true));
                Deck.Add(new Card(b, "Clon de Combate", 8, 3, "Su poder incrementa en presencia de otro clon", TypeUnit.Silver, "U", "Colmena", "M", Resources.Load<Sprite>("8"), true));
                Deck.Add(new Card(b, "Dragon Espacial", 9, 3, "Brilloso", TypeUnit.Silver, "U", "None", "M" + "R", Resources.Load<Sprite>("9"), true));
                Deck.Add(new Card(b, "Dragon Espacial", 10, 3, "Brilloso", TypeUnit.Silver, "U", "None", "M" + "R", Resources.Load<Sprite>("10"), true));
                Deck.Add(new Card(b, "Estrella Binaria", 11, 3, "Genera confusion en tu adversario, permite robar una carta", TypeUnit.Silver, "U", "Steal", "R" + "S", Resources.Load<Sprite>("11"), true));
                Deck.Add(new Card(b, "Guardian", 12, 3, "Custodia la Galaxia impecablemente, elimina la carta de mayor Poder", TypeUnit.Golden, "U", "Most Pwr", "M", Resources.Load<Sprite>("12"), true));
                Deck.Add(new Card(b, "Ingeniero Estelar", 13, 3, "Le gusta un combate de nivel, eliminará la carta más débil", TypeUnit.Golden, "U", "Less Pwr", "S", Resources.Load<Sprite>("13"), true));
                Deck.Add(new Card(b, "Mago del Tiempo", 14, 3, "Brilloso", TypeUnit.Silver, "U", "None", "R" + "S", Resources.Load<Sprite>("14"), true));
                Deck.Add(new Card(b, "Mago Tecnologico", 15, 3, "Brilloso", TypeUnit.Silver, "U", "None", "M" + "R", Resources.Load<Sprite>("15"), true));
                Deck.Add(new Card(b, "Mago Tecnologico", 16, 3, "Brilloso", TypeUnit.Silver, "U", "None", "M" + "R", Resources.Load<Sprite>("16"), true));
                Deck.Add(new Card(b, "Nave de Sacrificio", 17, 3, "Brilloso", TypeUnit.None, "D", "Decoy", "M" + "R" + "S", Resources.Load<Sprite>("17"), true));
                Deck.Add(new Card(b, "Nebulosa Energetica", 18, 0, "Brilloso", TypeUnit.None, "C", "Weather", "R", Resources.Load<Sprite>("18"), true));
                Deck.Add(new Card(b, "Tecnologo Cuantico", 19, 3, "Limpia la zona con menos unidades", TypeUnit.Golden, "U", "Zone Cleaner", "M" + "R" + "S", Resources.Load<Sprite>("19"), true));
                Deck.Add(new Card(b, "Tonico Espacial", 20, 0, "Brilloso", TypeUnit.None, "AR", "Raise", "R", Resources.Load<Sprite>("20"), true));
                Deck.Add(new Card(b, "Tormenta de Gusano", 21, 0, "Brilloso", TypeUnit.None, "C", "Weather", "S", Resources.Load<Sprite>("21"), true));
                Deck.Add(new Card(b, "Espada Laser", 22, 0, "Brilloso", TypeUnit.None, "AM", "Raise", "M", Resources.Load<Sprite>("22"), true));
                Deck.Add(new Card(b, "Bendicion de Houla", 23, 0, "Brilloso", TypeUnit.None, "AS", "Raise", "S", Resources.Load<Sprite>("23"), true));
                Deck.Add(new Card(b, "Luz", 24, 0, "Despeja todo el mal tiempo de la Batalla", TypeUnit.None, "C", "Light", "M" + "R" + "S", Resources.Load<Sprite>("24"), true));

                Debug.Log("Cartas añadidas");
                #endregion
            }
            else
            {
                #region
                Deck.Add(new Card(b, "Magnus", 0, 0, "Lider", TypeUnit.None, "L", "Planet", "", Resources.Load<Sprite>("_01"), true));
                Deck.Add(new Card(b, "Meteoro", 1, 4, "Brilloso", TypeUnit.Silver, "U", "None", "R" + "S", Resources.Load<Sprite>("_02"), true));
                Deck.Add(new Card(b, "Meteoro", 2, 4, "Brilloso", TypeUnit.Silver, "U", "None", "R" + "S", Resources.Load<Sprite>("_02"), true));
                Deck.Add(new Card(b, "Campo Gravitatorio", 3, 0, "Afecta a Melee", TypeUnit.None, "C", "Weather", "M", Resources.Load<Sprite>("_03"), true));
                Deck.Add(new Card(b, "Razor", 4, 8, "Arma de gran rango", TypeUnit.Silver, "U", "None", "S", Resources.Load<Sprite>("_04"), true));
                Deck.Add(new Card(b, "Razor", 5, 8, "Arma de gran rango", TypeUnit.Silver, "U", "None", "S", Resources.Load<Sprite>("_04"), true));
                Deck.Add(new Card(b, "Desintegrador", 6, 3, "Brilloso", TypeUnit.Silver, "U", "Weather", "S", Resources.Load<Sprite>("_05"), true));
                Deck.Add(new Card(b, "MultiBrazos", 7, 3, "Su poder incrementa en presencia de otro Multibrazos", TypeUnit.Silver, "U", "Colmena", "M" + "R", Resources.Load<Sprite>("_07"), true));
                Deck.Add(new Card(b, "Multibrazos", 8, 3, "Su poder incrementa en presencia de otro Multibrazos", TypeUnit.Silver, "U", "Colmena", "M"+ "R", Resources.Load<Sprite>("_07"), true));
                Deck.Add(new Card(b, "Reptil Lunar", 9, 3, "Brilloso", TypeUnit.Silver, "U", "None", "S" + "R", Resources.Load<Sprite>("_21"), true));
                Deck.Add(new Card(b, "Reptil Lunar", 10, 3, "Brilloso", TypeUnit.Silver, "U", "None", "S" + "R", Resources.Load<Sprite>("_21"), true));
                Deck.Add(new Card(b, "Laura", 11, 3, "Genera confusion en tu adversario, permite robar una carta", TypeUnit.Silver, "U", "Steal", "R" + "S", Resources.Load<Sprite>("_08"), true));
                Deck.Add(new Card(b, "Golem", 12, 3, "Custodia la Galaxia impecablemente, elimina la carta de mayor Poder", TypeUnit.Golden, "U", "Most Pwr", "M", Resources.Load<Sprite>("_06"), true));
                Deck.Add(new Card(b, "Espectro de Fuego", 13, 3, "Le gusta un combate de nivel, eliminará la carta más débil", TypeUnit.Golden, "U", "Less Pwr", "M", Resources.Load<Sprite>("_09"), true));
                Deck.Add(new Card(b, "Pulpo de Yud", 14, 3, "Brilloso", TypeUnit.Silver, "U", "None", "S", Resources.Load<Sprite>("_10"), true));
                Deck.Add(new Card(b, "Serpiente de Zitharus", 15, 3, "Brilloso", TypeUnit.Silver, "U", "None", "R" + "S", Resources.Load<Sprite>("_11"), true));
                Deck.Add(new Card(b, "Fenrir", 16, 3, "Brilloso", TypeUnit.Silver, "U", "None", "M" + "R", Resources.Load<Sprite>("_12"), true));
                Deck.Add(new Card(b, "Teletransportador", 17, 3, "Brilloso", TypeUnit.None, "D", "Decoy", "M" + "R" + "S", Resources.Load<Sprite>("_13"), true));
                Deck.Add(new Card(b, "Nebulosa Energetica", 18, 0, "Brilloso", TypeUnit.None, "C", "Weather", "R", Resources.Load<Sprite>("_14"), true));
                Deck.Add(new Card(b, "Los Trillizos", 19, 3, "Limpia la zona con menos unidades", TypeUnit.Golden, "U", "Zone Cleaner", "M" + "R" + "S", Resources.Load<Sprite>("_15"), true));
                Deck.Add(new Card(b, "Tonico Espacial", 20, 0, "Brilloso", TypeUnit.None, "AR", "Raise", "R", Resources.Load<Sprite>("_16"), true));
                Deck.Add(new Card(b, "Tormenta de Gusano", 21, 0, "Brilloso", TypeUnit.None, "C", "Weather", "S", Resources.Load<Sprite>("_17"), true));
                Deck.Add(new Card(b, "Espada Laser", 22, 0, "Brilloso", TypeUnit.None, "AM", "Raise", "M", Resources.Load<Sprite>("_18"), true));
                Deck.Add(new Card(b, "Bendicion de Houla", 23, 0, "Brilloso", TypeUnit.None, "AS", "Raise", "S", Resources.Load<Sprite>("_19"), true));
                Deck.Add(new Card(b, "Luz", 24, 0, "Despeja todo el mal tiempo de la Batalla", TypeUnit.None, "C", "Light", "M" + "R" + "S", Resources.Load<Sprite>("_20"), true));

                Debug.Log("Cartas añadidas");
                #endregion
            }
            return Deck;
        }




    }

    

}
