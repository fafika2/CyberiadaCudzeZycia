using UnityEditor;
using CleverCrow.Fluid.UniqueIds;

// Wy�wietlanie unikalnego id przy ContentTrigger (u�ywane przy tworzeniu sejw�w)
[CustomEditor(typeof(ContentTrigger))]
class ContentTriggerGUIInspector : Editor
{
    public override void OnInspectorGUI()
    {
        ContentTrigger ct = (ContentTrigger)target;
        var uniqueId = ct.GetComponent<UniqueId>();
        EditorGUILayout.SelectableLabel(uniqueId.Id);
        base.OnInspectorGUI();
    }
}
