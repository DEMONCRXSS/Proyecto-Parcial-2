using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Option : MonoBehaviour
{
    public int OptionID;
    public string OptionName;

    // Start is called before the first frame update
    void Start()
    {
        //Obtenemos el componente texto para actualizarlo al texto de la pregunta de nuestro scriptableObejct
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }

    //Actualizar texto
    public void UpdateText()
    {
        //Obtenemos el child para actualizarlo a la lista del scriptableObject
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }

    //Nos aseguramos de que una opción haya sido seleccionada y llamamos 2 funciones
    //Del script: Levelmanager
    public void SelectOption()
    {
        //Asignamos la respuesta correcta en función del ID del cript: Leccion
        LevelMannager.Instance.SetPlayerAnswer(OptionID);
        //Con Levelmanager comprobamos si una respuesta fue selecionada y si los botones son interactuables
        LevelMannager.Instance.CheckPlayerState();
    }
}
