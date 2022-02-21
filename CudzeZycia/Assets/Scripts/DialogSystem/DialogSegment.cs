using System;
using System.Collections.Generic;
using XNode;
using UnityEngine;

/*
S�u�y do tworzenia Nod�w (blok�w) w grafie z dialogami 
*/

namespace Scripts.DialogSystem
{
    [Serializable]
    public struct Connection { }

    [NodeWidth(250)]
    public class DialogSegment : Node
    {
        [Input]
        public Connection input; // wejscie do bloku

        // opcje bloku
        [TextArea(4, 500)]
        public string DialogText = "Wiadomo��";

        public string AvatarName = "Tajemniczy Nieznajomy";
        public Sprite AvatarImage;

        public enum Sides
        {
            Left = 1,
            Right = 2,
        }
        public Sides AvatarPosition = Sides.Right;


        // wyjscia z bloku (i opcje kt�re s� w Answers)
        [Output(dynamicPortList = true, connectionType = ConnectionType.Override)]
        public List<DialogAnswer> Answers;


        public override object GetValue(NodePort port)
        {
            return null;
        }

        public Node GetNextDialogByAnswerId(int index)
        {            
            var port = GetPort("Answers " + index);
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