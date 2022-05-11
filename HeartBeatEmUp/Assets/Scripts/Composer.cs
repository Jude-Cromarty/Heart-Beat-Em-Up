using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Composer : MonoBehaviour
{
    public float Delay;
    static public int Composed;
    public int KeyNumber;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
          if(Composed == KeyNumber){
            StartCoroutine(Key1());}
    }

        IEnumerator Key1()
        {
            GetComponent<AudioSource>().Play();
         yield return new WaitForSeconds(Delay);
        }
}
