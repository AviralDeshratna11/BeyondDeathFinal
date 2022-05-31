using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader2 : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        

    }
    private void SceneChanger()
    {
       
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }

    }
    // Update is called once per frame
    void Update()
    {
        SceneChanger();
    }
}
