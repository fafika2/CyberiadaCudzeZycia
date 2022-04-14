using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Scripts.DialogSystem
{
    public enum DialogAvatarType
    {
        FoxyDebug = 0,
        Lektor = 3,
        Skylar = 1,
        Faint = 2,
        Grey = 4,
    }

    [CreateAssetMenu(fileName = "DialogAvatarManager", menuName = "DialogSystem/DialogAvatarManager")]
    public class DialogAvatarManager : ScriptableObject
    {
        [Serializable]
        public class AvatarData
        {
            public DialogAvatarType Type;
            public Sprite Avatar;
            public string Name;
        }

        public List<AvatarData> Data;


        public Sprite GetAvatarSprite(DialogAvatarType dat)
        {
            return Data.FirstOrDefault(x => x.Type == dat).Avatar;
        }

        public Texture GetAvatarAsTexture(DialogAvatarType dat)
        {
            return Data.FirstOrDefault(x => x.Type == dat).Avatar.texture;
        }

        public string GetAvatarName(DialogAvatarType dat)
        {
            return Data.FirstOrDefault(x => x.Type == dat).Name;
        }

        public static DialogAvatarManager GetResourceDialogAvatarManager()
        {
            // U¿ywane tylko przez node editor, i tylko przez niego ma byæ u¿ywane!
            var res = Resources.Load<DialogAvatarManager>("DialogAvatarManager");
            if(res == null)
            {
                Debug.LogError("Nie znaleziono DialogAvatarManager, plik DialogAvatarManager powinien byæ w folderze Resources");
            }
            return res;
        }
    }
}