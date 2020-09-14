using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecognisePlayer : MonoBehaviour
{
    public GameObject Zombie;
    Enemy scriptBrabo;


    void Start()
    {

      scriptBrabo.GetComponent<Enemy>();    

    }


    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {            
            //Zombie.GetComponent(Enemy).enabled = false;
            //GameObject.Find("other_object_name").GetComponent(B).enabled = false;

        //    scriptBrabo.enabled = false;
            Debug.Log("Acho que vi um soldadinho.");
        }    
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
          //  scriptBrabo.enabled = true;
            Debug.Log("Ihh, vi nada, deve ser impressão minha.");
        }    
    }
    
}