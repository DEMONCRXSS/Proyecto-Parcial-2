using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMannager : MonoBehaviour
{
    [Header("Level Data")]
    public Subject Lesson;

    [Header("Game Configuration")]
    public int questionAmount = 0;
    public int currentQuestion = 0;
    public string question;
    public string correctAnswer;
    [Header("Current Lesson")]
    public Lección currentLesson;

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
            // QuestionTxt.Text = question;
           
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

}
