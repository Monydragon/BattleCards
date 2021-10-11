using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiController : MonoBehaviour
{
    public Player player;
    public GameObject playerHand;
    public GameObject playerDeck;
    public TMP_Text playerHealthText;
    public TMP_Text greenEnergyText;
    public TMP_Text redEnergyText;
    public TMP_Text blueEnergyText;
    public TMP_Text blackEnergyText;
    public TMP_Text whiteEnergyText;

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
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthText.text = $"Health: {player.Health}";
        greenEnergyText.text = player.GreenEnergy.ToString();
        redEnergyText.text = player.RedEnergy.ToString();
        blueEnergyText.text = player.BlueEnergy.ToString();
        blackEnergyText.text = player.BlackEnergy.ToString();
        whiteEnergyText.text = player.WhiteEnergy.ToString();
    }

    private void EventManager_onDrawCard(GameObject go, Card card, List<Card> deck)
    {
        var pc = go.GetComponent<PlayerCard>();
        pc.playerCard = card;
        var goCard = Instantiate(go, playerHand.transform);
        goCard.name = card.Name;
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
            if (pc.playerCard.ID == card.ID)
            {
                Destroy(playerHand.transform.GetChild(i).gameObject);
                return;
            }
        }
    }
}
