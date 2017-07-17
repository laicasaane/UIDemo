using UnityEngine;
using UnityEditor;

namespace UIDemo.Editor
{
    public static class Creator
    {
        public static void Create<T>(string undo) where T : UIElement
        {
            var objects = Resources.FindObjectsOfTypeAll<T>();

            foreach (var obj in objects)
            {
                if (!obj)
                    continue;

                var prefab = PrefabUtility.FindPrefabRoot(obj.gameObject);
                var component = prefab.GetComponent<T>();

                if (!component)
                    continue;

                if (component.GetType().IsSubclassOf(typeof(T)))
                    continue;

                var instance = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
                instance.transform.SetParent(Selection.activeTransform, false);
                PrefabUtility.DisconnectPrefabInstance(instance);

                Undo.RegisterCreatedObjectUndo(instance, undo);

                break;
            }
        }

        [MenuItem("GameObject/UI/UIDemo/UIText")]
        public static void CreateUIText()
        {
            Create<UIText>("CreateUIText");
        }

        [MenuItem("GameObject/UI/UIDemo/UITextButton")]
        public static void CreateUITextButton()
        {
            Create<UITextButton>("CreateUITextButton");
        }

        [MenuItem("GameObject/UI/UIDemo/UITextInput")]
        public static void CreateUITextInput()
        {
            Create<UITextInput>("CreateUITextInput");
        }

        [MenuItem("GameObject/UI/UIDemo/UIDialog")]
        public static void CreateUIDialog()
        {
            Create<UIDialog>("CreateUIDialog");
        }

        [MenuItem("GameObject/UI/UIDemo/UIInfoBox")]
        public static void CreateUIInfoBox()
        {
            Create<UIInfoBox>("CreateUIInfoBox");
        }
    }
}
