using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "STATES")]
public class States : ScriptableObject

{
    [TextArea(14, 10)] [SerializeField] string storyText;
    [SerializeField] States[] nextStates;
     
    
   public States[] GetNextState()
    {
        return nextStates;
    }
    public string GetStateStory()
    {
        return storyText;
    }
        

    // Update is called once per frame
   
}
