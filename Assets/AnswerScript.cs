using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
// dit komt als het antwoord goed is
   public void Answer()
   {
         if (isCorrect)
         {
              Debug.Log("Correct Answer");
              quizManager.Correct();
         }
         else
         { // dit komt als het antwoord fout is
              Debug.Log("Wrong Answer");
                quizManager.Wrong();
         }

   }
}
