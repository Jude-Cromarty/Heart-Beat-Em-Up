using UnityEngine;
using System.Collections;
public class spwan : MonoBehaviour
{

    public GameObject Prefab_0;
    public GameObject Prefab_1;
    public GameObject Prefab_2;
    public GameObject Prefab_3;
    public GameObject Prefab_4;
    public GameObject Prefab_5;
    public GameObject Prefab_6;
    public GameObject Prefab_7;


    public int amount;
    public bool randomized = false;
    public bool Respawn;
    public float Min_Random_Distance, Max_Random_Distance, Seconds_To_Wait;
    public float x, y, z;
    public int Thenum;

   
    void Start()
    {

        StartCoroutine(Magic());
    }

    public void randomnum()
    {
        Thenum = Random.Range(1, 8);

    }
    IEnumerator Magic()
    {
       
        int i = 0;
        while (i < amount)
        {
            randomnum();
            if (randomized == true) { x = Random.Range(Min_Random_Distance, Max_Random_Distance); }       
            if (randomized == true) { z = Random.Range(Min_Random_Distance, Max_Random_Distance); }
            switch (Thenum)
            {
                case 0:
                    Instantiate(Prefab_0, new Vector3(x, 7, z), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(Prefab_1, new Vector3(x, 7, z), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(Prefab_2, new Vector3(x, 7, z), Quaternion.identity);
                    break;
                case 3:
                    Instantiate(Prefab_3, new Vector3(x, 7, z), Quaternion.identity);
                    break;
                case 4:
                    Instantiate(Prefab_4, new Vector3(x, 7, z), Quaternion.identity);
                    break;
                case 5:
                    Instantiate(Prefab_5, new Vector3(x, 7, z), Quaternion.identity);
                    break;
                case 6:
                    Instantiate(Prefab_6, new Vector3(x, 7, z), Quaternion.identity);
                    break;
                case 7:
                    Instantiate(Prefab_7, new Vector3(x, 7, z), Quaternion.identity);
                    break;
            }        
            i++;
            if (Respawn == true) { i--; }
            yield return new WaitForSeconds(Seconds_To_Wait);
        }

    }
}