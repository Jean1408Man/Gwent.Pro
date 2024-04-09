using LogicalSide;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class CardDrag : MonoBehaviour
{
    private bool IsDragging= false;
    public bool Played= false;
    private Vector2 startPos;
    private bool IsOverZone= false;
    private GameObject dropzone;
    private Efectos efectos;
    void Start()
    // Start is called before the first frame update
    {
        efectos = GameObject.Find("Effects").GetComponent<Efectos>();

        Visualizer = GameObject.Find("Visualizer");
    }
    public void StartDrag()
    {
        if (Played == false)
        {
            startPos = gameObject.transform.position;
            IsDragging = true;
            BigCardDestroy();
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
                    if (disp.cardTemplate.type != "D")
                    {
                        transform.SetParent(dropzone.transform, false);
                        disp.cardTemplate.current_Rg = dropzone.tag;
                    }
                    else
                    {
                        //Es un Decoy, regreso la carta a la mano
                        CardDisplay exchange=dropzone.GetComponent<CardDisplay>();
                        disp.cardTemplate.current_Rg=exchange.cardTemplate.current_Rg;
                        Transform drop= dropzone.transform.parent;
                        transform.SetParent(drop.transform, false);
                        efectos.RestartCard(dropzone, null, true);
                    }
                    Played = true;
                    
                    if(disp.cardTemplate.type== "U")
                        efectos.PlayCard(disp.cardTemplate);
                    efectos.ListEffects[disp.cardTemplate.Eff].Invoke(disp.cardTemplate);
                    GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
                    GM.Turn1= !GM.Turn1;
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
        GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        if(disp.cardTemplate.DownBoard == GM.Turn1)
        if (disp.cardTemplate.type.IndexOf("C") == -1)
            if (disp.cardTemplate.type.IndexOf("A") == -1)
            {
                if (disp.cardTemplate.type.IndexOf('D') == -1)
                {
                    if (dropzone.transform.childCount < 6 && disp.cardTemplate.Atk_Rg.IndexOf(dropzone.tag) != -1 && efectos.RangeMap[(disp.cardTemplate.DownBoard, dropzone.tag)] == dropzone)
                    {
                        return true;
                    }
                }
                else
                {
                    if (dropzone.tag == "Card")
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


    public GameObject BigCardPrefab;
    GameObject Big;
    public GameObject Visualizer;
    public Vector3 zoneBig= new Vector3(1800, 300);
    public void BigCardProduce() 
    {
        if (!IsDragging)
        {
            CardDisplay card = gameObject.GetComponent<CardDisplay>();
            Big = Instantiate(BigCardPrefab, zoneBig, Quaternion.identity);
            Big.transform.SetParent(Visualizer.transform, worldPositionStays: true);
            Big.transform.position = zoneBig;
            CardDisplay disp = Big.GetComponent<CardDisplay>();
            disp.cardTemplate = card.cardTemplate;
            disp.ArtworkImg = Big.transform.GetChild(0).GetComponent<Image>();
            if (disp.ArtworkImg != null)
                disp.DescriptionText = Big.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            disp.PwrTxt = Big.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        }
    }
    public void BigCardDestroy()
    {
        Destroy(Big);
    }
}
