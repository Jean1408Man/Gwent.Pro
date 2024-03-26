using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LogicalSide 
{ 
    public class CardDataBase: MonoBehaviour
    {
        public static List<Card> CelestiallistCard = new List<Card>();
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
        public static void GetCelestial(bool b)
        {
            //Celestials
            #region
            CelestiallistCard.Add(new Card(b,"Alarion", 0, 0, "Brilloso", TypeUnit.None, "L", "None", "", Resources.Load<Sprite>("0")));
            CelestiallistCard.Add(new Card(b,"Arqueros Espaciales", 1, 4, "Brilloso", TypeUnit.Silver, "U", "None", "R"+"S", Resources.Load<Sprite>("1")));
            CelestiallistCard.Add(new Card(b, "Arqueros Espaciales", 2, 4, "Brilloso", TypeUnit.Silver, "U", "None", "R"  + "S" , Resources.Load<Sprite>("2")));
            CelestiallistCard.Add(new Card(b,"Campo Gravitatorio", 3, 7, "Afecta a Melee", TypeUnit.None, "C" , "Weather", "M", Resources.Load<Sprite>("3")));
            CelestiallistCard.Add(new Card(b,"Catapulta de Estrellas", 4, 8, "Arma de gran rango", TypeUnit.Silver, "U", "None", "S", Resources.Load<Sprite>("4")));
            CelestiallistCard.Add(new Card(b, "Catapulta de Estrellas", 5, 8, "Arma de gran rango", TypeUnit.Silver, "U", "None", "S", Resources.Load<Sprite>("5")));
            CelestiallistCard.Add(new Card(b, "Cientifico Nebular", 6, 3, "Brilloso", TypeUnit.Silver, "U", "None", "S" , Resources.Load<Sprite>("6")));
            CelestiallistCard.Add(new Card(b, "Clon de Combate", 7, 3, "Brilloso", TypeUnit.Silver, "U", "None", "M", Resources.Load<Sprite>("7")));
            CelestiallistCard.Add(new Card(b, "Clon de Combate", 8, 3, "Brilloso", TypeUnit.Silver, "U", "None", "M" , Resources.Load<Sprite>("8")));
            CelestiallistCard.Add(new Card(b, "Dragon Espacial", 9, 3, "Brilloso", TypeUnit.Silver, "U", "None", "M"+"R", Resources.Load<Sprite>("9")));
            CelestiallistCard.Add(new Card(b, "Dragon Espacial", 10, 3, "Brilloso", TypeUnit.Silver, "U", "None", "M"+"R", Resources.Load<Sprite>("10")));
            CelestiallistCard.Add(new Card(b, "Estrella Binaria", 11, 3, "Brilloso", TypeUnit.Silver, "U", "None", "R"  + "S" , Resources.Load<Sprite>("11")));
            CelestiallistCard.Add(new Card(b, "Guardian", 12, 3, "Brilloso", TypeUnit.Golden, "U", "None", "M" , Resources.Load<Sprite>("12")));
            CelestiallistCard.Add(new Card(b, "Ingeniero Estelar", 13, 3, "Brilloso", TypeUnit.Golden, "U", "None", "S" , Resources.Load<Sprite>("13")));
            CelestiallistCard.Add(new Card(b, "Mago del Tiempo", 14, 3, "Brilloso", TypeUnit.Silver, "U", "None", "R"  + "S" , Resources.Load<Sprite>("14")));
            CelestiallistCard.Add(new Card(b, "Mago Tecnologico", 15, 3, "Brilloso", TypeUnit.Silver, "U", "None", "M"+"R" , Resources.Load<Sprite>("15")));
            CelestiallistCard.Add(new Card(b, "Mago Tecnologico", 16, 3, "Brilloso", TypeUnit.Silver, "U", "None", "M"  + "R" , Resources.Load<Sprite>("16")));
            CelestiallistCard.Add(new Card(b, "Nave de Sacrificio", 17, 3, "Brilloso", TypeUnit.None, "D", "Decoy", "M"+"R"+"S", Resources.Load<Sprite>("17")));
            CelestiallistCard.Add(new Card(b, "Nebulosa Energetica", 18, 3, "Brilloso", TypeUnit.None, "C", "Weather", "R", Resources.Load<Sprite>("18")));
            CelestiallistCard.Add(new Card(b, "Tecnologo Cuantico", 19, 3, "Brilloso", TypeUnit.Golden, "U", "None", "M"+"R"+"S", Resources.Load<Sprite>("19")));
            CelestiallistCard.Add(new Card(b, "Tonico Espacial", 20, 3, "Brilloso", TypeUnit.None, "AR", "Raise", "R", Resources.Load<Sprite>("20")));
            CelestiallistCard.Add(new Card(b, "Tormenta de Gusano", 21, 3, "Brilloso", TypeUnit.None, "C" , "Weather", "S", Resources.Load<Sprite>("21")));
            CelestiallistCard.Add(new Card(b, "Espada Laser", 22, 3, "Brilloso", TypeUnit.None, "AM", "Raise", "M", Resources.Load<Sprite>("22")));
            CelestiallistCard.Add(new Card(b, "Bendicion de Houla", 23, 3, "Brilloso", TypeUnit.None, "AS" , "Raise", "S", Resources.Load<Sprite>("23")));
            CelestiallistCard.Add(new Card(b,"Luz", 24, 3, "Despeja todo el mal tiempo de la Batalla", TypeUnit.None, "C" , "Light", "M"+ "R"+ "S", Resources.Load<Sprite>("24")));
            
            Debug.Log("Cartas añadidas");
            #endregion
        }




    }

    

}
