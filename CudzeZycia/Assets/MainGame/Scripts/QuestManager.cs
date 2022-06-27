using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public TMP_Text currentQuestTMP_Text;
    public string currentQuest;

    void Start()
    {
        UpdateCurrentQuestText(""); // clean up on start
    }

    public void UpdateCurrentQuestText(string text)
    {
        currentQuestTMP_Text.SetText(text);
        currentQuest = text;
    }
}
