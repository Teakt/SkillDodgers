using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingTeacher : Spawner
{
    
    public Sprite goodTeacher;//Sprite du teacher netraliser
    public int numberBoost; // Nombre de consommable drop meme tps par le "bon" proffesseur
    public GameObject coffee; //Prefab du caffe
    public int range;// Portee du proffesseur
    public int speed;// vitesse des projectiles

    private SpriteRenderer sprite;
    private List<GameObject> listConsommable = new List<GameObject>(); // list des consommables qui spawn
    private float timeSinceLastSpawned = 0;// Permet de faire apparraitre les projectiles
    private bool good = false; //Permet de savoir si le prof est neutraliser


    // Use this for initialization
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        //iniatilisation de la list des consomables
        for (int i = 0; i < numberBoost; i++)
        {

            GameObject temp = Instantiate(coffee);
            temp.SetActive(false);
            //Destroy(temp);
            listConsommable.Add(temp);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (good)
            GoodBehavior();
        else
            BadBehaviour();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            BecommeGood();
        
    }

    private void BecommeGood()
    {
        sprite.sprite = goodTeacher;
        GetComponent<BoxCollider2D>().enabled = false;//Pour des soucis de performance
        timeSinceLastSpawned = 0;
        good = true;
    }

    
    private void BadBehaviour()
    {
        // Debug.DrawLine(transform.position, new Vector2(transform.position.x+range,transform.position.y),Color.red,5f);
        
        this.gameObject.SetActive(false);
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, (2 * Mathf.PI)*range, new Vector2(0, 0), 3, LayerMask.GetMask("Player"));
        this.gameObject.SetActive(true);
        if (hit)
        {
            //Debug.Log("Player found"+ hit.rigidbody.transform.position);
            Debug.DrawLine(transform.position, hit.rigidbody.transform.position,Color.magenta,0.1f);
            timeSinceLastSpawned += Time.deltaTime;
            if (timeSinceLastSpawned >=  spawnRate)//Si timeSinceLastSpawned depasse le spawnRate il faut faire spawn un object si possible
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


    /*
    //Spawn des consommable a intervalles regullier
    private void GoodBehavior()
    {

        timeSinceLastSpawned += Time.deltaTime;//augmente a chaque frame

        if (timeSinceLastSpawned >= (2 * spawnRate))//Si timeSinceLastSpawned depasse le spawnRate il faut faire spawn un object si possible
        {
            timeSinceLastSpawned = 0f;

           


            //cette boucle for sert a faire apparaitre un consommable s'il ne sont pas tous deja apparu
            GameObject temp = null;
            for (int i = 0; i < listConsommable.Count; i++)
            {
                if (!listConsommable[i].activeSelf)
                {
                    temp = listConsommable[i];
                    temp.transform.position = new Vector2(transform.position.x + spawnXPosition, transform.position.y + spawnYPosition);
                    temp.SetActive(true);
                    break;
                }
            }
        }
    }*/

    bool isSpawn = false;
    //Spawn des consommables une seul fois
    private void GoodBehavior()
    {
        if (isSpawn)
            return;

        isSpawn = true;
        //Set a random y position for the column
        float spawnXPosition = Random.Range(-range, range);
        float spawnYPosition = Random.Range(-range, range);


        GameObject temp = null;
        for (int i = 0; i < listConsommable.Count; i++)
        {
            if (!listConsommable[i].activeSelf)
            {
                temp = listConsommable[i];
                temp.transform.position = new Vector2(transform.position.x + spawnXPosition, transform.position.y + spawnYPosition);
                temp.SetActive(true);
            }
        } 
    }
}
