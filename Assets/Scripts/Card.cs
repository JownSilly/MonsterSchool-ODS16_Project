using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Card : ScriptableObject
{
    //Basic Variables
    public int cardID;
    public string dialogueText;
    public string nameText;
    public string cardName;
    public CardSprite sprite;
    public string respostaEsquerda;
    public string respostaDireita;
    //Impact Values 
    //left
    public int mIconTeacherLeft;
    public int mIconStudentsLeft;
    public int mIconParentsLeft;
    public int mIconMoneyLeft;
    //right
    public int mIconTeacherRight;
    public int mIconStudentsRight;
    public int mIconParentsRight;
    public int mIconMoneyRight;
    public void Left()
    {
        Debug.Log(cardName + "Swuiped left");
        //Anexando os Valores
        GameManager.teacherIconM += mIconTeacherLeft;
        GameManager.studentsIconM += mIconStudentsLeft;
        GameManager.parentsIconM += mIconParentsLeft;
        GameManager.moneyIconM += mIconMoneyLeft;
    }
    public void Right()
    {
        Debug.Log(cardName + "swiped right");
        //Anexando os Valores
        GameManager.teacherIconM += mIconTeacherRight;
        GameManager.studentsIconM += mIconStudentsRight;
        GameManager.parentsIconM += mIconParentsRight;
        GameManager.moneyIconM += mIconMoneyRight;
    }
   }
