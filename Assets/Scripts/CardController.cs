using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{


    private BoxCollider2D thisCard;
    public bool isMouseOver;
    private void Start()
    {
        thisCard = gameObject.GetComponent<BoxCollider2D>();

    }
    private void OnMouseOver()
    {
        isMouseOver = true;
    }
    private void OnMouseExit()
    {
        isMouseOver = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum CardSprite
{
    ProfessorCarlos_Biologia,
    ProfessoraMarta_Historia,
    AlunoJuninho_ZeFoguinho
}
