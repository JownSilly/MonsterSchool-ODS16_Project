using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject cardGameObject;
    public SpriteRenderer cardSpriteRenderer;
    public CardController mainCardController;
    public float fMovingSpeed;
    public float fSideMargin;
    public float fSideTrigger;
    public TMP_Text dialogue;
    float alphaText;
    public Color textColor;
    Vector3 pos;
    public TMP_Text display;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Dialogo Texto
        
        textColor.a = Mathf.Min(Mathf.Abs(cardGameObject.transform.position.x/2), 1);
        dialogue.color = textColor;
        if (Input.GetMouseButton(0) && mainCardController.isMouseOver)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            cardGameObject.transform.position = pos;
        }
        else
        {
            cardGameObject.transform.position = Vector2.MoveTowards(cardGameObject.transform.position, new Vector2(0, 0), fMovingSpeed);
        }

        //checando o lado
        //lado direito
        if (cardGameObject.transform.position.x > fSideMargin)
        {
            //dialogue.alpha = Mathf.Min(cardGameObject.transform.position.x, 1);
            if (!Input.GetMouseButton(0) && cardGameObject.transform.position.x > fSideTrigger)
            {
                Debug.Log("Esquerda");
                //mainCardController.InduceRight();
            }
        }
        // //lado esquerdo
        else if (mainCardController.transform.position.x < -fSideMargin)
        {
            //dialogue.alpha = Mathf.Min(-cardGameObject.transform.position.x, 1);
            if (!Input.GetMouseButton(0)&& cardGameObject.transform.position.x > fSideTrigger)
            {
                Debug.Log("Direita");
                //cl.InduceLeft();
            }
        }
        //posição inicial
        else
        {
            cardSpriteRenderer.color = Color.white;
        }
        //UI
        display.text = ""+ textColor.a;
    }

    public void LoadCard(Card card)
    {
        //cardSpriteRenderer.sprite = 
    }
}
