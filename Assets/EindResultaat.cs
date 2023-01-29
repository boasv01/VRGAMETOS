using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EindResultaat : MonoBehaviour
{

    public static int[] ResultatenLijst = {9,9,9,9,9,9,9,9,9};
    public int[] ResultatenProcessed = {9,9,9,9,9,9,9,9,9};
    public string[] VragenLijst = {"1. Waarom is logopedische behandeling noodzakelijk bij een leerling met TOS?", "2. Hoe lang hebben kinderen extra bedenktijd nodig voordat je je vraag kan herhalen?", "3. Wat kan je doen bij een leerkracht op het gebied van emoties?", "4. Wat kan de leerkracht tijdens zijn/haar instructie doen?", "5. Wat kan de leerkracht doen om een kind met TOS in de klas te helpen?", "6. Hoe vaak komt een TOS voor?", "7. Waarom is het vroeg opsporen van TOS belangrijk?", "8. Waar staan de letters TOS voor?", "9. Enkele belangrijke signalen van TOS zijn"};
    public Text QuestionText;
    public Text AntwoordText;
    public int ResultView = 0;
    public Text ResultviewDisplay;

    public void Start(){
        ConvertResultaten();
    }

    public void Update(){
        ResultViewDisplayScript();
        ViewResultaat();
    }

    public void ConvertResultaten(){
        for( int i = 0; i < ResultatenLijst.Length; i++){
            ResultatenProcessed[i] = ResultatenLijst[i];
        }
    }

    public void ResultViewDisplayScript(){
        ResultviewDisplay.text = ResultView.ToString();
    }

    public void ViewResultaat(){
        int Viewinput = ResultatenProcessed[ResultView];
        QuestionText.text = VragenLijst[ResultView];
        if(Viewinput == 1){
            AntwoordText.text = "Goed!";
        }
        else{
            AntwoordText.text = "Fout";
        }
        // AntwoordText.text = Viewinput.ToString();
    }

    public void VolgendeVraag(){
        if(ResultView <= 8){
            ResultView++;
        }
        else{
            Debug.Log("Kan niet meer naar boven");
        }
        ViewResultaat();
    }

    public void VorigeVraag(){
        if(ResultView >= 0){
            ResultView--;
        }
        else{
            Debug.Log("Kan niet meer naar beneden");
        }
        ViewResultaat();
    }
}
