using UnityEditor;
using UnityEngine;

namespace UnityUtils.Editor
{
    public class ToggleGameObjectActive : ScriptableObject
    {
        [MenuItem("Edit/Toggle Active _&r")] 
        static void ToggleActiveState()
        {
            GameObject[] selectedObjects = Selection.gameObjects;

            Undo.IncrementCurrentGroup();

            foreach (GameObject obj in selectedObjects)
            {
                Undo.RecordObject(obj, "Toggle Active State");
                bool isActive = obj.activeSelf;
                obj.SetActive(!isActive);
            }

            Undo.CollapseUndoOperations(Undo.GetCurrentGroup());
        }
    }
}

