using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecamera : MonoBehaviour
{
public float speed, delay, actualspeed, nextactualspeed, waitTime; //adjust this in the inspector to make the scroll speed less or more
 
 void Update(){
 
 transform.Translate( speed, 0, 0);
 
 }
void Start(){StartCoroutine(move());}
 IEnumerator move()
 {
    yield return new WaitForSeconds(delay);
    speed += actualspeed;
    yield return new WaitForSeconds(10);
    speed += nextactualspeed;
    yield return new WaitForSeconds(waitTime);
    speed = 0.001f;
 }
}
