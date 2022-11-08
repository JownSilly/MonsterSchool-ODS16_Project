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
    public Image teacherIconM;
    public Image studentsIconM;
    public Image parentsIconM;
    public Image moneyIconM;
    //UI impact icon
    void Update()
    {
        //UI ICONS 
        teacherIconM.fillAmount = (float) GameManager.teacherIconM / GameManager.maxValue;
        studentsIconM.fillAmount = (float) GameManager.studentsIconM / GameManager.maxValue;
        parentsIconM.fillAmount = (float) GameManager.parentsIconM / GameManager.maxValue;
        moneyIconM.fillAmount = (float) GameManager.moneyIconM / GameManager.maxValue;
        //UI impact icon
        //Right
        if (card.transform.position.x > 0)
        {

        }
    }
}
