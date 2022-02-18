using System;
using System.Collections.Generic;
using XNode;

/*
S�u�y do tworzenia Nod�w (blok�w) w grafie z dialogami 
*/

namespace Scripts.DialogSystem
{
    [Serializable]
    public struct Connection { }
    public class DialogSegment : Node
    {
        [Input]
        public Connection input; // wejscie do bloku

        // opcje bloku
        public string DialogText;

        // wyjscia z bloku (i opcje kt�re s� w Answers)
        [Output(dynamicPortList = true)]
        public List<string> Answers;


        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}