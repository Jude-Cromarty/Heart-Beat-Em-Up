using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
//finds reverb comp on all tagged objects then puts in array.
    public AudioReverbFilter[] key;
     void Awake(){
      GameObject[] keyed = GameObject.FindGameObjectsWithTag("Keys");
      key = new AudioReverbFilter[keyed.Length];
      for ( int i = 0; i < keyed.Length; ++i )
            key[i] = keyed[i].GetComponent<AudioReverbFilter>();
            
            
 
    }

}