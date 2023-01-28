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
  public static int vraagNu = 0;
  public Text QuestionTxt;
  public Text Puntentellingtemp;

  private void Start()
  {
    generateQuestion();
    loadPoints();
  } 

  public void correct()
  {
    QnA.RemoveAt(currentQuestion);
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
        vraagNu = currentQuestion;
        // SoundManager.getPlayAudio(); lukt niet om audio uit SoundManager te referencen (Audio speelt wel aan het begin)
      }

    QuestionTxt.text = QnA[currentQuestion].Question;
    SetAnswers();
    }
    else{
      Debug.Log("out of questions");
    }
  }  

  public void addPoints()
  {
    PublicVar.score += 1;
    Puntentellingtemp.text = "Je score is: " + PublicVar.score.ToString() + " van de " + currentQuestion;
    Debug.Log("goedzo! je score is:" + PublicVar.score);
    waiter();
  }

  public void noPoints()
  {
    Puntentellingtemp.text = "Je score is: " + PublicVar.score.ToString() + " van de " + currentQuestion;
    Debug.Log("fout antwoord");
    waiter();
  }

  public void loadPoints()
  {
    Puntentellingtemp.text = "Je score is: " + PublicVar.score.ToString() + " van de " + currentQuestion;
  }

  async static void waiter(){ //Delay werkt nog niet
    await Task.Delay(2000);
  }
}
