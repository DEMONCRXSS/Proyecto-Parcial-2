using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelMannager : MonoBehaviour
{
    public static LevelMannager Instance;
    [Header("Level Data")]
    public SubjectContainer subject;

    //GameObjects para UI
    [Header("User Interface")]
    public TMP_Text QuestionTxt;
    public TMP_Text QuestionTxt1;
    public List<Option> Options;
    public GameObject CheckButton;
    public GameObject AnswerContainer;
    public Color Green;
    public Color Red;

    //Esto recibirá el script del scriptableObject
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
        subject = SaveSystem.Instance.subject;
        //Establecemos la cantidad de preguntas en la leccion
        questionAmount = subject.LeccionList.Count;
        //Cargar la primera pregunta
        LoadQuestion();
    }

    private void LoadQuestion()
    {
        // Aseguramos que la pregunta actual este dentro de los limites
        if (currentQuestion < questionAmount)
        {
            // Establecemos la leccion actual
            currentLesson = subject.LeccionList[currentQuestion];
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

    //Pasar siguiente pregunta
    public void NextQuestion()
    {
        //Revisa la respuesta que selecciona el jugador
        if (CheckPlayerState())
        {
            if (currentQuestion < questionAmount)
            {
                //Revisamos si la respuesta es correcta o no
                bool isCorrect = currentLesson.options[answerFromPlayer] == correctAnswer;

                //Activa el Answercontainer
                AnswerContainer.SetActive(true);

                //Revisa si la respuesta es correcta
                if (isCorrect)
                {
                    //El contenedor cambia a color verde si la respuesta es correcta
                    AnswerContainer.GetComponent<Image>().color = Green;
                    Debug.Log("Respuesta correcta." + question + ": " + correctAnswer);
                }
                else //Si no es correcto
                {
                    //El contenedor cambia a color rojo si la respuesta es incorrecta
                    AnswerContainer.GetComponent<Image>().color = Red;
                    Debug.Log("Respuesta Incorrecta." + question + ": " + correctAnswer);
                }

                // Incrementamos el índice de la pregunta actual
                currentQuestion++;

                //ShowResultAndLoadQuestion comienza una corrutina (las corrutinas comunmente son utilizadas en escenarios scenarios donde se necesitan procesos de larga duración, como la carga de recursos)
                //que suspende por 2 segundos el contenedor de respuesta y cambiará de pregunta
                StartCoroutine(ShowResultAndLoadQuestion(isCorrect));

                //Reinicia la respuesta del jugador para la nueva pregunta
                answerFromPlayer = 9;
            }
            else
            {
                // Cambio de escena
            }
        }

    }

    //Inicia una corrutina que suspende el código dependiendo de lo que se especifique dentro de esta
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

    //Asignará la respuesta del jugador
    public void SetPlayerAnswer(int _answer)
    {
        //Actualiza la respuesta del jugador
        answerFromPlayer = _answer;
    }

    //Nos aseguramos si el jugador presionó un botón para cambiar su color y activarlo
    public bool CheckPlayerState()
    {
        //nos aseguramos si los botones cambian de color al ser presionados
        if (answerFromPlayer != 9)
        {
            //Actualizamos el componente boton para que sea interactuable
            CheckButton.GetComponent<Button>().interactable = true;
            //Actualizamos el componente Imagen para que cambie su color
            CheckButton.GetComponent<Image>().color = Color.white;
            return true;
        }
        else //Si no se interactua con el boton
        {
            //Actualizamos el componente boton para que no se pueda presionar
            CheckButton.GetComponent<Button>().interactable = false;
            //Actualizamos el componente Imagen para que cambie su color
            CheckButton.GetComponent<Image>().color = Color.grey;
            return false;
        }
    }
}
