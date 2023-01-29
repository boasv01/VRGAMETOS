using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class QuizManager : MonoBehaviour
{
  public List<QuestionsAndAnswers> QnA;
  public GameObject[] options;

  public int currentQuestion = 0;
  public static int vraagNu = 0; //teller werkt wel maar begint opnieuw als je naar volgende scene gaat, als dit gefixt wordt is de eind ui bijna klaar
  int totalQuestions = 0;

  public Text QuestionTxt;
  public Text Puntentellingtemp;

  public AudioSource Speaker;
  public AudioClip[] Clipvraag;

  public GameObject QuizPanel;
  public GameObject EndPanel;

  public int Result;

  private void Start()
  {
    totalQuestions = QnA.Count;
    QuizPanel.SetActive(true);
    EndPanel.SetActive(false);
    generateQuestion();
    loadPoints();
  } 

  public void Update(){
    DecryptVT(); // Just to show what PublicVar.vragenTeller contains (no actual use)
  }

  public void lastQuest()
  {
    QuizPanel.SetActive(false);
    EndPanel.SetActive(true);
  }

  public void correct()
  {
    QnA.RemoveAt(currentQuestion);
    PlayAudio(currentQuestion);
    generateQuestion();
  }

  void SetAnswers()
  {
    for (int i = 0; i < options.Length; i++)
    {
      options[i].GetComponent<AnswerScript>().isCorrect = false;
      options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

      if(QnA[currentQuestion].correctAnswer == i+1)
      {
        options[i].GetComponent<AnswerScript>().isCorrect = true;
      }
    }
  }

  void generateQuestion() //naar volgende vraag
  {
    if(QnA.Count > 0)
    {
      for(int i = 0; i < QnA.Count; i++)
      {
        currentQuestion = i;

        QuestionTxt.text = QnA[currentQuestion].Question;
        SetAnswers();
      }
    }
    else{
      Debug.Log("out of questions");
      lastQuest();
    }
  }  

  public void addPoints()
  {
    PublicVar.score += 1;
    Puntentellingtemp.text = "Vraagnummer: " + currentQuestion.ToString();
    EindResultaat.ResultatenLijst[PublicVar.vragenTeller] = 1;
    Debug.Log("goedzo! je score is:" + PublicVar.score);
    PublicVar.vragenTeller++;
  }

  public void noPoints()
  {
    Puntentellingtemp.text = "Vraagnummer: " + currentQuestion.ToString();
    EindResultaat.ResultatenLijst[PublicVar.vragenTeller] = 0;
    Debug.Log("fout antwoord");
    PublicVar.vragenTeller++;
  }

  public void loadPoints()
  {
    Puntentellingtemp.text = "Vraagnummer: " + currentQuestion.ToString();
  }

  public void DecryptVT(){
    Result = PublicVar.vragenTeller;
  }

  // async static void waiter(){ //Delay werkt nog niet
  //   await Task.Delay(2000);
  // }

  public void PlayAudio(int vraagNummer){
    if(vraagNummer < 3){
    Speaker.clip = Clipvraag[vraagNummer];
    Speaker.PlayOneShot(Speaker.clip); //speelt audio na een vraag
    }
    else{
      Debug.Log("hier is nog geen audiofile voor");
    }
  }
}
