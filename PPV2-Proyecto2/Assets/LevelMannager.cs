using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelMannager : MonoBehaviour
{
    public static LevelMannager Instance;
    [Header("Level Data")]
    public Subject Lesson;

    [Header("User Interface")]
    public TMP_Text QuestionTxt;
    public TMP_Text QuestionTxt1;
    public List<Option> Options;
    public GameObject CheckButton;
    public GameObject AnswerContainer;
    public Color Green;
    public Color Red;

    [Header("Game Configuration")]
    public int questionAmount = 0;
    public int currentQuestion = 0;
    public string question;
    public string correctAnswer;
    public int answerFromPlayer = 9;
    

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
        CheckPlayerState();

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
        if (CheckPlayerState())
        {
            if (currentQuestion < questionAmount)
            {
                //Revisamos si la respuesta es correcta o no
                bool isCorrect = currentLesson.options[answerFromPlayer] == correctAnswer;

                AnswerContainer.SetActive(true);

                if (isCorrect)
                {
                    AnswerContainer.GetComponent<Image>().color = Green;
                    Debug.Log("Respuesta correcta." + question + ": " + correctAnswer);
                }
                else
                {
                    AnswerContainer.GetComponent<Image>().color = Red;
                    Debug.Log("Respuesta Incorrecta." + question + ": " + correctAnswer);
                }

                // Incrementamos el índice de la pregunta actual
                currentQuestion++;

                // Cargar la nueva pregunta
                StartCoroutine(ShowResultAndLoadQuestion(isCorrect));

                // Reset answer from player
                answerFromPlayer = 9;
            }
            else
            {
                // Cambio de escena
            }
        }

    }

    private IEnumerator ShowResultAndLoadQuestion(bool isCorrect)
    {
        yield return new WaitForSeconds(2.5f); //Ajusta el tiempo que deseas mostrar el resultado

        //Ocultar el contenedor de respuestas
        AnswerContainer.SetActive(false);

        //Cargar la nueva pregunta
        LoadQuestion();

        //Activa el botón después de mostrar el resultado
        //Puedes hacer esto aquí o en LoadQuestion(), dependiendo de tu estructura
        //por ejemplo, si el botón está en el mismo gameObject que el script:
        //getComponent<Button>().intercatable = true;
        CheckPlayerState();
    }

    public void SetPlayerAnswer(int _answer)
    {
        answerFromPlayer = _answer;
    }

    public bool CheckPlayerState()
    {
        if (answerFromPlayer != 9)
        {
            CheckButton.GetComponent<Button>().interactable = true;
            CheckButton.GetComponent<Image>().color = Color.white;
            return true;
        }
        else
        {
            CheckButton.GetComponent<Button>().interactable = false;
            CheckButton.GetComponent<Image>().color = Color.grey;
            return false;
        }
    }
}
