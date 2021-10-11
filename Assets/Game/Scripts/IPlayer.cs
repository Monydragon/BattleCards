using System.Collections.Generic;

public interface IPlayer
{
    int Health
    {
        get;
        set;
    }

    int GreenEnergy
    {
        get;
        set;
    }

    int RedEnergy
    {
        get;
        set;
    }

    int BlueEnergy
    {
        get;
        set;
    }

    int WhiteEnergy
    {
        get;
        set;
    }

    int BlackEnergy
    {
        get;
        set;
    }

    int MaxHandSize
    {
        get;
        set;
    }

    Card SelectedCard
    {
        get;
        set;
    }

    List<Card> Hand
    {
        get;
        set;
    }

    List<Card> Deck
    {
        get;
        set;
    }
    List<Card> Discard
    {
        get;
        set;
    }
    void DrawCard();
    void DiscardCard();
    void UseCard();
}