using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public GameObject QuizPanel;
    public GameObject GoPanel;
    public GameObject Proceed;
    public int currentQuestion;
    public GameObject popup;
    public Animator animator;
    public Text QuestionTxt;
    public Text ScoreTxt;

    int totalQuestions = 0;
    int passingScore =  3;

    public int score;

    private void Start() {

        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        Proceed.SetActive(false);
        generateQuestion();
    
    
    }
     public void retry() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void ProceedNextlevel()
    {
        popup.SetActive(false);
        animator.SetTrigger("DoneAssesment");
       

    }
    void GameOver() {

        GoPanel.SetActive(true);
        QuizPanel.SetActive(false);
        ScoreTxt.text = score + " / " + totalQuestions;
        if (score >= passingScore)
        {
            Proceed.SetActive(true);

        }
        else {

            Proceed.SetActive(false);

        }


    }
    public void correct() {

        score += 1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    
    
    
    }
    public void wrong() {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }
    void SetAnswer() {

        for (int i = 0; i < options.Length; i ++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }

        }


       
    }
    void generateQuestion() {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswer();
        }
        else {

            Debug.Log("Out of quesitons");
            GameOver();
        }
      
    }

}
