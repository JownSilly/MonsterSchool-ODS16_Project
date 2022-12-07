using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountDown : MonoBehaviour
{
    public Animator animatorRelogio;
    public bool isTrigger;
    public GameManager gameManager;
    public float currentTime = 0f;
    public float startingTime = 15f;
    [SerializeField] TMP_Text countDownText;
    public Color colorText;
    public Color standardColorText;
    // Start is called before the first frame update
    public void Start()
    {
        currentTime = startingTime; 
    }
    public void Update()
    {
        //Reiniciar Caso Escolha algum lado
        if (gameManager.isNewCard == "hasLeft" || gameManager.isNewCard == "hasRight")
        {
            currentTime = startingTime;
        }
            //Contador
            
        if (gameManager.randomNumber >=0) {
            
            if(currentTime > 0)
            {
                currentTime -= 1 * Time.deltaTime;
                countDownText.text = "00:"+ currentTime.ToString("00");
                if (currentTime <= 3)
                {
                    countDownText.color = colorText;
                    animatorRelogio.SetBool("isAlarming", true);
                }
                else
                {
                    animatorRelogio.SetBool("isAlarming", false);
                    countDownText.color = standardColorText;
                }
            }
            else if(currentTime <= 0)
            {
                // SE O CONTADOR ATINGIR 0, SERA TOMADA UMA DECISÃO ALEATORIA
                currentTime = 0;
                int random = Random.Range(1, 3);
                if (random == 1)
                {
                    gameManager.currentCard.Left();
                    gameManager.GameOvers();
                    DestroyImmediate(gameManager.currentSpriteObject);
                    gameManager.NewCard();
                    currentTime = startingTime;
                }
                else
                {
                    gameManager.currentCard.Right();
                    gameManager.GameOvers();
                    DestroyImmediate(gameManager.currentSpriteObject);
                    gameManager.NewCard();
                    currentTime = startingTime;
                }
            }
        }
        else
        {
            //AS CARTAS ACABARAM, NECESSÁRIA A CHAMADA DE CENA DE FEEDBACK DE DESENVOLVIMENTO 

        }
        
    }
    
}
