using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance;

    //public Leccion data;
    public SubjectContainer subject;

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
        //SaveToJSON("LeccionDummy", data);

       //subject = LoadFromJSON<SubjectContainer>("SubjectDummy");
    }

    //public void SaveToJSON(string_fileName, object_data)
    //{
        //if (_data != null)
        //{
            //string JSONData = JsonUtility.ToJson(_data, true);

            //if(JSONData.Length != 0)
            //{
                //Debug.Log("JSON STRING: " + JSONData);

                //string fileName = _fileName + ".json";

                //string filePath = filePath.Combine(Application.dataPath + "/Resource/JSONS", fileName);

                //filePath.WriteAllText(filePath, JSONData);

                //Debug.Log("JSON almacenamiento en la direccion: " + filePath);

           // }
            //else
            //{7
               // Debug.LogWarning("ERROR- fileSystem: _data is null, check for param [object_data");
            //}
       // }
       // else
       // {

        }
    //}

   // // Update is called once per frame
   // void Update()
    //{
        
   // }
//}
