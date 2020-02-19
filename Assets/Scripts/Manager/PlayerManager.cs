using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerManager : MonoBehaviour {

    
    public static PlayerManager instance; // Permet de rendre l'instance unique et permettre aux autres objets,scripts de lui faire appel

    public bool isDead = false ; //variable qui permet de dire si le personnage est mort

    public int hpCurrent = 3; // Les vies du joueur duuh
    public int hpMax = 3; // Les vies du joueur duuh

    public Text HPtext;

    public int speed = 40;

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
    }

  
	
	// Update is called once per frame
	void FixedUpdate () {
        GameController.instance.PlayerIsScoring(); // le score monte tant que le joueur est vivant
        PlayerHpIsUpdating(); // Gere les hp en live
        PlayerNoLife();
        //Debug.Log(hpCurrent + "/" + hpMax);
        //Debug.Log("IsDead =" + isDead.ToString());

    }

    public void PlayerNoLife()
    {
        if(hpCurrent == 0)
        {
            isDead = true;
            GameController.instance.PlayerIsDead();

        }
    }

    public void PlayerHpIsUpdating()
    {
        if(GameController.instance.GameIsOver == true) // si le joueur meurt on sort 
        {
            return;
        }
        HPtext.text = "HP : " + hpCurrent + "/" + hpMax; // affichage des pv sur l'UI
    }

    

    
}
