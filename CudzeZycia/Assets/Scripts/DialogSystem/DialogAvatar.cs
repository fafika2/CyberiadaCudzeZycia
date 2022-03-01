using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.DialogSystem
{
    public enum DialogAvatarType
    {
        FoxyDebug = 0,
        Skylar = 1,
    }


    public static class DialogAvatar
    {
        private static Dictionary<DialogAvatarType, string> DbFiles = new Dictionary<DialogAvatarType, string>(){
            {DialogAvatarType.FoxyDebug, "DialogAvatars/FoxyDebug"},
            {DialogAvatarType.Skylar, "DialogAvatars/Skylar"},

        };
        private static Dictionary<DialogAvatarType, string> DbNames = new Dictionary<DialogAvatarType, string>(){
            {DialogAvatarType.FoxyDebug, "FoxyDebug"},
            {DialogAvatarType.Skylar, "Skylar"},

        };

        public static Sprite GetAvatarSprite(DialogAvatarType dat)
        {
            //Load a Sprite (Assets/Resources/*)
            var avTexture = Resources.Load<Sprite>(DbFiles[dat]);
            if (avTexture is null)
            {
                avTexture = Resources.Load<Sprite>(DbFiles[DialogAvatarType.FoxyDebug]);
                Debug.LogWarning("Nie znaleziono avatara dla " + dat.ToString() + "!");
            }
            return avTexture;
        }

        public static Texture GetAvatarAsTexture(DialogAvatarType dat)
        {
            var avTexture = Resources.Load<Texture>(DbFiles[dat]);
            if (avTexture is null)
            {
                avTexture = Resources.Load<Texture>(DbFiles[DialogAvatarType.FoxyDebug]);
                Debug.LogWarning("Nie znaleziono avatara dla " + dat.ToString() + "!");
            }
            return avTexture;
        }

        public static string GetAvatarName(DialogAvatarType dat)
        {
            return DbNames[dat];
        }
    }
}
