using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Card : ScriptableObject
{
    
    public int cardID;
    public string dialogueText;
    public string cardName;
    public CardSprite sprite;
    public string respostaEsquerda;
    public string respostaDireita;
    public void Left()
    {
        Debug.Log(cardName + "Swuiped left");
    }
    public void Right()
    {
        Debug.Log(cardName + "swiped right");
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
 
        
    
}
