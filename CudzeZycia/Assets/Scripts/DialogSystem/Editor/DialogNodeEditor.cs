using UnityEditorInternal;
using UnityEngine;
using XNode;
using XNodeEditor;

/// <summary>
/// Dziêki temu mo¿na zmieniaæ wygl¹d nodów
/// </summary>

namespace Scripts.DialogSystem.Editor
{
    [CustomNodeEditor(typeof(DialogSegment))]
    public class DialogNodeEditor : NodeEditor
    {
        public override void OnBodyGUI()
        {
            serializedObject.Update();

            var segment = serializedObject.targetObject as DialogSegment;

            NodeEditorGUILayout.PortField(segment.GetPort("input"));

            // display place to edit message
            GUILayout.Label("Message");
            segment.DialogText = GUILayout.TextArea(segment.DialogText, new GUILayoutOption[]
            {
                GUILayout.MinHeight(50),
            });

            // Dynamic List with answers
            NodeEditorGUILayout.DynamicPortList(
                "Answers", // field name
                typeof(string), // field type
                serializedObject, // serializable object
                NodePort.IO.Input, // new port i/o
                Node.ConnectionType.Override, // new port connection type
                Node.TypeConstraint.None,
                OnCreateReorderableList); // onCreate override. This is where the magic 


            foreach (XNode.NodePort dynamicPort in target.DynamicPorts)
            {
                if (NodeEditorGUILayout.IsDynamicPortListPort(dynamicPort)) continue;
                NodeEditorGUILayout.PortField(dynamicPort);
            }

            serializedObject.ApplyModifiedProperties();
        }

        void OnCreateReorderableList(ReorderableList list)
        {
            /// <summary>
            /// Renderowanie odpowiedzi w edytorze
            /// </summary>

            list.elementHeightCallback = (int index) =>
            {
                return 60; // wysokoœæ jednej Answer
            };

            // Override drawHeaderCallback to display node's name instead
            list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
            {
                var segment = serializedObject.targetObject as DialogSegment;

                NodePort port = segment.GetPort("Answers " + index);

                segment.Answers[index] = GUI.TextArea(rect, segment.Answers[index]);

                if (port != null)
                {
                    Vector2 pos = rect.position + (port.IsOutput ? new Vector2(rect.width + 6, 0) : new Vector2(-36, 0));
                    NodeEditorGUILayout.PortField(pos, port);
                }
            };
        }
    }
}