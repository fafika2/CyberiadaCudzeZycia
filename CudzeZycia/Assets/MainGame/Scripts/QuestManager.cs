using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public TMP_Text currentQuest;

    void Start()
    {
        UpdateCurrentQuestText("Obudü starego pijanego");
    }

    public void UpdateCurrentQuestText(string text)
    {
        currentQuest.SetText(text);
    }
}
