using UnityEngine;
using System.IO;
using System;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class SaveContentTrigger
{
    public string name;
    public bool isComplete;
}

[Serializable]
public class GameSaveData
{
    public string mapName = "";
    public Vector3 characterTransform;
    public Quaternion characterRotation;
    public List<SaveContentTrigger> contentTriggersOnMapWasExecuted;
    public string currentQuestText = "";
    public DateTime saveCreateDateTime = DateTime.Now;
}





public class SaveLoadGame
{
    static public string saveFilePath()
    {
        return Application.persistentDataPath + "/" + "save.dat";
    }

    static public void SaveGame()
    {
        // get data
        var contentTriggersOnMapWasExecuted = new List<SaveContentTrigger>();
        foreach (var ct in Resources.FindObjectsOfTypeAll<ContentTrigger>())
        {
            contentTriggersOnMapWasExecuted.Add(new SaveContentTrigger
            {
                name = ct.gameObject.name,
                isComplete = ct.isComplete,
            });
        }


        // create object
        var s = new GameSaveData
        {
            mapName = SceneManager.GetActiveScene().name,
            characterTransform = GameObject.Find("Character").transform.position,
            characterRotation = GameObject.Find("Character").transform.rotation,
            contentTriggersOnMapWasExecuted = contentTriggersOnMapWasExecuted,
            currentQuestText = GameObject.FindObjectOfType<QuestManager>().currentQuest,
        };

        // save data
        string jsondata = JsonUtility.ToJson(s, true);
        File.WriteAllText(saveFilePath(), jsondata);
        Debug.Log("Game saved to " + saveFilePath());
    }

    static public void LoadGame()
    {
        // Tak naprawde tylko ³aduje mapê na której by³ zapisany stan gry, wszystkie inne opcje ustawia LoadGameOnMapEnter
        // Dlaczego tak: bo Character mogê ustawiæ dopiero jak bêdzie na mapie a w menu Character nie istnieje
        GameSaveData s;
        if (File.Exists(saveFilePath()))
        {
            string jsondata = File.ReadAllText(saveFilePath());
            s = JsonUtility.FromJson<GameSaveData>(jsondata);
        }
        else
        {
            throw new Exception("File with save dont exist (" + saveFilePath() + ")");
        }
        // start loading target map
        var loadGameObj = GameObject.FindObjectOfType<LoadGame>();
        loadGameObj.SetGameSaveData(s);
        SceneManager.LoadScene(s.mapName);
    }

    static public void LoadGameOnMapEnter(GameSaveData gsd)
    {
        // set all things after map is loaded
        var characterObj = GameObject.Find("Character");
        characterObj.transform.position = gsd.characterTransform;
        characterObj.transform.rotation = gsd.characterRotation;

        var questManagerObj = GameObject.FindObjectOfType<QuestManager>();
        questManagerObj.UpdateCurrentQuestText(gsd.currentQuestText);


        foreach (var ct in Resources.FindObjectsOfTypeAll<ContentTrigger>())
        {
            var saveContentTrigger = gsd.contentTriggersOnMapWasExecuted.Find(sct => sct.name == ct.name);
            ct.isComplete = saveContentTrigger.isComplete;
            ct.gameObject.SetActive(!ct.isComplete);
        }
    }

}
