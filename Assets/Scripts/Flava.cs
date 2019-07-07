using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Flava : MonoBehaviour
{

    [SerializeField] private string newLevel;






    void OnTriggerEnter2D(Collider2D lava)
    {
        if (lava.gameObject.CompareTag("Player"))
        {

            SceneManager.LoadScene(newLevel);

        }
    }

}
