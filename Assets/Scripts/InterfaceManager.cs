using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InterfaceManager : MonoBehaviour
{
    //CARD
    public GameManager gameManager;
    public GameObject card;

    //UI ICONS
    public Transform teacherIcon;
    public Transform studentsIcon;
    public Transform parentsIcon;
    public Transform moneyIcon;
    public Image teacherIconFill;
    public Image studentsIconFill;
    public Image parentsIconFill;
    public Image moneyIconFill;
    //UI impact icon
    void Update()
    {
        //UI ICONS 
        teacherIconFill.fillAmount = (float) GameManager.teacherIconM / GameManager.maxValue;
        studentsIconFill.fillAmount = (float) GameManager.studentsIconM / GameManager.maxValue;
        parentsIconFill.fillAmount = (float) GameManager.parentsIconM / GameManager.maxValue;
        moneyIconFill.fillAmount = (float) GameManager.moneyIconM / GameManager.maxValue;
        //UI impact icon
        //Right
        if (gameManager.direction == "right")
        {
            if (gameManager.currentCard.mIconTeacherRight != 0)
            {
                teacherIcon.localScale = new Vector3((float)1.2, (float)1.2, 0);
            }
            if (gameManager.currentCard.mIconStudentsRight != 0)
            {
                studentsIcon.localScale = new Vector3((float)1.2, (float)1.2, 0);
            }
            if (gameManager.currentCard.mIconParentsRight != 0)
            {
                parentsIcon.localScale = new Vector3((float)1.2, (float)1.2, 0);
            }
            if (gameManager.currentCard.mIconMoneyRight != 0)
            {
                moneyIcon.localScale = new Vector3((float)1.2, (float)1.2, 0);
            }
        }
        else if(gameManager.direction == "left")
        {
            if (gameManager.currentCard.mIconTeacherLeft != 0)
            {
                teacherIcon.localScale = new Vector3((float)1.2, (float)1.2, 0);
            }
            if (gameManager.currentCard.mIconStudentsLeft != 0)
            {
                studentsIcon.localScale = new Vector3((float)1.2, (float)1.2, 0);
            }
            if (gameManager.currentCard.mIconParentsLeft != 0)
            {
                parentsIcon.localScale = new Vector3((float)1.2, (float)1.2, 0);
            }
            if (gameManager.currentCard.mIconMoneyLeft != 0)
            {
                moneyIcon.localScale = new Vector3((float)1.2, (float)1.2, 0);
            }
        }
        else
        {
            teacherIcon.localScale = new Vector3(1,1,0);
            studentsIcon.localScale = new Vector3(1, 1, 0);
            parentsIcon.localScale = new Vector3(1, 1, 0);
            moneyIcon.localScale = new Vector3(1, 1, 0);
        }
    }
}
