using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance;

    public Lección data;
    public SubjectContainer subject;

    //Singleton es un patrón de diseño que se asegura que una clase tenga una sola instancia y da un punto de acceso global a esa instancia
    private void Awake()
    {
        //Creamos la instancia
        if (Instance != null)
        {
            return;
        }
        else
        {
            Instance = this;
        }
        subject = LoadFromJSON<SubjectContainer>(PlayerPrefs.GetString("selectedLesson"));
    }

    // Start is called before the first frame update
    void Start()
    {
        SaveToJSON("LeccionDummy", data);
        //SaveToJSON("LeccionDummy", subject);

        CreateFile("Pepe", ".data");

        //subject = LoadFromJSON<SubjectContainer>("SubjectDummy");
    }

    public void CreateFile(string fileName, string extension)
    {

    }

    public void SaveToJSON(string _fileName, object _data)
    {
        if (_data != null)
        {
            //_data va a transformarse en un archivo JSON
            string JSONData = JsonUtility.ToJson(_data, true);

            if (JSONData.Length != 0)
            {
                Debug.Log("JSON STRING: " + JSONData);

                //Creamos el archivo que se va a almacenar
                string fileName = _fileName + ".json";
                //Direccion donde se va a almacenar el archivo
                string filePath = Path.Combine(Application.dataPath + "/Resources/JSONS", fileName);
                //Escribir el recurso en memoria
                File.WriteAllText(filePath, JSONData);
                //Para indicar en donde se guardó el archivo
                Debug.Log("JSON almacenado en la direccion: " + filePath);
            }
            else
            {
                Debug.LogWarning("ERROR- FileSystem: _data is null, check for param [object _data]");
            }
        }
        else
        {

        }
    }

    //Esta funcion carga datos desde un archivo JSON y los deserializa en un objecto del tipo especificado por el usuario
    //Usamos una definición generica definida como "T" para que se pueda trabajar con cualquier tipo de dato que se quiera llamar
    public T LoadFromJSON<T>(string _fileName) where T : new()
    {
        //Creacion de intancia del tipo "T"
        T Dato = new T();
        //Obtenemos la ruta de archivo de los JSON
        string path = Application.dataPath + "/Resources/JSONS" + _fileName + ".json";
        string JSONData = "";
        //Comprobamos si el archivo JSON está en la ruta especificada
        if (File.Exists(path))
        {
            JSONData = File.ReadAllText(path);
            Debug.Log("JSON STRING: " + JSONData);
        }
        if (JSONData.Length != 0)
        {
            //Esto es para deserializar el JSON en el objecto "dato"
            //FromJsonOverWrite se encarga de sobreescribir los valores de "Dato" con los valores
            //del JSON
            JsonUtility.FromJsonOverwrite(JSONData, Dato);
        }
        else
        {
            //Si el archivo JSON no se encuentra o esta vacio mandará una advertencia a consola
            Debug.LogWarning("ERROR - fileSystem: JSONData is emty, check for local variable [string JSONData]");
        }
        //Devuelve el objeto deserializado, si el archivo JSON no se pudo cargar se devolverá un objecto vacío
        return Dato;
    }
}