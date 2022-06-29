using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public TMP_Text currentQuestTMP_Text;
    public string currentQuest;

    private SaveGameSingleton saveGameInstance;

    void Awake()
    {
        saveGameInstance = FindObjectOfType<SaveGameSingleton>();
    }

    public void UpdateCurrentQuestText(string text)
    {
        currentQuestTMP_Text.SetText(text);
        currentQuest = text;
        saveGameInstance.gameState.currentQuestText = text;
    }
}
