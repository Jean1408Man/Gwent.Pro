using LogicalSide;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CardDrag : MonoBehaviour
{
    private bool IsDragging= false;
    private bool Played= false;
    private Vector2 startPos;
    private bool IsOverZone= false;
    private GameObject dropzone;
    private Efectos efectos;
    void Start()
    // Start is called before the first frame update
    {
        efectos = GameObject.Find("Effects").GetComponent<Efectos>();
    }
    public void StartDrag()
    {
        if (Played == false)
        {
            startPos = gameObject.transform.position;
            IsDragging = true;
        }
    }
    public void EndDrag()
    {
        IsDragging = false;
        if (!Played)
        {
            CardDisplay disp = gameObject.GetComponent<CardDisplay>();
            if (IsOverZone && dropzone != null)// Verificar si el collider no es nulo y corresponde a una Dropzone
            {
                if (IsPosible(disp))
                {
                    transform.SetParent(dropzone.transform, false);
                    Played = true;
                    disp.cardTemplate.current_Rg = dropzone.tag;
                    if(disp.cardTemplate.type== "U")
                        efectos.PlayCrad(disp.cardTemplate);
                    efectos.ListEffects[disp.cardTemplate.Eff].Invoke(disp.cardTemplate);
                }
            }
            if(!Played)
            {
                transform.position = startPos;
                IsOverZone = false;
                dropzone= null;
            }
        }
    }
    private bool IsPosible(CardDisplay disp)
    {
        if (disp.cardTemplate.type.IndexOf("C") == -1)
            if (disp.cardTemplate.type.IndexOf("A") == -1)
            {
                if (dropzone.transform.childCount < 6 && disp.cardTemplate.Atk_Rg.IndexOf(dropzone.tag) != -1 && efectos.RangeMap[(disp.cardTemplate.DownBoard, dropzone.tag)] == dropzone)
                {
                    return true;
                }
            }
            else
            {
                if (dropzone.tag==disp.cardTemplate.type && efectos.RangeMap[(disp.cardTemplate.DownBoard, dropzone.tag)] == dropzone)
                    return true;
            }
        else
        {
            if (dropzone.transform.childCount < 3&& dropzone.tag=="C")
                return true;
        }
        return false;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        IsOverZone = true;
        dropzone= collision.gameObject;
    }
    void Update()
    {
        if (IsDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }
}
