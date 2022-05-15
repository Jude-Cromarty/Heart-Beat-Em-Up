using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecameraactual : MonoBehaviour
{
public float delay, actualspeed, nextactualspeed, waitTime, speedY; //adjust this in the inspector to make the scroll speed less or more
 
 void Update(){
 
 transform.Translate( 0, speedY, 0);
 
 }
void Start(){StartCoroutine(move());}
 IEnumerator move()
 {
    yield return new WaitForSeconds(delay);
    speedY += actualspeed;
    yield return new WaitForSeconds(waitTime);
    speedY = 0;
 }
}