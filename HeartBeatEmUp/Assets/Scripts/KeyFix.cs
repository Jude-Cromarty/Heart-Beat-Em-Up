using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFix : MonoBehaviour
{
    public bool GotInput;
    public KeyCode Corresponding_Key;
    // Start is called before the first frame update
    void Start()
    {
        //bool gotinput = GameObject.Find("HeartOHearts").GetComponent<HeartFix>().GotInput;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(KeyToMyHeart());
    }

    IEnumerator KeyToMyHeart()
    {
        //if key was pressed set gotinput to true
        
        if(Input.GetKey(Corresponding_Key))
        {
           GotInput = true;
           GetComponent<AudioSource>().Play();
        }
        else 
        {
            GotInput = false;
            yield break;
        }
    }
}
