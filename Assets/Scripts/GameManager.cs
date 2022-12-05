using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.SceneManagement;

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
    [SerializeField] private LevelChanger levelChanger;
    public ResourceManager resourceManager;
    public GameObject cardGameObject;
    public GameObject cardSprite;
    public CardController mainCardController;
    public GameObject currentSpriteObject;
    //Variaveis Ajustaveis
    public float fMovingSpeed;
    public float fSideMargin;
    public float fSideTrigger;
    public Color textColor;
    public Color opacityQuote;
    float alphaText;
    public float divideValue;
    Vector3 pos;
    //UI
    public TMP_Text actionQuote;
    public SpriteRenderer backgroundActionQuote;
    public TMP_Text display;
    public TMP_Text characterDialogue;
    public string direction;
    public string isNewCard;
    public TMP_Text daysText;

    //Variaveis de Cartas
    private string leftQuote;
    private string rightQuote;
    public Card currentCard;
    public Card testCard;
    public int days;
    //Numero aleatorio
    public int randomNumber;
    public int rMinValue;
    public int rMaxValue;
    public List<int> repeatedNumber = new List<int>();
    //sound
    public AudioSource woosh_effect;
    void Start()
    {
        teacherIconM = 50;
        studentsIconM = 50;
        parentsIconM = 50;
        moneyIconM = 50;
        NewCard();
    }
    void UpdateDialogue()
    {
        actionQuote.color = textColor;
        backgroundActionQuote.color = opacityQuote;
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
        opacityQuote.a = Mathf.Min((Mathf.Abs(cardGameObject.transform.position.x) - fSideMargin) / divideValue, .5f);
        //Dialogo Texto
        if (cardGameObject.transform.position.x > fSideTrigger)
        {
            direction = "right";
            if (Input.GetMouseButtonUp(0))
            {
                currentCard.Right();
                woosh_effect.Play();
                GameOvers();
                DestroyImmediate(currentSpriteObject);
                NewCard();
                isNewCard = "hasRight";
            }
        }else if (cardGameObject.transform.position.x > fSideMargin)
        {
            direction = "right";
        }
        else if (cardGameObject.transform.position.x > -fSideMargin)
        {
            direction = "none";
            opacityQuote.a = 0;
            textColor.a = 0;
            isNewCard = "none";
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
                woosh_effect.Play();
                GameOvers();
                DestroyImmediate(currentSpriteObject);
                NewCard();
                isNewCard = "hasLeft";
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
    }
    public void LoadCard(Card card)
    {
        currentSpriteObject = Instantiate(resourceManager.cardSpritePrefab[(int)card.sprite], new Vector3(cardSprite.transform.parent.position.x, cardSprite.transform.parent.position.y, 0), Quaternion.identity);
        currentSpriteObject.transform.SetParent(cardSprite.transform.parent);
        currentSpriteObject.transform.localScale = new Vector3(1, 1, 1);
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
            days++;
            daysText.text = days.ToString("00");
        }
        else
        {
            mainCardController.GetComponent<BoxCollider2D>().enabled = false;
            EndLevel();
            
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
    public void EndLevel()
    {
        float media = (teacherIconM + studentsIconM + moneyIconM + parentsIconM) / 4;
        if (media < 70)
        {
            levelChanger.FadeToLevel(2);
            StateEndGame.text_Option = "Sua nota foi inferior a 70, infelizmente você não se saiu tão bem, mas mesmo errando, aprendemos algo :) (TIPO ESSE JOGO Q FOI UM ERRO). Sua média ["+ media+"]";
        }
        else
        {
            levelChanger.FadeToLevel(2);
            StateEndGame.text_Option = "Sua nota foi Superior a 70, você se saiu bem como Diretor de primeira viajem, espero que sua jornada perdure. Sua média [" + media + "]";
        }
    }
    // Verifica o Fim do Jogo para Aquele que Zerarem algum dos Atributos
    public void GameOvers()
    {
        if (teacherIconM <= 0)
        {
            levelChanger.FadeToLevel(2);
            StateEndGame.text_Option = "Os professores organizaram um motin por conta da situação insalubre que você os deixou, ninguem está ao seu lado.";
        } else if (studentsIconM <= 0)
        {
            levelChanger.FadeToLevel(2);
            StateEndGame.text_Option = "Os estudantes estão descontente com a situação a qual a escola se encontra, não se sentem bem com o ambiente ou com o valor que possuem para escola, muitos estão saindo...";
        }
        else if (parentsIconM <= 0)
        {
            levelChanger.FadeToLevel(2);
            StateEndGame.text_Option = "O pais dos estudante acreditam que a escola não seja o ambiente ideal para seus filhos, estão optando por realoca-los em outras instituições.";
        }
        else if (moneyIconM <= 0)
        {
            levelChanger.FadeToLevel(2);
            StateEndGame.text_Option = "A verba escolar é praticamente inexistente, não será possivel manter siquer mais nenhum dia aberta, infelizmente é decretada a falência";
        }
    }
    
}
