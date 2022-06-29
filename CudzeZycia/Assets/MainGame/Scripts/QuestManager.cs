using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public TMP_Text currentQuestTMP_Text;
    public string currentQuest;

    void Awake()
    {
        UpdateCurrentQuestText(""); // clean up on awake (not start, becouse on start is set data from save file)
    }

    public void UpdateCurrentQuestText(string text)
    {
        currentQuestTMP_Text.SetText(text);
        currentQuest = text;
    }
}
