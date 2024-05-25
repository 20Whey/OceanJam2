using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sillyStuff : MonoBehaviour
{

    public bool tm;
    public bool isBub;
    private bool coRot;
    private bool wontColl;


void Start () {

    tm = false;
    isBub = false;
    coRot = false;
    wontColl = false;
}
    private IEnumerator reactiveBub(){
        float elpsedT = 0f;
        while (elpsedT < 6f)
        {
            elpsedT += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        isBub = false;
        coRot = false;
        tm = false;
        wontColl = false;
    }


    public void healthGetter(string name, int amount){
        if(!wontColl){
        switch(name){
            case "Player":
            gameObject.GetComponent<HealthScript>().TakeDamage(amount);
            reactiveBub();
            break;
        
            default:
            gameObject.GetComponent<EnemyScript>().TakeDamage(amount);
            reactiveBub();
            break;
        }
        wontColl = true;
    }

    }
    

    void Update (){
        if (isBub || tm) 
        if (!coRot){
            tm = true;
            StartCoroutine(reactiveBub());
            coRot = true;
          //  wontColl = true;
        }
    


    }

}
