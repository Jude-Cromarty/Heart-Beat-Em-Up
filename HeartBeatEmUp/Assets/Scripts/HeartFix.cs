using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartFix : MonoBehaviour
{
    public KeyFix GotInput;
    public int Decay;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
     StartCoroutine(HeartDecline());
    }

    IEnumerator HeartDecline()
    {
        if(GotInput == true)
        {
            currentHealth += 1;
            yield break;
        }
        else if(GotInput == false)
        {
            currentHealth -= 1;
            yield return new WaitForSeconds(Decay);
        }
        else yield break;
    }
}
