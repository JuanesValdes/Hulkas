using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sanic_controler:MonoBehaviour
{
    public float SanicSpeed;
    private Rigidbody2D SanicRigid;
    private Animator SanicAnim;
    public float SanicImpulse;
    public bool JumpLock;
    public bool JumpLock2;

    public bool Controles;

    public static Sanic_controler instance;

    public Transform firepoint;
    


    // Start is called before the first frame update
    void Start()
    {
        SanicSpeed = 5;
        SanicRigid= GetComponent<Rigidbody2D>();
        SanicAnim= GetComponent<Animator>();
       SanicImpulse = 9;
        JumpLock = false;
        
        Controles = true;

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.D))&& Controles==true)
        {
            SanicRigid.velocity = new Vector2(SanicSpeed, 0);
            transform.localScale = new Vector2(1f, 1f);
            SanicAnim.SetBool(name: "Player_Run", value: true);
            SanicAnim.SetBool(name: "Player_Jump", value: false);
            SanicAnim.SetBool(name: "Player_Idle", value: false);
        }
        else
        {
            SanicAnim.SetBool(name: "Player_Run", value: false);
        }
        if ((Input.GetKey(KeyCode.A)) && Controles == true)
        {
            SanicRigid.velocity = new Vector2(-SanicSpeed, 0);
            transform.localScale = new Vector2(-1f, 1f);
            SanicAnim.SetBool(name: "Player_Run", value: true);
            SanicAnim.SetBool(name: "Player_Jump", value: false);
            SanicAnim.SetBool(name: "Player_Idle", value: false);
        }
        if ((Input.GetKeyDown(KeyCode.Space))&& (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.A) && Controles == true)))
        {
            jump();
            SanicAnim.SetBool(name: "Player_Jump", value: true);
            SanicAnim.SetBool(name: "Player_Idle", value: false);
        }
        if ((Input.GetKey(KeyCode.Space))&& (Input.GetKey(KeyCode.D))&& Controles == true)
        {
            SanicRigid.velocity = new Vector2(3, SanicImpulse);
            Debug.Log("saltando de lado derecho");
            SanicAnim.SetBool(name: "Player_Jump", value: true);
            SanicAnim.SetBool(name: "Player_Idle", value: false);
        }
        
        if ((Input.GetKey(KeyCode.Space)) && (Input.GetKey(KeyCode.A)) && Controles == true)
        {
            SanicRigid.velocity = new Vector2(-3, SanicImpulse);
            Debug.Log("saltando de lado izquierdo");
            SanicAnim.SetBool(name: "Player_Jump", value: true);
            SanicAnim.SetBool(name: "Player_Idle", value: false);
        }
        

    }


    void jump()
    {
        if(JumpLock == false)
        {
            SanicRigid.velocity = new Vector2(0, SanicImpulse);
            JumpLock = true;
           
            Debug.Log("saltando");
        }
       
         
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Piso") 
        {
            Debug.Log("colisiono");
            JumpLock = false;
            
            Controles = true;
           

        }
        



    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Piso") 
        {

            Controles = false;

        }
    }
    public float obtenerX()
    {
        return transform.position.x;
    }

    private void Awake()
    {
        
        if (SanicSpeed == 0)
        {
            SanicAnim.SetBool(name: "Player_Idle", value: true);
            SanicAnim.SetBool(name: "Player_Jump", value: false);
        }
    }
}