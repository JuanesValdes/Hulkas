using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muertemono : MonoBehaviour
{

    public GameObject enemigo;




    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(enemigo);
            Debug.Log("le pegaste");
        }

    }
}
