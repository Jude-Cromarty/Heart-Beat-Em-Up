using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecamera : MonoBehaviour
{
public float speed; //adjust this in the inspector to make the scroll speed less or more
 
 void Update(){
 
 transform.Translate( speed, 0, 0);
 }
}
