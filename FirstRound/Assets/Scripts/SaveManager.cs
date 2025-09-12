using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SaveManager : MonoBehaviour
{
    [Header("PRIVATE VARIABLES")]
    private string saveFilePath;
    private string saveFileName = "highScoreData.json";
    // Start is called before the first frame update

    private void Awake()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, saveFileName);
    }

    // save high score to json file
    public void SaveGame(DataController dataController)
    {
        string json = JsonUtility.ToJson(dataController);
        File.WriteAllText(saveFilePath, json);
    }

    // load the save json file and convert it to dataController
    public DataController LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);

            DataController loadData = JsonUtility.FromJson<DataController>(json);
            return loadData;
        }
        else
            return null;
    }
}
