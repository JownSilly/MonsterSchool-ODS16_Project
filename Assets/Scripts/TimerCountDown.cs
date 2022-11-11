using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountDown : MonoBehaviour
{
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
            currentTime -= 1 * Time.deltaTime;
            countDownText.text = currentTime.ToString("0");
            if (currentTime <= 3)
            {
                countDownText.color = colorText;
            }
            else
            {
                countDownText.color = standardColorText;
            }
        if (gameManager.randomNumber >=0) {
            if (currentTime <= 0)
            {
                // SE O CONTADOR ATINGIR 0, SERA TOMADA UMA DECIS�O ALEATORIA
                currentTime = 0;
                int random = Random.Range(1, 2);
                if (random == 1)
                {
                    gameManager.currentCard.Left();
                    gameManager.NewCard();
                    currentTime = startingTime;
                }
                else
                {
                    gameManager.currentCard.Right();
                    gameManager.NewCard();
                    currentTime = startingTime;
                }



            }
        }
        else
        {

        }
        
    }
    
}
