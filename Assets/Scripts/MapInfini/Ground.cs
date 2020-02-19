using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ground : MonoBehaviour {

    public bool playerIsHere = false; 
    SpriteRenderer ground;
    float tailleSpriteX;
    float tailleSpriteY;


    private Collider2D myCollider;

    

    void Start () {
        myCollider = GetComponent<Collider2D>(); // Permet de recup le collider de ce ground
        ground = GetComponent<SpriteRenderer>();
        

        tailleSpriteX = ground.size.x * 10;
        tailleSpriteY = ground.size.y * 10;
        //Debug.Log("X du sprite = " + tailleSpriteX + " et Y du sprite = " + tailleSpriteY);

        
    }
	
	// Update is called once per frame
	void Update () {

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.tag == "Player"))
        {
            return;
        }
        playerIsHere = true;

        GenerateNeighbour();




    }





    private void OnTriggerExit2D(Collider2D collision)
    {
        playerIsHere = false;
    }

    public bool GetPlayerIsHere()
    {
        return playerIsHere;
    }

    public Vector2 RadianToVector2(float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }

    public void GenerateNeighbour()
    {
       
        //Debug.Log("LE JOUEUR EST SUR MOI HELP" +playerIsHere);
        bool bdiago = false;
        for (float angle = 0; angle < 2 * Mathf.PI + 1; angle = angle + Mathf.PI / 4)
        {
            myCollider.enabled = false;
            Debug.DrawLine(transform.position, (Vector2)transform.position + RadianToVector2(angle) * tailleSpriteX, Color.cyan, 0f);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, RadianToVector2(angle), tailleSpriteX, LayerMask.GetMask("Ground"));
            myCollider.enabled = true;




            if (hit)
            {

                Debug.Log("TOUCHER");

            }
            else
            {
                Vector2 NoDiago = (Vector2)transform.position + RadianToVector2(angle) * tailleSpriteX;
                Vector2 Diago = (Vector2)transform.position + RadianToVector2(angle) * Mathf.Sqrt(2 * Mathf.Pow(tailleSpriteX, 2));
                //Debug.Log("OMAR SY");
                if (bdiago)
                {
                    ZoneGenerator.instance.generateZone(Diago.x, Diago.y, tailleSpriteX);
                }
                else
                {
                    ZoneGenerator.instance.generateZone(NoDiago.x, NoDiago.y, tailleSpriteX);
                }
            }

            bdiago = !(bdiago);
        }
    }
}
