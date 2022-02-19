using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Kontroler okna z dialogiem w grze
/// </summary>

namespace Scripts.DialogSystem
{
    public class DialogWindow : MonoBehaviour
    {
        public TMP_Text dialogText;

        public DialogGraph activeDialog;

        public GameObject buttonPrefab;

        public Transform buttonParent;

        private DialogSegment activeSegment;


        void OnEnable()
        {
            Debug.Log("Open Dialog");
            Setup();
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        void OnDisable()
        {
            Debug.Log("Close Dialog");
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void Setup()
        {
            // Znajdz pocz¹tek dialogu (pierwszy bez inputa)
            foreach (DialogSegment node in activeDialog.nodes)
            {
                if (!node.GetInputPort("input").IsConnected)
                {
                    UpdateDialog(node);
                    return;
                }
            }
            Debug.LogWarning("Dialog startowy nie zostal znaleziony!");
        }

        public void AnswerClicked(int clickedIndex)
        {
            var port = activeSegment.GetPort("Answers " + clickedIndex);
            if (port.IsConnected)
                UpdateDialog(port.Connection.node as DialogSegment);
            else
                gameObject.SetActive(false);
        }

        private void UpdateDialog(DialogSegment newSegment)
        {
            activeSegment = newSegment;
            dialogText.text = newSegment.DialogText;
            int answerIndex = 0;
            foreach (Transform child in buttonParent)
            {
                Destroy(child.gameObject);
            }

            foreach (var answer in newSegment.Answers)
            {
                var btn = Instantiate(buttonPrefab, buttonParent);
                btn.GetComponentInChildren<Text>().text = answer.Message;

                var index = answerIndex;
                btn.GetComponentInChildren<Button>().onClick.AddListener((() => { AnswerClicked(index); }));

                answerIndex++;
            }
        }
    }
}