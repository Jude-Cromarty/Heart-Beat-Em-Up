using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamageTextP1 : MonoBehaviour
{
   GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player1");
    }

    // Update is called once per frame
    void Update()
    {
      GetComponent<TextMesh>().text = player.GetComponent<Player1>().Damage.ToString();  
    }
    
}