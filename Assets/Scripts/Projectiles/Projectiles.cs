using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class Projectiles : MonoBehaviour {

    

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.tag);
        if (!other.CompareTag("Player"))
        {
            return;
        }

        Action(other.GetComponent<GameObject>());
        //this.gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public abstract void Action(GameObject player); // Pour pouvoir le définir dans les classe filles

    public abstract void Spawn();
}
