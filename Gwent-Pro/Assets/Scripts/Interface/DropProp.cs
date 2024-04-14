using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LogicalSide
{
    public class DropProp : MonoBehaviour
    {
        public int raised;
        public int weather;
        
        public bool enable;
        
        public void DropStatus(int diff, Card card)
        {
            if (diff > 0)
                raised += diff;
            else
                weather += diff;
                CardDisplay disp;
            foreach (Transform cardTransform in transform)
            {
                disp = cardTransform.GetComponent<CardDisplay>();
                if (disp != null && disp.cardTemplate.unit == TypeUnit.Silver&& disp!=card)
                {
                    disp.cardTemplate.Pwr += diff;
                }
            }
        }


        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        
    }
}
