using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour
{

    public void LoadNewScene(string scene)
    {
        Application.LoadLevel(scene);
        
    }

    public void Quit()
    {
        Application.Quit();
    }



}
