/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FDown : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool active = true;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        StartCoroutine(DamageMachine());
    }

    // Update is called once per frame
    void Update()
    {
        if(active == false)
        {
            active = true;
        }
    }
    IEnumerator DamageMachine()
    {
            while(active == true)
        {
            
            yield return new WaitForSeconds(0.2f);
            TakeDamage(1);
            active = false;
            yield return new WaitForSeconds(0.2f);
        }
    }
    void TakeDamage(int damage)
    {
        if(KEYBORED.isPlaying == false){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);}
    }
}*/
