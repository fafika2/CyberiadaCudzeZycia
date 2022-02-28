using System;
using System.Collections.Generic;
using XNode;
using UnityEngine;


namespace Scripts.DialogSystem
{
    [NodeWidth(250), NodeTint("#40603e")]
    public class SimpleDialog : Node
    {
        [Input]
        public Connection input; // wejscie do bloku

        public DialogAvatarType AvatarName = DialogAvatarType.FoxyDebug;

        public enum Sides
        {
            Left = 1,
            Right = 2,
        }
        public Sides AvatarPosition = Sides.Right;

        [TextArea(4, 500)]
        public string DialogText;

        [Output]
        public Connection Output;


        public override object GetValue(NodePort port)
        {
            return null;
        }

        public Node GetNextDialog()
        {
            var port = GetPort("Output");
            if (port.IsConnected)
            {
                var node = port.Connection.node;
                return node;
            }
            else
            {
                return null;
            }
        }
    }
}