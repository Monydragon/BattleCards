using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Player : MonoBehaviour, IPlayer
{
    [SerializeField]
    private int health = 100;
    [SerializeField]
    private int greenEnergy = 0;
    [SerializeField]
    private int redEnergy = 0;
    [SerializeField]
    private int blueEnergy = 0;
    [SerializeField]
    private int whiteEnergy = 0;
    [SerializeField]
    private int blackEnergy = 0;
    [SerializeField]
    private int maxHandSize = 5;
    [SerializeField]
    private Card selectedCard;
    [SerializeField]
    private List<Card> hand;
    [SerializeField]
    private List<Card> deck;
    [SerializeField]
    private List<Card> discard;

    public int Health { get => health; set => health = value; }
    public int GreenEnergy { get => greenEnergy; set => greenEnergy = value; }
    public int RedEnergy { get => redEnergy; set => redEnergy = value; }
    public int BlueEnergy { get => blueEnergy; set => blueEnergy = value; }
    public int WhiteEnergy { get => whiteEnergy; set => whiteEnergy = value; }
    public int BlackEnergy { get => blackEnergy; set => blackEnergy = value; }
    public int MaxHandSize { get => maxHandSize; set => maxHandSize = value; }
    public Card SelectedCard { get => selectedCard; set => selectedCard = value; }
    public List<Card> Hand { get => hand; set => hand = value; }
    public List<Card> Deck { get => deck; set => deck = value; }
    public List<Card> Discard { get => discard; set => discard = value; }

    private void OnEnable()
    {
        EventManager.onUseCard += EventManager_onUseCard;
    }



    private void OnDisable()
    {
        EventManager.onUseCard += EventManager_onUseCard;
    }

    public void DiscardCard()
    {
        hand.Remove(selectedCard);
        discard.Add(selectedCard);
        EventManager.DiscardCard(selectedCard.CardPrefab, selectedCard, deck);
    }

    public void DrawCard()
    {
        int cardIndex = 0;
        for (int i = 0; i < deck.Count; i++)
        {
            if(i == deck.Count - 1) { selectedCard = deck[i]; cardIndex = i; }
        }
        deck.RemoveAt(cardIndex);
        hand.Add(selectedCard);
        EventManager.DrawCard(selectedCard.CardPrefab, selectedCard, deck);
    }

    public void UseCard()
    {
        selectedCard.Use();
        DiscardCard();
    }

    private void EventManager_onUseCard(Card card)
    {
        Debug.Log("Using Card from Player");
        card.Use();
        DiscardCard();
    }
}
