using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationComplex : MonoBehaviour
{
    public GameObject Stage, Player1, Player2;
    public KeyCode RotateStart, RotateStop;
    public Vector3 position, rotationVector;
    public float degreesPerSecond;
    bool Turning = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(RotateStart))
        {
            Turning = true;
        }
        if(Input.GetKey(RotateStop))
        {
            Turning = false;
        }
        if(Turning == true)
        {
            Stage.transform.RotateAround(position, rotationVector, degreesPerSecond * Time.deltaTime);
        }

    }
}
