using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildDeleter : MonoBehaviour
{

    public float Speed, Delay, FirstDelay;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(FirstDelay);
        foreach (Transform child in transform)
        {
            transform.Translate( 0, 0, Speed);
        }
        
    }
}
