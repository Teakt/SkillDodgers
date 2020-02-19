using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public GameObject player;       //Public variable to store a reference to the player game object
    public float resetDistance;
    public float speedMouvementCamera;
    public Vector3 offset;//Position initial de la camera par rapport au joueur


    private Camera cam;

    //private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {   /*
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
        */

        cam = GetComponent<Camera>();

        

    }

    // LateUpdate is called after Update each frame
    void FixedUpdate()
    {/*
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;*/
        Vector3 newposition = transform.position;

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (Mathf.Abs(distance) > resetDistance)
        {

            if (Mathf.Abs(distance) > resetDistance)
            {
                Vector2 direction = (player.transform.position - transform.position);
                direction.Normalize();
                direction = resetDistance * direction;
                newposition = Vector2.Lerp(transform.position, player.transform.position,speedMouvementCamera*Time.deltaTime);
            }
            
            transform.position = newposition+offset;
        }


    }
}