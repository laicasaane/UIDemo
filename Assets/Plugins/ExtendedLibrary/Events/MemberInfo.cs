using System;
using System.Reflection;
using UnityEngine;

namespace ExtendedLibrary.Events
{
    public partial class ExtendedEvent
    {
        [Serializable]
        public class MemberInfo
        {
            [HideInInspector]
            [SerializeField]
            private ObjectType returnType = ObjectType.Void;

            [HideInInspector]
            [SerializeField]
            private MemberType memberType = MemberType.None;

            [HideInInspector]
            [SerializeField]
            private string memberName = string.Empty;

            [HideInInspector]
            [SerializeField]
            private UnityEngine.Object target;

            [HideInInspector]
            [SerializeField]
            private string targetFullName = string.Empty;

            /// <summary>
            /// AssemblyQualifiedName
            /// </summary>
            [HideInInspector]
            [SerializeField]
            private string[] parameterTypes = new string[0];

            private Type typeOf;
            private FieldInfo field;
            private PropertyInfo property;
            private MethodInfo method;
            private object[] parameters;

            public object Invoke(UnityEngine.Object target, Value[] values)
            {
                if (target == null)
                {
                    throw new ArgumentNullException("target");
                }

                if (this.target == null)
                {
                    if (this.memberType == MemberType.None || string.IsNullOrEmpty(this.targetFullName) || this.returnType == ObjectType.Void)
                    {
                        Debug.LogError("Corrupted data.");
                        return null;
                    }

                    this.target = GetActualTarget(target);

                    if (this.target == null)
                    {
                        Debug.LogErrorFormat("Target of type {0} cannot be found.", this.targetFullName);
                        return null;
                    }
                }

                if (this.typeOf == null)
                {
                    this.typeOf = this.target.GetType();
                }

                switch (this.memberType)
                {
                    case MemberType.Field:
                        return InvokeField(values);

                    case MemberType.Property:
                        return InvokeProperty(values);

                    case MemberType.Method:
                        return InvokeMethod(values);

                    default:
                        return null;
                }
            }

            private object InvokeField(Value[] values)
            {
                if (values == null || values.Length < 1)
                {
                    Debug.LogWarning("No value to be set.");
                    return null;
                }

                if (this.returnType != values[0].Type)
                {
                    Debug.LogErrorFormat("Types mismatched: expected {0}, received {1}.",
                        this.returnType, values[0].Type);

                    return null;
                }

                if (this.field == null)
                {
                    this.field = this.typeOf.GetField(this.memberName);

                    if (this.field == null)
                    {
                        this.field = this.typeOf.GetField(this.memberName, BindingFlags.Instance | BindingFlags.NonPublic);
                    }
                }

                if (this.field == null)
                {
                    Debug.LogErrorFormat("Field {0} cannot be found.", this.memberName);
                    return null;
                }

                var value = values[0].Get();
                this.field.SetValue(this.target, values[0].Get());

                return value;
            }

            private object InvokeProperty(Value[] values)
            {
                if (values == null || values.Length < 1)
                {
                    Debug.LogWarning("No value to be set.");
                    return null;
                }

                if (this.returnType != values[0].Type)
                {
                    Debug.LogErrorFormat("Types mismatched: expected {0}, received {1}.",
                        this.returnType, values[0].Type);

                    return null;
                }

                if (this.property == null)
                {
                    this.property = this.typeOf.GetProperty(this.memberName);

                    if (this.property == null)
                        this.property = this.typeOf.GetProperty(this.memberName, BindingFlags.Instance | BindingFlags.NonPublic);
                }

                if (this.property == null)
                {
                    Debug.LogErrorFormat("Property {0} cannot be found.", this.memberName);
                    return null;
                }

                var value = values[0].Get();
                this.property.SetValue(this.target, value, null);

                return value;
            }

            private object InvokeMethod(Value[] values)
            {
                if (this.parameterTypes.Length > 0 &&
                    (values == null || values.Length <= 0 || this.parameterTypes.Length != values.Length))
                {
                    Debug.LogErrorFormat("Number of parameters mismatched: expected {0}, received {1}.",
                        this.parameterTypes.Length, values == null ? 0 : values.Length);

                    return null;
                }

                if (this.method == null)
                {
                    var paramTypes = new Type[values.Length];

                    for (var i = 0; i < values.Length; ++i)
                    {
                        paramTypes[i] = values[i].TypeOf;
                        if (values[i].TypeOf == null)
                            Debug.LogFormat("{0} Null: {1}", i, values[i].FullTypeName);
                    }

                    this.method = this.typeOf.GetMethod(this.memberName, paramTypes);

                    if (this.method == null)
                    {
                        this.method = this.typeOf.GetMethod(this.memberName, BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder, paramTypes, null);
                    }
                }

                if (this.method == null)
                {
                    Debug.LogErrorFormat("Method {0} cannot be found.", this.memberName);
                    return null;
                }

                if (this.parameterTypes.Length <= 0)
                {
                    return this.method.Invoke(this.target, null);
                }
                else
                {
                    if (this.parameters == null)
                    {
                        this.parameters = new object[this.parameterTypes.Length];

                        for (var i = 0; i < this.parameterTypes.Length; ++i)
                        {
                            var paramType = this.parameterTypes[i];
                            var valueType = values[i].FullTypeName;

                            if (!paramType.Equals(valueType))
                            {
                                Debug.LogErrorFormat("Types mismatched at {0}: expected {1}, received {2}.",
                                    i, paramType, valueType);

                                this.parameters = null;
                                return null;
                            }

                            this.parameters[i] = values[i].Get();
                        }
                    }

                    return this.method.Invoke(this.target, this.parameters);
                }
            }

            private UnityEngine.Object GetActualTarget(UnityEngine.Object target)
            {
                try
                {
                    if (target is GameObject)
                    {
                        return ((GameObject) target).GetComponent(this.targetFullName);
                    }

                    return target;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
