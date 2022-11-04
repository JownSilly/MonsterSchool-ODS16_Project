using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Card_Logic : MonoBehaviour
{
    
    public TextMeshProUGUI tmp;
    public bool isMouseOver = false;
    // Start is called before the first frame update
    private void OnMouseOver()
    {
        isMouseOver = true;
    }

    // Update is called once per frame
    private void OnMouseExit()
    {
        isMouseOver = false;
    }

    public void InduceRight()
    {
        tmp.text = "Você tomou a decisão correta. Parabéns!";
    }

    public void InduceLeft()
    {
        tmp.text = "Essa sua decisão pode ter consequências desagradáveis no futuro. Fique atento!";
    }
}
