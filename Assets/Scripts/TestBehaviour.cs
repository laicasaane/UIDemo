using UnityEngine;
using UnityEngine.Events;
using ExtendedLibrary.Events;
using UnityEditor;

//[ExecuteInEditMode]
public class TestBehaviour : MonoBehaviour
{
    //private A a = new A();
    //private B b = new B();

    private void Update()
    {
        //Print(this.a.DoSomething, new ExtendedAction<string>(this.b.DoSomething, "None"));

        //var all = Resources.FindObjectsOfTypeAll<UIDemo.UITextButton>();

        //if (all.Length >= 1)
        //{
            //var prefab = PrefabUtility.GetPrefabObject(all[0]);
            //print(prefab == null);
        //}
    }

    private void Print(UnityAction<string> action, ExtendedDelegate del)
    {
        Debug.Log(action.Method.Equals(del.Method));
    }

    private void DoSomething(string something)
    {
        Debug.Log($"Do {something}");
    }

    public class A
    {
        public void DoSomething(string something)
        {
            Debug.Log($"Do {something}");
        }
    }

    public class B
    {
        public void DoSomething(string something)
        {
            Debug.Log($"Do {something}");
        }
    }
}
