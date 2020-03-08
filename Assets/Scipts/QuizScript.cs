using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuizScript : MonoBehaviour
{
    [SerializeField] private Color correctCol,wrongCol;
    public QuestionList[] questions;
    public Text[] answersText;
    public Text Text;
    public GameObject headPanel;
    bool defaultColor, trueColor, falseColor;

    List<object> qList;
    QuestionList crntQ;
    int randQ;

    void Update()
    {
       
    }

    public void OnClickPlay()
    {
        qList = new List<object>(questions);
        questionGenerate();
    }
    void questionGenerate()
    {
        if (qList.Count > 0)
        {
            randQ = Random.Range(0,qList.Count);
            crntQ = qList[randQ] as QuestionList;
            Text.text = crntQ.question;
            List<string> answers = new List<string>(crntQ.answers);
            for(int i = 0;i < crntQ.answers.Length; i++)
            {
                int rand = Random.Range(0, answers.Count);
                answersText[i].text = answers[rand];
                answers.RemoveAt(rand);
            }
        }
        else
        {

        }

    }
    public void AnswerBtn(int index)
    {
        
        if(answersText[index].text.ToString() == crntQ.answers[0])
        {
        
        print("Правильный ответ");

        }
        else
        {
           print("Неправильный ответ");
        }
        qList.RemoveAt(randQ);
        questionGenerate();
    }
    
}

[System.Serializable]
public class QuestionList
{
    public string question;
    public string[] answers = new string[3];
}
