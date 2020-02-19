using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodGrade : Consommables
{

    //public int bonusSpeed = 5;

    
    void Start()
    {
        // Spawn food every 4 seconds, starting in 3
        //InvokeRepeating("Spawn", 3, 5);
        StartCoroutine(Comportement());

    }

    // Update is called once per frame
    void Update()
    {

    }




    public override void Action(GameObject player)
    {

        

        GameController.instance.score = GameController.instance.score + 100;



    }

    public override void Spawn()
    {
        
    }

    IEnumerator Comportement()
    {


        yield return new WaitForSeconds(4f);

        Destroy(gameObject);

    }

}
