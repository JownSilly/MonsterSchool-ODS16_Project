using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public Card card;
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
public class Card
{
    public int cardID;
    public string cardName;
    public CardSprite sprite;
    public string leftQuote;
    public string rightQuote;
    public void Left()
    {
        Debug.Log(cardName + "Swuiped left");
    }
    public void Right()
    {
        Debug.Log(cardName + "swiped right");
    }
}
public enum CardSprite
{
    MAN,
    WOMAN,
    KNIGHT
}
