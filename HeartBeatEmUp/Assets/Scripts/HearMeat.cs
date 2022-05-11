using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearMeat : MonoBehaviour
{
    public int currentHealth;
    static int amount;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (JustBeatIt());
    }

    // Update is called once per frame
    void Update()
    {
        //increase 2 then decrease 1 till 100.
        //wait 2 seconds
        //increase 2 then decrease 1 till 100.
    }

    IEnumerator JustBeatIt()
    {
        int i = 0;
        while (i < amount)
        {
            currentHealth = currentHealth += 20;
            healthBar.SetHealth(currentHealth);
        yield return new WaitForSeconds(1);
            currentHealth = currentHealth -= 10;
            healthBar.SetHealth(currentHealth);
        yield return new WaitForSeconds(1);
        i++;
        }

    }
}
