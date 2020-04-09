using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuizScript : MonoBehaviour
{
    public GameObject QuizAnswer;
    public GameObject ScoreText;
    public GameObject RecordScore;
    public int score = 0;
    public int recScore;
    public GameObject FirstScreen;
    public GameObject ThirdScreen;
    public GameObject ShowUser;
    public GameObject MainPage;

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
            
            FirstScreen.SetActive(false);
            ThirdScreen.SetActive(true);
            // ShowUser.SetActive(false);
            // MainPage.SetActive(true);
            ShowMessageQuiz();
            ScoreText.GetComponent<Text>().text = score.ToString("F0");
            recScore += score;
            RecordScore.GetComponent<Text>().text = recScore.ToString("F0");
            
        }
    }
    public void ResetScore()
    {  
        score = 0;
    }
    public void ShowMessageQuiz()
    {
           string quizansFail = "Вы не прошли тест,хотите попробовать еще?";
           string quizansCorrect = "Молодец можешь перейти на следующий уровень или перепройти тест еще раз!";
            if(score < 3)
            {
                QuizAnswer.GetComponent<Text>().text = quizansFail.ToString();
            }
            if(score > 2)
            {
                QuizAnswer.GetComponent<Text>().text = quizansCorrect.ToString();
            }
    }
    public void AnswerBtn(int index)
    {
        
        if(answersText[index].text.ToString() == crntQ.answers[0])
        {
            score++;
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
