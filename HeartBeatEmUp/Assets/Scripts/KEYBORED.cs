/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KEYBORED : MonoBehaviour
{
    public int CurrentHealth;
    private int Cooldown = 3;
    private float TimeTill = 0.1f;
    public HealthBar healthBar;
    public float Delay;
    public  KeyCode Corresponding_Key;
    public static bool isPlaying;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = GameObject.Find("HeartOHearts").GetComponent<FDown>().currentHealth;
          if(Input.GetKey(Corresponding_Key)&&Cooldown > 0){
            if(isPlaying == false)
            {
            Cooldown = Cooldown - 1;
            StartCoroutine(Keyboned());
            healthIncrease(10);
            if(Cooldown < 3){StartCoroutine(Cooldowner());}
            }
        }
    }
 
      public IEnumerator Keyboned()
        {
            isPlaying = true;
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(Delay);//prevents spamming
            isPlaying = false;
        }

    public void healthIncrease(int heal)
    {
        CurrentHealth += heal;
    }
        IEnumerator Cooldowner()
        {
            TimeTill = TimeTill + 1;
            while(Cooldown <3){Cooldown ++;}
            yield return new WaitForSeconds(TimeTill);
        }
}
*/
