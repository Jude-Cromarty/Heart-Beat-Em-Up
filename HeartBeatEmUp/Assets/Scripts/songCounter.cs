using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class songCounter : MonoBehaviour
{
    public float AttackTime;
    public float Delay;
    public bool canAttack;
    public GameObject player;
    AudioSource Howling;
    // Start is called before the first frame update
    void Start()
    {
      Howling  = GetComponent<AudioSource>();
      Howling.Play();
      StartCoroutine(SongTimings());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
//player.GetComponent<PlayerMovement>().Attack();
    IEnumerator SongTimings()
    {
        yield return new WaitForSeconds(25.4f);
        canAttack = true;
        yield return new WaitForSeconds(AttackTime);
        canAttack = false;

        for (int i = 0; i < 20; i++)
        { 
        yield return new WaitForSeconds(Delay);
        canAttack = true;
        yield return new WaitForSeconds(AttackTime);
        canAttack = false;
        }
    }
}
