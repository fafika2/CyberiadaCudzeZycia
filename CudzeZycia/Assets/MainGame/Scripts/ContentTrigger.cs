using UnityEngine;
using MyBox;
using UnityEngine.Video;
using Scripts.DialogSystem;

public enum ContentTriggerType
{
    Video,
    Dialogs,
    ChangeObjective
}

[System.Serializable]
public class ContentTriggerItem
{
    public ContentTriggerType ContentType = ContentTriggerType.Video;

    [ConditionalField(new[] { nameof(ContentType) }, new[] { false }, ContentTriggerType.Video)]
    public VideoClip videoClip;

    [ConditionalField(new[] { nameof(ContentType) }, new[] { false }, ContentTriggerType.Dialogs)]
    public DialogGraph dialogGraph;

    [ConditionalField(new[] { nameof(ContentType) }, new[] { false }, ContentTriggerType.ChangeObjective)]
    public string newObjective;

    public double getVideoDurationSek()
    {
        return videoClip.length;
    }
}

public class ContentTrigger : MonoBehaviour
{
    public ContentTriggerItem[] scenarioList;

    private MyVideoPlayer myVideoPlayer;
    private DialogWindow dialogWindow;
    private QuestManager qm;
    private bool wasExecuted = false;

    void Start()
    {
        if(scenarioList.FirstIndex((e) => e.ContentType == ContentTriggerType.Video) != -1)
        {
            if (!myVideoPlayer) { myVideoPlayer = FindObjectOfType<MyVideoPlayer>(); }
            if (!myVideoPlayer) { Debug.LogError("Nie znaleziono MyVideoPlayer, ContentTrigger nie bêd¹ dzia³aæ poprawnie"); }
        }

        if (scenarioList.FirstIndex((e) => e.ContentType == ContentTriggerType.Dialogs) != -1)
        {
            if (!dialogWindow) { dialogWindow = FindObjectOfType<DialogWindow>(); }
            if (!dialogWindow) { Debug.LogError("Nie znaleziono DialogWindow, ContentTrigger nie bêd¹ dzia³aæ poprawnie"); }
        }

        if (scenarioList.FirstIndex((e) => e.ContentType == ContentTriggerType.ChangeObjective) != -1)
        {
            if (!qm) { qm = FindObjectOfType<QuestManager>(); }
            if (!qm) { Debug.LogError("Nie znaleziono QuestManager, ContentTrigger nie bêd¹ dzia³aæ poprawnie"); }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (wasExecuted) return; // dont run if was executed (run only one time)
        if (other.name != "Character") return; // detect only player colisions

        wasExecuted = true;
        Exec();
    }

    private async void Exec()
    {
        Debug.Log("ContentTrigger ("+gameObject.name + ") Uruchomiono");
        foreach (var e in scenarioList)
        {
            if(e.ContentType == ContentTriggerType.Video)
            {
                if (!e.videoClip) { Debug.LogError("videoClip not set! Dont play video."); continue; }
                Debug.Log("Uruchomiono Video (duration = " + e.videoClip.length + "sek)");
                await myVideoPlayer.PlayVideo(e.videoClip);
            }
            else if (e.ContentType == ContentTriggerType.Dialogs)
            {
                if (!e.dialogGraph) { Debug.LogError("dialogGraph not set! Dont start dialog."); continue; }
                Debug.Log("Uruchomiono Dialog (name = " + e.dialogGraph.name + "; length = "+ e.dialogGraph.nodes.Count+ ")");
                await dialogWindow.OpenDialogAndWaitForClose(e.dialogGraph);
            }
            else if (e.ContentType == ContentTriggerType.ChangeObjective)
            {
                Debug.Log("Nowy cel ("+ e.newObjective + ")");
                qm.UpdateCurrentQuestText(e.newObjective);
            }
            else
            {
                Debug.LogError("ContentTriggerType" + e.ContentType + " not implemented");
            }
        }

        Debug.Log("ContentTrigger (" + gameObject.name + ") Done!");
        gameObject.SetActive(false);
    }
}
