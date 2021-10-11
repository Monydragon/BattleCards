using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiController : MonoBehaviour
{
    public GameObject playerHand;
    public GameObject playerDeck;

    private void OnEnable()
    {
        EventManager.onDrawCard += EventManager_onDrawCard;
        EventManager.onDiscardCard += EventManager_onDiscardCard;
    }

    private void OnDisable()
    {
        EventManager.onDrawCard -= EventManager_onDrawCard;
        EventManager.onDiscardCard -= EventManager_onDiscardCard;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EventManager_onDrawCard(GameObject go, Card card, List<Card> deck)
    {
        var pc = go.GetComponent<PlayerCard>();
        pc.playerCard = card;
        Instantiate(go, playerHand.transform);
        if(deck.Count <= 0)
        {
            playerDeck.SetActive(false);
        }
        
    }

    private void EventManager_onDiscardCard(GameObject go, Card card, List<Card> deck)
    {
        for (int i = 0; i < playerHand.transform.childCount; i++)
        {
            var pc = playerHand.transform.GetChild(i).gameObject.GetComponent<PlayerCard>();
            if (pc.playerCard == card)
            {
                Destroy(playerHand.transform.GetChild(i).gameObject);
                return;
            }
        }
    }
}
