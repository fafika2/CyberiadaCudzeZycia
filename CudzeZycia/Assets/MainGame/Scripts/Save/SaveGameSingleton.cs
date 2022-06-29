using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

[Serializable]
public class SaveContentTrigger
{
    public string id;
    public bool isComplete;
}

[Serializable]
public class GameSaveData
{
    public string mapName = "";
    public Vector3 characterTransform;
    public Quaternion characterRotation;
    public List<SaveContentTrigger> contentTriggerList;
    public string currentQuestText = "";
    public DateTime saveCreateDateTime = DateTime.Now;
}



public class SaveGameSingleton : MonoBehaviour
{
    GameSaveData gameState;
    string saveGamePath = "";

    private bool isSaveLoading = false;

    void Awake()
    {
        saveGamePath = Application.persistentDataPath + "/" + "save.dat";

        gameState.mapName = "";
        gameState.contentTriggerList = new List<SaveContentTrigger>() { };
        gameState.currentQuestText = "";

        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (isSaveLoading)
        {
            isSaveLoading = false;
            LoadGameAfterMapEnter();
        }
    }

    public void ContentTriggerUpdate(ContentTrigger ct)
    {
        var thisCtId = ct.GetUniqueId();
        var index = gameState.contentTriggerList.FindIndex(a => a.id == thisCtId);
        if (index != -1)
        {
            // edytuj istniejacy
            gameState.contentTriggerList[index].isComplete = ct.isComplete;
        }
        else
        {
            // dodaj nowy
            gameState.contentTriggerList.Add(new SaveContentTrigger
            {
                id = thisCtId,
                isComplete = ct.isComplete,
            });
        }
    }


    public void SaveGame()
    {
        // get data
        gameState.mapName = SceneManager.GetActiveScene().name;
        gameState.characterTransform = GameObject.Find("Character").transform.position;
        gameState.characterRotation = GameObject.Find("Character").transform.rotation;
        gameState.currentQuestText = GameObject.FindObjectOfType<QuestManager>().currentQuest;


        // save to file
        string jsondata = JsonUtility.ToJson(gameState, true);
        File.WriteAllText(saveGamePath, jsondata);
        Debug.Log("Game saved to " + saveGamePath);
    }

    public void LoadGame()
    {
        if (File.Exists(saveGamePath))
        {
            string jsondata = File.ReadAllText(saveGamePath);
            gameState = JsonUtility.FromJson<GameSaveData>(jsondata);
        }
        else
        {
            throw new Exception("File with save dont exist (" + saveGamePath + ")");
        }

        // start loading target map
        isSaveLoading = true;
        SceneManager.LoadScene(gameState.mapName);
    }

    private void LoadGameAfterMapEnter()
    {
        // setup character
        var characterObj = GameObject.Find("Character");
        characterObj.transform.position = gameState.characterTransform;
        characterObj.transform.rotation = gameState.characterRotation;

        // setup quest
        var questManagerObj = GameObject.FindObjectOfType<QuestManager>();
        questManagerObj.UpdateCurrentQuestText(gameState.currentQuestText);

        // setup content triggers / TODO: move to OnSceneLoaded
        foreach (var ct in Resources.FindObjectsOfTypeAll<ContentTrigger>())
        {
            var saveContentTrigger = gameState.contentTriggerList.Find(sct => sct.id == ct.GetUniqueId());
            ct.isComplete = saveContentTrigger.isComplete;
            ct.gameObject.SetActive(!ct.isComplete);
        }
    }
}
