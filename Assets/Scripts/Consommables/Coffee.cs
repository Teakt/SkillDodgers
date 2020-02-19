using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : Consommables {

    public int bonusSpeed = 5;
    
    public GameObject coffeePrefab;
    void Start()
    {
        // Spawn food every 4 seconds, starting in 3
        //InvokeRepeating("Spawn", 3, 5);
        StartCoroutine(Comportement());

    }

    // Update is called once per frame
    void Update () {
		
	}

    
   

    public override void Action(GameObject player)
    {
        
        

        PlayerManager.instance.speed = PlayerManager.instance.speed + bonusSpeed;

        //Debug.Log("inActionCoffee");
        //Debug.Log(PlayerManager.instance.speed);

        

    }

    public override void Spawn()
    {
        // x position between left & right border
        int x = (int)Random.Range(-5,5);
        // y position between top & bottom border
        int y = (int)Random.Range(-5,5);

        Instantiate(coffeePrefab,
            new Vector2(x, y),
            Quaternion.identity); // default rotation
    }

    IEnumerator Comportement()
    {


        yield return new WaitForSeconds(4f);

        Destroy(gameObject);

    }

}
