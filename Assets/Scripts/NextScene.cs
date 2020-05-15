using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NextScene : MonoBehaviour
{

    private void Update() {
        if(Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene("stage1");
        }
    }
    
}
