using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class GameManager : MonoBehaviour
{
    //Gerenciamento Escola
    public static int teacherIconM;
    public static int studentsIconM;
    public static int parentsIconM;
    public static int moneyIconM;
    public static int maxValue = 100;
    public int minValue = 0;
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
    public string direction;
    //Variaveis de Cartas
    private string leftQuote;
    private string rightQuote;
    public Card currentCard;
    public Card testCard;
    //Numero aleatorio
    public int randomNumber;
    public int rMinValue;
    public int rMaxValue;
    public List<int> repeatedNumber = new List<int>();
    void Start()
    {
        NewCard();
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
        //Logica de valores de gerenciamento
        textColor.a = Mathf.Min((Mathf.Abs(cardGameObject.transform.position.x) - fSideMargin) / divideValue, 1);
        //Dialogo Texto
        if (cardGameObject.transform.position.x > fSideTrigger)
        {
            direction = "right";
            if (Input.GetMouseButtonUp(0))
            {
                currentCard.Right();
                NewCard();
            }
        }else if (cardGameObject.transform.position.x > fSideMargin)
        {
            direction = "right";
        }
        else if (cardGameObject.transform.position.x > -fSideMargin)
        {
            direction = "none";
            textColor.a = 0;
        }
        else if (cardGameObject.transform.position.x > -fSideTrigger)
        {
            direction = "left";
        }
        else
        {
            direction = "left";
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
        //display.text = ""+ textColor.a;
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
        randomNumber = RandomNumb();
        if (randomNumber >= 0) {
            LoadCard(resourceManager.cards[randomNumber]);
        }
        else
        {
            Debug.LogError("Todos os numero foram sorteados");
        }   
    }
    public int RandomNumb()
    {
        if(Mathf.Abs(resourceManager.cards.Length - rMinValue)> repeatedNumber.Count)
        {
            while (true)
            {
                int random = Random.Range(rMinValue, resourceManager.cards.Length);
                if (!repeatedNumber.Contains(random))
                {
                    repeatedNumber.Add(random);
                    return random;
                }
            }
        }
        else
        {
            return -1;
        }
    }
}
