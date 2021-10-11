using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    public delegate void D_Void();
    public delegate void D_GameObjectAndCardAndDeck(GameObject go, Card card, List<Card> deck);
    public delegate void D_Card(Card card);

    public static event D_GameObjectAndCardAndDeck onDrawCard;
    public static event D_GameObjectAndCardAndDeck onDiscardCard;
    public static event D_Card onUseCard;

    public static void DrawCard(GameObject go, Card card, List<Card> deck) { onDrawCard?.Invoke(go, card, deck); }
    public static void DiscardCard(GameObject go, Card card, List<Card> deck) { onDiscardCard?.Invoke(go, card, deck); }

    public static void UseCard(Card card) { onUseCard?.Invoke(card); }

}
