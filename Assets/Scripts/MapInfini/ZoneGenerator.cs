using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ZoneGenerator : MonoBehaviour {

    public List<Spawner> spawners;
    public List<Consommables> consommables;
    public List<GameObject> grounds;
    public int minConsommable = 0;
    public int maxConsommable = 5;
    public int minSpawner = 0;
    public int maxSpawner= 8;

    public static ZoneGenerator instance;


    private void Awake() // Awake est appelé avant Start() , c'est dédié pour les controller par exemple , pour les Singletons 
    {
        if (instance == null)  // renforce le Singleton en vérifiant qu'il n'ya pas d'autres instances de GameController
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);  // Detruit cette instance de GameController si il y en a déjà 1 
        }

        GameObject initialGround = generateZone(0, 0, 12.3f);

        initialGround.GetComponent<Ground>().GenerateNeighbour();

       

        

        
    }

   
    // Use this for initialization
    public GameObject generateZone (float x,float y,float length) {
        int ground = Random.Range(0, grounds.Count);
        int consommable = Random.Range(0, consommables.Count);



        GameObject tempGround = Instantiate(grounds[ground], new Vector2(x,y),Quaternion.identity);


        for(int i = minSpawner; i < Random.Range(0, maxSpawner + 1); i++)
        {
            float sizeX = Random.Range(-length, length);
            float sizeY = Random.Range(-length, length);
            Instantiate(spawners[Random.Range(0, spawners.Count)], new Vector2(x+sizeX, y+sizeY), Quaternion.identity);
        }

        for (int i = minConsommable; i < Random.Range(0, maxConsommable + 1); i++)
        {
            float sizeX = Random.Range(-length, length);
            float sizeY = Random.Range(-length, length);
            Instantiate(consommables[Random.Range(0, consommables.Count)], new Vector2(x + sizeX, y + sizeY), Quaternion.identity);
        }


        return tempGround;


    }


   
}
