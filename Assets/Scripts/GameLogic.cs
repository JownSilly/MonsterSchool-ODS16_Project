using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameObject card;
    SpriteRenderer sr;
    public Card_Logic cl;
    public float fmovingSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {

        sr = card.GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && cl.isMouseOver)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            card.transform.position = pos;
        }
        else{
            card.transform.position = Vector2.MoveTowards(card.transform.position, new Vector2(0,0),fmovingSpeed);
        }
        
        //checando o lado
        //lado direito
        if(card.transform.position.x > 2)
        {
            sr.color = Color.green;
            if(!Input.GetMouseButton(0))
            {
                cl.InduceRight();
            }
        }
        // //lado esquerdo
        else if(card.transform.position.x < -2)
        {
            sr.color = Color.red;
            if(!Input.GetMouseButton(0))
            {
                cl.InduceLeft();
            }
        }
        //posição inicial
        else{
            sr.color = Color.white;
        }
    }
}
