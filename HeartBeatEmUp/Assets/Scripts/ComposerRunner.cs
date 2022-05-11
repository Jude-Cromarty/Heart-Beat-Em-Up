using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComposerRunner : MonoBehaviour
{
    int Composed = Composer.Composed;
int[] CompNums;
    void Start()
    {
 /*            string text =  CompFile.text;  //this is the content as string
        byte[] byteText =  CompFile.bytes;  //this is the content as byte array
        List<ComposedPiece> comped = new List<ComposedPiece>();
          comped.Add(new ComposedPiece(text));{}*/

          CompNums = new int[] {1,2,3,4,5,6,7,8};
          for (int i = 0; i < CompNums.Length; i++)
        {Composed = CompNums[i];}
    }

    // Update is called once per frame
    void Update()
    {
    }
}

