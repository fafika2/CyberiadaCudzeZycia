using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// tylko do ³adowania sejwa gry na mapie
public class LoadGame : MonoBehaviour
{
    private GameSaveData gameSaveData;
    private bool loadWasTriggered = true;

    void Awake()
    {
        // DontDestroyOnLoad(gameObject); // only works on root components, it is used in PreloadScript.cs
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void SetGameSaveData(GameSaveData gsd)
    {
        gameSaveData = gsd;
        loadWasTriggered = false;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!loadWasTriggered)
        {
            SaveLoadGame.LoadGameOnMapEnter(gameSaveData);
        }
    }
}
