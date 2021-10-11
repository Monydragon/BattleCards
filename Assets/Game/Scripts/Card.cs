using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Card.asset",menuName ="BattleCards/Create Card")]
public class Card : ScriptableObject
{
    public int ID;
    public string Name;
    [TextArea]
    public string Description;
    public string CardType;
    [TextArea]
    public string Effect;
    public int AttackPower;
    public int DefensePower;
    public GameObject CardPrefab;
    public string MainImagePath;
    public Sprite MainImage;
    public string EnergyImagePath;
    public Sprite EnergyImage;
    public string CardTemplateImagePath;
    public Sprite CardTemplateImage;


    public void Use()
    {
        Debug.Log($"Card Used: {Name} with Effect: {Effect}");
    }
}
