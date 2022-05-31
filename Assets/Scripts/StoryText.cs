using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryText : MonoBehaviour
{
    [SerializeField]States startingState;
    [SerializeField] Text myStoryText;
    States states;
    // Start is called before the first frame update
    void Start()
    {
        states = startingState;
        myStoryText.text = states.GetStateStory();
    }

    public void ManageStates()
    {
        var nextState = states.GetNextState();
        for(int stateIndex = 0; stateIndex < nextState.Length; stateIndex++)
        {
            if (Input.GetMouseButtonDown(0))
            {
                states = nextState[stateIndex];
                stateIndex++;
            }
            if(stateIndex == nextState.Length)
            {
                SceneManager.LoadScene(3);
            }
        }
        myStoryText.text = states.GetStateStory();
       
    }
    // Update is called once per frame
    void Update()
    {
        ManageStates();
    }
}
