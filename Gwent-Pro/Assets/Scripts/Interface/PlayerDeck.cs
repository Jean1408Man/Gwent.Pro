using LogicalSide;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class PlayerDeck : MonoBehaviour
{
    public GameObject prefabCarta; // El prefab gen�rico de la carta
    public GameObject prefabLeader;
    public Transform playerZone; // El lugar donde se colocar� la carta del jugador
    public GameObject PlayerHand;
    public Transform Leaderzone;
    public List<Card> deck; // Tu lista de cartas
    public List<Card> cement;
    
    // M�todo para instanciar la �ltima carta del mazo
    public void Instanciate(Card card, Transform zone, GameObject prefab)
    {
        GameObject instanciaCarta = Instantiate(prefab, zone);
        CardDisplay disp=instanciaCarta.GetComponent<CardDisplay>();
        disp.cardTemplate = card;
        disp.ArtworkImg = instanciaCarta.transform.GetChild(0).GetComponent<Image>();
        disp.DescriptionText = instanciaCarta.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        disp.PwrTxt = instanciaCarta.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        deck.Remove(card);
    }
    public void InstanciateLastOnDeck( int n, bool exception)
    {
        if (deck.Count > 0 && (playerZone.childCount <= 9 || exception )&& n>0)
        {
            Card card = deck[deck.Count - 1];
            GameObject instanciaCarta = Instantiate(prefabCarta, playerZone);
            CardDisplay disp = instanciaCarta.GetComponent<CardDisplay>();
            disp.cardTemplate = card;
            disp.ArtworkImg = instanciaCarta.transform.GetChild(0).GetComponent<Image>();
            disp.DescriptionText = instanciaCarta.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            disp.PwrTxt = instanciaCarta.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
            deck.Remove(card);
            GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
            if (PlayerHand.tag.IndexOf("DE") != -1)
            {
                playerZone.GetChild(playerZone.childCount - 1).Rotate(0, 0, 180);
            }
            InstanciateLastOnDeck(n - 1, exception);
        }
    }
    public void OnClick()
    {
        if(deck.Count > 0)
        InstanciateLastOnDeck(1,false);
    }
    public void Shuffle(List<Card> deck)
    {
        System.Random random = new System.Random();
        Instanciate(deck[0],Leaderzone, prefabLeader);
        if(Leaderzone.name == "LeaderplaceEnemy")
            Leaderzone.transform.GetChild(0).Rotate(0, 0, 180);
        int n = deck.Count;
        while (n > 0)
        {
            n--;
            int k = random.Next(n + 1);
            (deck[n], deck[k]) = (deck[k], deck[n]);
        }
        InstanciateLastOnDeck(10,false);
    }

}