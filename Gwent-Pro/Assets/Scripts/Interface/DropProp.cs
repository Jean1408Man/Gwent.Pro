using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LogicalSide
{
    public class DropProp : MonoBehaviour
    {
        public int raised;
        public int weather;
        
        public void DropStatus(int diff)
        {
            if (diff > 0)
                raised += diff;
            else
                weather += diff;
                CardDisplay disp;
            foreach (Transform cardTransform in transform)
            {
                disp = cardTransform.GetComponent<CardDisplay>();
                if (disp != null && disp.cardTemplate.unit == TypeUnit.Silver && disp.cardTemplate.TypeInterno!="D")
                {
                    disp.cardTemplate.Power += diff;
                }
            }
        }
        public void DropOnReset(int diff)
        {
            if (diff < 0)
                raised += diff;
            else
                weather += diff;
            CardDisplay disp;
            foreach (Transform cardTransform in transform)
            {
                disp = cardTransform.GetComponent<CardDisplay>();
                if (disp != null && disp.cardTemplate.unit == TypeUnit.Silver && disp.cardTemplate.TypeInterno != "D")
                {
                    disp.cardTemplate.Power += diff;
                }
            }
        }
        //private IEnumerator WaitForNextClick()
        //{
        //    // Espera hasta que no haya ninguna tecla presionada
        //    while (Input.anyKey)
        //    {
        //        yield return null;
        //    }
        //    GetPrincipal();
        //}
        //private IEnumerator ProcessMessage()
        //{
        //    // Procesa el mensaje aqu� (reemplaza esto con tu l�gica real)


        //    // Espera un frame antes de procesar el siguiente mensaje
        //    yield return null;
        //}

    }
}
