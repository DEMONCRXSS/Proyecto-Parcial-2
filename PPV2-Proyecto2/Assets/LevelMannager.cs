using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelMannager : MonoBehaviour
{
    public static LevelMannager Instance;
    [Header("Level Data")]
    public Subject Lesson;

    [Header("User Interface")]
    public TMP_Text QuestionTxt;
    public List<Option> Options;

    [Header("Game Configuration")]
    public int questionAmount = 0;
    public int currentQuestion = 0;
    public string question;
    public string correctAnswer;
    public int answerfromPlayer;

    [Header("Current Lesson")]
    public Lección currentLesson;

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        else
        {
            Instance = this; 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Establecemos la cantidad de preguntas en la leccion
        questionAmount = Lesson.leccionList.Count;
        // Cargar la primera pregunta
        LoadQuestion();

    }

    private void LoadQuestion()
    {
        // Aseguramos que la pregunta actual este dentro de los limites
        if (currentQuestion < questionAmount)
        {
            // Establecemos la leccion actual
            currentLesson = Lesson.leccionList[currentQuestion];
            // Establecemos la pregunta
            question = currentLesson.lessons;
            // Establecemos la respuesta correcta
            correctAnswer = currentLesson.options[currentLesson.correctAnswer];
            // Establecemos la pregunta en UI
            QuestionTxt.text = question;
            // Establecemos las Opciones
            for (int i = 0; i < currentLesson.options.Count; i++)
            {
                Options[i].GetComponent<Option>().OptionName = currentLesson.options[i];
                Options[i].GetComponent<Option>().OptionID = i;
                Options[i].GetComponent<Option>().UpdateText();
            }
          
        }
        else
        {
            // si llegamos al final de las preguntas
            Debug.Log("Fin de las preguntas");
        }
    }

    public void NextQuestion()
    {
        if (currentQuestion < questionAmount)
        {
            // Incrementamos el índice de la pregunta actual
            currentQuestion++;
            // Cargar la nueva pregunta
            LoadQuestion();
        }
        else
        {
            // Cambio de escena
        }
    }

    public void SetPlayerAnswer(int _answer)
    {
        answerfromPlayer = _answer;
    }
}
