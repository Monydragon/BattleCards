using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class PlayerCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Card playerCard;
    public GameObject playerGo;
    public Player player;

    [SerializeField]
    private TMP_Text nameText;
    [SerializeField]
    private TMP_Text cardTypeText;
    [SerializeField]
    private TMP_Text descriptionText;
    [SerializeField]
    private TMP_Text attackAndDefenseText;
    [SerializeField]
    private Image cardTemplateImage;
    [SerializeField]
    private Image cardImage;
    [SerializeField]
    private Image energyImage;

    public Vector3 zoomVector;
    private Vector3 cachedScale;


    // Start is called before the first frame update
    void Start()
    {
        cachedScale = transform.localScale;
        playerGo = GameObject.FindGameObjectWithTag("Player");
        player = playerGo.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        nameText.text = playerCard.Name;
        cardTypeText.text = playerCard.CardType;
        descriptionText.text = playerCard.Description;
        attackAndDefenseText.text = $"Attack: {playerCard.AttackPower} Defense: {playerCard.DefensePower}";
        cardTemplateImage.sprite = playerCard.CardTemplateImage;
        cardImage.sprite = playerCard.MainImage;
        energyImage.sprite = playerCard.EnergyImage;

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = zoomVector;
        player.SelectedCard = playerCard;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = cachedScale;
    }

    public void UseCard()
    {
        Debug.Log("Used Card");
        EventManager.UseCard(playerCard);
        playerCard.Use();
        //Destroy(gameObject);
    }
}
