using System.Collections.Generic;
using UnityEngine;

// chyba do usuniecia - Kamil

namespace Scripts.DialogSystem
{
    [CreateAssetMenu(fileName = "New Dialog", menuName = "Dialog Part 2/Dialog", order = 0)]
    public class Dialog : ScriptableObject
    {

        public List<DialogSegment> segments;

    }
}