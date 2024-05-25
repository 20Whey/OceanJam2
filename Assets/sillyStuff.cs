using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sillyStuff : MonoBehaviour
{

    public bool tm;
    public bool isBub;
    private bool coRot;


void Start () {

    tm = false;
    isBub = false;
    coRot = false;
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
    }



    

    void Update (){
        if (isBub || tm) 
        if (!coRot){
            tm = true;
            StartCoroutine(reactiveBub());
            coRot = true;
        }
    }

}
