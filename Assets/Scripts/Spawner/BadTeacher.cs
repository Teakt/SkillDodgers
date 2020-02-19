using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadTeacher : Spawner {

    
    
    public float rotationspeed = 1f;
    public float speed ;
    public int range;
    Quaternion rotateToTarget;
    Vector3 dir;
    private float timeSinceLastSpawned = 0;
    //private Collider2D myCollider;




    // Use this for initialization
    void Start () {;
        //InvokeRepeating("Spawn", 3, spawnRate);
        //StartCoroutine("ASpawn");
        //myCollider = GetComponent<Collider2D>();
    }
	
	// Update is called once per frame
	void Update () {
       
        BadBehaviour();



    }

    //IEnumerator ASpawn()
    //{
    //    while (true)
    //    {



    //        // Instantiate the food at (x, y)
    //        GameObject temp = Instantiate(prefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity); // default rotation


    //        Rigidbody2D rb = temp.GetComponent<Rigidbody2D>();

    //        //Permet de tourner lesprite vers target
    //        dir = (Vector2)(target.transform.position) - rb.position;

    //        //float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
    //        //rb.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180 + angle));
    //        print(dir);

    //        dir.Normalize();
    //        rb.AddForce(dir * speed);

    //        yield return new WaitForSeconds(3);
    //    }
    //}

    //new void Spawn()
    //{
    //    // Instantiate the food at (x, y)
    //    GameObject temp = Instantiate(prefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity); // default rotation


    //    Rigidbody2D rb = temp.GetComponent<Rigidbody2D>();

    //    //Permet de tourner lesprite vers target
    //    dir = (Vector2)(target.transform.position) - rb.position;

    //    //float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
    //    //rb.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180 + angle));
    //    //print(dir);

    //    dir.Normalize();
    //    rb.AddForce(dir * speed);
    //}

    private void BadBehaviour()
    {
        //Debug.Log("LayerPlayer:"+LayerMask.NameToLayer("Player"));
        // Debug.DrawLine(transform.position, new Vector2(transform.position.x+range,transform.position.y),Color.red,5f);

        RaycastHit2D hit = Physics2D.CircleCast(transform.position, (2 * Mathf.PI)*range, new Vector2(0, 0), 3, LayerMask.GetMask("Player"));
        if (hit)
        {
            //Debug.Log("Player found"+ hit.rigidbody.transform.position);
            Debug.DrawLine(transform.position, hit.rigidbody.transform.position, Color.blue, 0.1f);
            timeSinceLastSpawned += Time.deltaTime;
            if (timeSinceLastSpawned >= spawnRate)//Si timeSinceLastSpawned depasse le spawnRate il faut faire spawn un object si possible
            {
                timeSinceLastSpawned = 0f;
                GameObject projectile = Instantiate(prefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity); // default rotation
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

                //Permet de tourner lesprite vers target
                Vector2 dir = (Vector2)(target.transform.position) - rb.position;
                dir.Normalize();
                rb.AddForce(dir * speed);
            }
        }
        
        /* 1-fair le raycasr pour regarder si le joueur est a cote 
           2-si le joueur in range lancer des projectiles sur le joueur avec le spawnRate et en updatant le timelastspawn
           3- sinon ne rien faire 
         */


    }



}
