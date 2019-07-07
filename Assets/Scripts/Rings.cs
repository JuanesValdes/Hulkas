using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rings : MonoBehaviour
{
    public int pointsToAdd;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name=="Sanic")
        {
            Puntaje.AddPoints(pointsToAdd);
            Destroy(gameObject);
            Debug.Log(pointsToAdd);
        }
        


    }
}
