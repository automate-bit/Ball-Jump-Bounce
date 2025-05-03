using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoadin : MonoBehaviour
{
    private void Start() {
        SceneManager.LoadSceneAsync("level1");
    }

    
}
