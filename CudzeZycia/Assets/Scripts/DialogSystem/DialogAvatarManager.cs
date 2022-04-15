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
        Ash = 8,

        Zbir_Rick = 5,
        Zbir_Paul = 6,
        Zbir_Jack = 7,

        Szef_Kurierow = 9,
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
            var obj = Data.FirstOrDefault(x => x.Type == dat);
            if (obj == null) { return  Data[0].Avatar; }
            return obj.Avatar;
        }

        public Texture GetAvatarAsTexture(DialogAvatarType dat)
        {
            var obj = Data.FirstOrDefault(x => x.Type == dat);
            if (obj == null) { return Data[0].Avatar.texture; }
            return obj.Avatar.texture;
        }

        public string GetAvatarName(DialogAvatarType dat)
        {
            var obj = Data.FirstOrDefault(x => x.Type == dat);
            if (obj == null) { return "--MISSING CONFIG--"; }
            return obj.Name;
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