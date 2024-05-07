using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace UnityUtils.Editor
{
    public static class GameWindowShortcuts
    {
        [MenuItem("UnityUtils/Toggle Maximize Game View %m")]
        private static void ToggleMaximizeGameView()
        {
            EditorWindow win = GetEditorWindow("GameView");
            if (win != null)
            {
                win.maximized = !win.maximized;
            }
        }

        [MenuItem("UnityUtils/Minimize Game View & Get Mouse Focus %#m")]
        private static void MinimizeGameViewAndFocusHierarchy()
        {
            EditorWindow window = EditorWindow.focusedWindow;
            Type T = Type.GetType($"UnityEditor.GameView,UnityEditor");
            if (window == null || window.GetType() != T)
            {
                return;
            }

            window.maximized = false;
            Cursor.visible = true;

            EditorWindow win = GetEditorWindow("SceneHierarchyWindow");
            if (win != null)
            {
                win.Focus();
            }
        }

        private static EditorWindow GetEditorWindow(string type)
        {
            EditorWindow[] allWindows = Resources.FindObjectsOfTypeAll<EditorWindow>();
            Type T = Type.GetType($"UnityEditor.{type},UnityEditor");
            EditorWindow window = allWindows.FirstOrDefault(editorWindow => editorWindow.GetType() == T);
            return window;
        }
    }
}