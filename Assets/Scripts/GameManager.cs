using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class GameManager : MonoBehaviour
{
    //GAMEOBJECTS
    public ResourceManager resourceManager;
    public GameObject cardGameObject;
    public SpriteRenderer cardSpriteRenderer;
    public CardController mainCardController;
    //Variaveis Ajustaveis
    public float fMovingSpeed;
    public float fSideMargin;
    public float fSideTrigger;
    public Color textColor;
    float alphaText;
    public float divideValue;
    Vector3 pos;
    //UI
    public TMP_Text actionQuote;
    public TMP_Text display;
    public TMP_Text characterDialogue;
    //Variaveis de Cartas
    private string leftQuote;
    private string rightQuote;
    public Card currentCard;
    public Card testCard;
    void Start()
    {
        LoadCard(testCard);
    }
    void UpdateDialogue()
    {
        actionQuote.color = textColor;
        if(cardGameObject.transform.position.x < 0)
        {
            actionQuote.text = leftQuote;
        }
        else
        {
            actionQuote.text = rightQuote;
        }
    }
    void Update()
    {
        textColor.a = Mathf.Min((Mathf.Abs(cardGameObject.transform.position.x) - fSideMargin) / divideValue, 1);
        //Dialogo Texto
        if (cardGameObject.transform.position.x > fSideTrigger)
        {
            if (Input.GetMouseButtonUp(0))
            {
                currentCard.Right();
                NewCard();
            }
        }else if (cardGameObject.transform.position.x > fSideMargin)
        {

        }
        else if (cardGameObject.transform.position.x > -fSideMargin)
        {
            textColor.a = 0;
        }
        else if (cardGameObject.transform.position.x > -fSideTrigger)
        {
            
        }
        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                currentCard.Left();
                NewCard();
            }
        }
        UpdateDialogue();
        //movement
        if (Input.GetMouseButton(0) && mainCardController.isMouseOver)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            cardGameObject.transform.position = pos;
        }
        else
        {
            cardGameObject.transform.position = Vector2.MoveTowards(cardGameObject.transform.position, new Vector2(0, 0), fMovingSpeed);
        }
        //UI
        display.text = ""+ textColor.a;
    }

    public void LoadCard(Card card)
    {
        cardSpriteRenderer.sprite = resourceManager.sprites[(int)card.sprite];
        leftQuote = card.respostaEsquerda;
        rightQuote = card.respostaDireita;
        currentCard = card;
        characterDialogue.text = card.dialogueText;
    }
    public void NewCard()
    {
        int rollDice = Random.Range(0, resourceManager.cards.Length);
        LoadCard(resourceManager.cards[rollDice]);
    }
}
