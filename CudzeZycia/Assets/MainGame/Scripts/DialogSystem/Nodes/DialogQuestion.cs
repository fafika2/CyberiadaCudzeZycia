using System;
using System.Collections.Generic;
using XNode;
using UnityEngine;

/*
S�u�y do tworzenia Nod�w (blok�w) w grafie z dialogami 
*/

namespace Scripts.DialogSystem
{
    [NodeWidth(250), NodeTint("#5e603e")]
    public class DialogQuestion : DialogNode
    {

        // wyjscia z bloku (i opcje kt�re s� w Answers)
        [Output(dynamicPortList = true, connectionType = ConnectionType.Override)]
        public List<DialogAnswer> Answers;


        public override DialogNode GetNextDialog(int answerId)
        {         
            var port = GetPort("Answers " + answerId);
            if (port.IsConnected)
            {
                var node = port.Connection.node;
                return node as DialogNode;
            }
            else
            {
                return null;
            }
        }
    }
}