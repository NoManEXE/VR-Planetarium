using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuizScript : MonoBehaviour
{
    const string privateCode = "Kx6_Qtm7XUuep2FM-8kBEQDju24yuNeUmQiIGLBNEQvA";
    const string publicCode = "5eba34430cf2aa0c281a9d62";
    const string webURL = "http://dreamlo.com/lb/";


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


    public void AddNewHighscore(string username, int score)
    {
        StartCoroutine(UploadNewHighScore(username, score));
    }

    IEnumerator UploadNewHighScore(string username, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
            print("Upload completed");
        else
        {
            print("Error uploading " + www.error);
        }
    }

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
                AddNewHighscore("Vlad", score);
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
