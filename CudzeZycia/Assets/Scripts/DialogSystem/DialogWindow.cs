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

        public Image LeftAvatarImage;
        public Image RightAvatarImage;

        private XNode.Node activeSegment;


        void Start()
        {
            // on start game disable / hide dialog ui
            gameObject.SetActive(false);
        }
        void OnEnable()
        {
            Setup();
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        void OnDisable()
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void Setup()
        {
            FindDialogStart();
        }

        private void FindDialogStart()
        {
            // Znajdz pocz¹tek dialogu (DialogStart)
            foreach (var node in activeDialog.nodes)
            {
                if (node.GetType() == typeof(DialogStart))
                {
                    var port = node.GetPort("Output");
                    if (port.IsConnected)
                    {
                        EazyUpdateDialog(port.Connection.node);
                        return;
                    }
                    else
                    {
                        Debug.LogWarning("DialogStart nie jest do niczego podlaczony");
                    }
                }
            }
            // Awaryjnie znajdz pocz¹tek dialogu (pierwszy bez inputa)
            foreach (XNode.Node node in activeDialog.nodes)
            {
                if (!node.GetInputPort("input").IsConnected)
                {
                    EazyUpdateDialog(node);
                    return;
                }
            }
            Debug.LogWarning("Dialog startowy nie zostal znaleziony!");
        }


        private void EazyUpdateDialog(XNode.Node newSegment)
        {
            if (newSegment == null)
                gameObject.SetActive(false);
            else if (newSegment.GetType() == typeof(DialogSegment))
                UpdateDialog(newSegment as DialogSegment);
            else if (newSegment.GetType() == typeof(SimpleDialog))
                UpdateDialog(newSegment as SimpleDialog);
            else
            {
                gameObject.SetActive(false);
                Debug.LogWarning("Unknown Dialog type");
            }
        }

        private void UpdateDialog(SimpleDialog newSegment)
        {
            activeSegment = newSegment;
            var avatarName = DialogAvatar.GetAvatarName(newSegment.AvatarName);
            dialogText.text = "<color=#777777>" + avatarName + ":</color> " + newSegment.DialogText;

            LeftAvatarImage.enabled = (newSegment.AvatarPosition == SimpleDialog.Sides.Left);
            LeftAvatarImage.sprite = DialogAvatar.GetAvatarSprite(newSegment.AvatarName);
            RightAvatarImage.sprite = DialogAvatar.GetAvatarSprite(newSegment.AvatarName);
            RightAvatarImage.enabled = (newSegment.AvatarPosition == SimpleDialog.Sides.Right);

            foreach (Transform child in buttonParent)
            {
                Destroy(child.gameObject);
            }

            var btn = Instantiate(buttonPrefab, buttonParent);
            btn.GetComponentInChildren<Text>().text = "Dalej...";
            btn.GetComponentInChildren<Button>().onClick.AddListener((() => {
                var nextDialog = newSegment.GetNextDialog();
                if (nextDialog != null)
                    EazyUpdateDialog(nextDialog);
                else
                    gameObject.SetActive(false);
            }));
        }

        private void UpdateDialog(DialogSegment newSegment)
        {
            activeSegment = newSegment;
            var avatarName = DialogAvatar.GetAvatarName(newSegment.AvatarName);
            dialogText.text = "<color=#777777>" + avatarName + ":</color> " + newSegment.DialogText;

            LeftAvatarImage.enabled = (newSegment.AvatarPosition == DialogSegment.Sides.Left);
            LeftAvatarImage.sprite = DialogAvatar.GetAvatarSprite(newSegment.AvatarName);
            RightAvatarImage.sprite = DialogAvatar.GetAvatarSprite(newSegment.AvatarName);
            RightAvatarImage.enabled = (newSegment.AvatarPosition == DialogSegment.Sides.Right);

            int answerIndex = 0;
            foreach (Transform child in buttonParent)
            {
                Destroy(child.gameObject);
            }

            foreach (var answer in newSegment.Answers)
            {
                var btn = Instantiate(buttonPrefab, buttonParent);
                var textComponent = btn.GetComponentInChildren<Text>();
                textComponent.text = answer.Message;
                textComponent.color = answer.GetTextColor();

                var index = answerIndex;
                btn.GetComponentInChildren<Button>().onClick.AddListener((() => {
                    var nextDialog = newSegment.GetNextDialogByAnswerId(index);
                    if(nextDialog != null)
                        EazyUpdateDialog(nextDialog);
                    else
                        gameObject.SetActive(false);
                }));

                answerIndex++;
            }
        }

    }
}