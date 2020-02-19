using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGrade : Projectiles {

    public float rotationSpeed = 25f;
    
   
    public int attackDamage = 1;

    private float rotationBase = 0f ;

    Vector2 dir;
    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Comportement());
       
    }



    public override void Action(GameObject player)
    {
        PlayerManager.instance.hpCurrent = PlayerManager.instance.hpCurrent - attackDamage;
    }

    public override void Spawn()
    {
        throw new System.NotImplementedException();
    }

    
	
	// Update is called once per frame
	void Update () {
        rotationBase = rotationBase + rotationSpeed;
        transform.rotation =Quaternion.Euler(new Vector3(0, 0, rotationBase) * Time.deltaTime);
         
    }


    IEnumerator Comportement()
    {
        
        
        yield return new WaitForSeconds(4f);
        
        Destroy(gameObject);
       
    }
}
