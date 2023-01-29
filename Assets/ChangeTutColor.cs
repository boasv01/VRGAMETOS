using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTutColor : MonoBehaviour
{
    public Text knoptext;
    public Color[] colors = {Color.red, Color.green, Color.blue}; 
    public Text headertext;
    private int counter;

    public void Update(){
        ChangeHeaderText();
    }

    public void ChangeTextColor(){
            knoptext.color = colors[Random.Range(0, 3)];
            counter++;
    }

    public void ChangeHeaderText(){
        if(counter == 3){
            headertext.text = "Goedzo! Gebruik nu je controller om je om te draaien en naar de deur te lopen";
        }
    }
}
