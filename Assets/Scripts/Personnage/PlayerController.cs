using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public PauseMenu pausemenu; // Pour accéder à pause

    //public int speed = 10;
    private string lastDirection;//La dernier direction du personnage
    private Animator anim;
    private void Start()
    {
        lastDirection = "North";
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (pausemenu.getGameIsPaused())
        {
            return;
        }
        int speed = PlayerManager.instance.speed;
        //Debug.Log(speed);

        int InputX = 0;
        int InputY = 0;
        string nvDirection = "";
        bool up = Input.GetKey(KeyCode.UpArrow);
        bool down = Input.GetKey(KeyCode.DownArrow);
        bool left = Input.GetKey(KeyCode.LeftArrow);
        bool right = Input.GetKey(KeyCode.RightArrow);

        if ((up && down) || (!up && !down))//Si les touches haut et bas sont appuyer en meme tps aucune action est fait;
            InputY = 0;
        else
            InputY = up ? 1 : -1; 

        if ((left && right) || (!left && !right))//pareil avec gauche et droite
            InputX = 0;
        else
            InputX = right ? 1 : -1;

        //Pour effectuer un deplacement
        transform.Translate((0.1f * speed * InputX)* Time.deltaTime, (0.1f * speed * InputY) * Time.deltaTime, 0);
        //Debug.Log(Time.deltaTime);

        //Pour effectuer la bonne animation
        if (InputX == 0 && InputY == 0)//S'il le personnage ne bouge plus revenir a l'état IDLE(immobile)
            anim.SetTrigger("IDLE");
        else//Sinon joue l'animation de mouvement
        {
            if (InputY != 0)
                nvDirection = (InputY == -1) ? "South" : "North";
            if (InputX != 0)
                nvDirection = (InputX == -1) ? "West" : "Est";

            if (lastDirection == nvDirection)// Si vrai le personnage avance dans la meme direction donc il ne faut pas cancel l'animation en la rejouant;
                anim.SetTrigger("MOVE");
            else
            {//Il y a eu un changement de direction jouer l'animation adapter
                anim.Play(nvDirection + "MOVING");
                lastDirection = nvDirection;
            }

        } 
    }




}
