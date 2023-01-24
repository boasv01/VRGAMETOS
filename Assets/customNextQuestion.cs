using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class customNextQuestion : MonoBehaviour
{
    public Text question;
    public Text answer1;
    public Text answer2;
    public Text answer3;
    public Text answer4;
    public Button btn1 = null;
    public Button btn2;
    public Button btn3;
    public Button btn4;
    string[] questionList1 = {"quest1", "quest2", "quest3", "quest4"};
    string[] answerList1 = {"answer1", "answer2", "answer3", "answer4"};
    string[] answerList2 = {"answer1", "answer2", "answer3", "answer4"};
    string[] answerList3 = {"answer1", "answer2", "answer3", "answer4"};
    string[] answerList4 = {"answer1", "answer2", "answer3", "answer4"};
    int[] userInputAntw = {0,0,0,0};
    // Start is called before the first frame update
    void Start()
    {
        questionSystem();
    }

    public void questionSystem() {
        
        for (int i = 0; i < 4; i++)
        {
            question.text = (questionList1[i]);
            answer1.text = (answerList1[i]);
            answer2.text = (answerList2[i]);
            answer3.text = (answerList3[i]);
            answer4.text = (answerList4[i]);
			Thread.Sleep(5000);
            Debug.Log("Your Text" +i);
            btn1.onClick.AddListener(delegate{testClick("Click getest voor input");});
        }
    }

    public void testClick(string test)
    {
        Debug.Log(test);
}
}