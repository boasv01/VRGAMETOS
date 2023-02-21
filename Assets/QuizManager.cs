using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    // deze class heeft alle methodes
   public List<QuestionAndAnswer> QnA;
   public GameObject[] options;
   public int currentQuestion;

   public GameObject QuizPanel;
   public GameObject GoPanel;

   public Text QuestionTxt;
   public Text ScoreTxt;

   int  totalQuestions = 0;
   public int Score;

   private void Start()
{
    totalQuestions = QnA.Count;
    GoPanel.SetActive(false);
    generateQuestion();

}
//hier kan de game herhalen
public void retry()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


}
//de resultaten van de game 
void GameOver()
{
    QuizPanel.SetActive(false);
    GoPanel.SetActive(true);
    ScoreTxt.text = "Score: " + Score + "/" + totalQuestions;
}

public void Correct()
{ //when its right
    Score++;
    QnA.RemoveAt(currentQuestion);
    generateQuestion();
}

public void Wrong()
{   //when its worng
    QnA.RemoveAt(currentQuestion);

    generateQuestion();
}

//het antwoord kiezen van de opties
void SetAnswers()
{
    for (int i = 0; i < options.Length; i++)
    {
        options[i].GetComponent<AnswerScript>().isCorrect = false;
        options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

        if (QnA[currentQuestion].CorrectAnswer == i + 1)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = true;
        }
    }

}

//laat de vragen door met random manier' 
void generateQuestion(){

        if(QnA.Count > 0){ 
            currentQuestion = Random.Range(0, QnA.Count);

             QuestionTxt.text = QnA[currentQuestion].Question;
             SetAnswers();
         }
        else
        {//als er geen meer vragen
            Debug.Log("No more questions");
            GameOver();
        
        }
}
}


