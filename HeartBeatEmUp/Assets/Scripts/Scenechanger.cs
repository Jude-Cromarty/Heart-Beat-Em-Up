
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class Scenechanger : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}