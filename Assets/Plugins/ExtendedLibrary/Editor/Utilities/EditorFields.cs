using UnityEngine;

namespace UnityEditor
{
    public static class EditorFields
    {
        public static sbyte SByteField(Rect position, sbyte value)
        {
            return SByteField(position, GUIContent.none, value);
        }

        public static sbyte SByteField(Rect position, GUIContent label, sbyte value)
        {
            int intValue = value;
            intValue = EditorGUI.IntField(position, label, intValue);

            if (intValue < sbyte.MinValue)
                return sbyte.MinValue;

            if (intValue > sbyte.MaxValue)
                return sbyte.MaxValue;

            unchecked
            {
                return (sbyte) intValue;
            }
        }

        public static sbyte SByteField(string label, sbyte value)
        {
            return SByteField(new GUIContent(label), value);
        }

        public static sbyte SByteField(GUIContent label, sbyte value)
        {
            int intValue = value;
            intValue = EditorGUILayout.IntField(label, intValue);

            if (intValue < sbyte.MinValue)
                return sbyte.MinValue;

            if (intValue > sbyte.MaxValue)
                return sbyte.MaxValue;

            unchecked
            {
                return (sbyte) intValue;
            }
        }

        public static byte ByteField(Rect position, byte value)
        {
            return ByteField(position, GUIContent.none, value);
        }

        public static byte ByteField(Rect position, GUIContent label, byte value)
        {
            int intValue = value;
            intValue = EditorGUI.IntField(position, label, intValue);

            if (intValue < byte.MinValue)
                return byte.MinValue;

            if (intValue > byte.MaxValue)
                return byte.MaxValue;

            unchecked
            {
                return (byte) intValue;
            }
        }

        public static byte ByteField(string label, byte value)
        {
            return ByteField(new GUIContent(label), value);
        }

        public static byte ByteField(GUIContent label, byte value)
        {
            int intValue = value;
            intValue = EditorGUILayout.IntField(label, intValue);

            if (intValue < byte.MinValue)
                return byte.MinValue;

            if (intValue > byte.MaxValue)
                return byte.MaxValue;

            unchecked
            {
                return (byte) intValue;
            }
        }

        public static short ShortField(Rect position, short value)
        {
            return ShortField(position, GUIContent.none, value);
        }

        public static short ShortField(Rect position, GUIContent label, short value)
        {
            int intValue = value;
            intValue = EditorGUI.IntField(position, label, intValue);

            if (intValue < short.MinValue)
                return short.MinValue;

            if (intValue > short.MaxValue)
                return short.MaxValue;

            unchecked
            {
                return (short) intValue;
            }
        }

        public static short ShortField(string label, short value)
        {
            return ShortField(new GUIContent(label), value);
        }

        public static short ShortField(GUIContent label, short value)
        {
            int intValue = value;
            intValue = EditorGUILayout.IntField(label, intValue);

            if (intValue < short.MinValue)
                return short.MinValue;

            if (intValue > short.MaxValue)
                return short.MaxValue;

            unchecked
            {
                return (short) intValue;
            }
        }

        public static ushort UShortField(Rect position, ushort value)
        {
            return UShortField(position, GUIContent.none, value);
        }

        public static ushort UShortField(Rect position, GUIContent label, ushort value)
        {
            int intValue = value;
            intValue = EditorGUI.IntField(position, label, intValue);

            if (intValue < ushort.MinValue)
                return ushort.MinValue;

            if (intValue > ushort.MaxValue)
                return ushort.MaxValue;

            unchecked
            {
                return (ushort) intValue;
            }
        }

        public static ushort UShortField(string label, ushort value)
        {
            return UShortField(new GUIContent(label), value);
        }

        public static ushort UShortField(GUIContent label, ushort value)
        {
            int intValue = value;
            intValue = EditorGUILayout.IntField(label, intValue);

            if (intValue < ushort.MinValue)
                return ushort.MinValue;

            if (intValue > ushort.MaxValue)
                return ushort.MaxValue;

            unchecked
            {
                return (ushort) intValue;
            }
        }

        public static uint UIntField(Rect position, uint value)
        {
            return UIntField(position, GUIContent.none, value);
        }

        public static uint UIntField(Rect position, GUIContent label, uint value)
        {
            long longValue = value;
            longValue = EditorGUI.LongField(position, label, longValue);

            if (longValue < uint.MinValue)
                return uint.MinValue;

            if (longValue > uint.MaxValue)
                return uint.MaxValue;

            unchecked
            {
                return (uint) longValue;
            }
        }

        public static uint UIntField(string label, uint value)
        {
            return UIntField(new GUIContent(label), value);
        }

        public static uint UIntField(GUIContent label, uint value)
        {
            long longValue = value;
            longValue = EditorGUILayout.LongField(label, longValue);

            if (longValue < uint.MinValue)
                return uint.MinValue;

            if (longValue > uint.MaxValue)
                return uint.MaxValue;

            unchecked
            {
                return (uint) longValue;
            }
        }

        public static ulong ULongField(Rect position, ulong value)
        {
            return ULongField(position, GUIContent.none, value);
        }

        public static ulong ULongField(Rect position, GUIContent label, ulong value)
        {
            var ulongStr = value.ToString();
            decimal ulongValue;

            try
            {
                if (!decimal.TryParse(EditorGUI.DelayedTextField(position, label, ulongStr), out ulongValue))
                {
                    ulongValue = value;
                }
            }
            catch
            {
                ulongValue = value;
            }

            if (ulongValue < ulong.MinValue)
                return ulong.MinValue;

            if (ulongValue > ulong.MaxValue)
                return ulong.MaxValue;

            unchecked
            {
                return (ulong) ulongValue;
            }
        }

        public static ulong ULongField(string label, ulong value)
        {
            return ULongField(new GUIContent(label), value);
        }

        public static ulong ULongField(GUIContent label, ulong value)
        {
            var ulongStr = value.ToString();
            decimal ulongValue;

            try
            {
                if (!decimal.TryParse(EditorGUILayout.DelayedTextField(label, ulongStr), out ulongValue))
                {
                    ulongValue = value;
                }
            }
            catch
            {
                ulongValue = value;
            }

            if (ulongValue < ulong.MinValue)
                return ulong.MinValue;

            if (ulongValue > ulong.MaxValue)
                return ulong.MaxValue;

            unchecked
            {
                return (ulong) ulongValue;
            }
        }

        public static char CharField(Rect position, char value)
        {
            return CharField(position, GUIContent.none, value);
        }

        public static char CharField(Rect position, GUIContent label, char value)
        {
            string stringValue = value.ToString();
            stringValue = EditorGUI.TextField(position, label, stringValue);

            if (stringValue.Length < 1)
                return char.MinValue;

            return stringValue[0];
        }

        public static char CharField(string label, char value)
        {
            return CharField(new GUIContent(label), value);
        }

        public static char CharField(GUIContent label, char value)
        {
            string stringValue = value.ToString();
            stringValue = EditorGUILayout.TextField(label, stringValue);

            if (stringValue.Length < 1)
                return char.MinValue;

            return stringValue[0];
        }

        public static Quaternion QuaternionField(Rect position, Quaternion value)
        {
            return QuaternionField(position, GUIContent.none, value);
        }

        public static Quaternion QuaternionField(Rect position, GUIContent label, Quaternion value)
        {
            var v4 = new Vector4(value.x, value.y, value.z, value.w);
            v4 = EditorGUI.Vector4Field(position, label, v4);

            return new Quaternion(v4.x, v4.y, v4.z, v4.w);
        }

        public static Quaternion QuaternionField(string label, Quaternion value)
        {
            return QuaternionField(new GUIContent(label), value);
        }

        public static Quaternion QuaternionField(GUIContent label, Quaternion value)
        {
            var v4 = new Vector4(value.x, value.y, value.z, value.w);
            v4 = EditorGUILayout.Vector4Field(label, v4);

            return new Quaternion(v4.x, v4.y, v4.z, v4.w);
        }

        public static Matrix4x4 Matrix4x4Field(Rect position, Matrix4x4 value)
        {
            return Matrix4x4Field(position, GUIContent.none, value);
        }

        public static Matrix4x4 Matrix4x4Field(Rect position, GUIContent label, Matrix4x4 value)
        {
            position = EditorGUI.PrefixLabel(position, label);

            var originalLabelWidth = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = 28f;

            var contentPosition = position;
            var firstX = contentPosition.x;
            var itemWidth = (Screen.width - contentPosition.x) / 4f - 5.7f;
            var itemOffset = 6f;
            contentPosition.width = itemWidth;

            // Row 0
            {
                value.m00 = EditorGUI.FloatField(contentPosition, "M00", value.m00);

                contentPosition.x += itemWidth + itemOffset;
                value.m01 = EditorGUI.FloatField(contentPosition, "M01", value.m01);

                contentPosition.x += itemWidth + itemOffset;
                value.m02 = EditorGUI.FloatField(contentPosition, "M02", value.m02);

                contentPosition.x += itemWidth + itemOffset;
                value.m03 = EditorGUI.FloatField(contentPosition, "M03", value.m03);
            }

            contentPosition = EditorGUILayout.GetControlRect();
            contentPosition.width = itemWidth;

            // Row 1
            {
                value.m10 = EditorGUI.FloatField(contentPosition, "M10", value.m10);

                contentPosition.x += itemWidth + itemOffset;
                value.m11 = EditorGUI.FloatField(contentPosition, "M11", value.m11);

                contentPosition.x += itemWidth + itemOffset;
                value.m12 = EditorGUI.FloatField(contentPosition, "M12", value.m12);

                contentPosition.x += itemWidth + itemOffset;
                value.m13 = EditorGUI.FloatField(contentPosition, "M13", value.m13);
            }

            contentPosition = EditorGUILayout.GetControlRect();
            contentPosition.width = itemWidth;

            // Row 2
            {
                value.m20 = EditorGUI.FloatField(contentPosition, "M20", value.m20);

                contentPosition.x += itemWidth + itemOffset;
                value.m21 = EditorGUI.FloatField(contentPosition, "M21", value.m21);

                contentPosition.x += itemWidth + itemOffset;
                value.m22 = EditorGUI.FloatField(contentPosition, "M22", value.m22);

                contentPosition.x += itemWidth + itemOffset;
                value.m23 = EditorGUI.FloatField(contentPosition, "M23", value.m23);
            }

            contentPosition = EditorGUILayout.GetControlRect();
            contentPosition.width = itemWidth;

            // Row 3
            {
                value.m30 = EditorGUI.FloatField(contentPosition, "M30", value.m30);

                contentPosition.x += itemWidth + itemOffset;
                value.m31 = EditorGUI.FloatField(contentPosition, "M31", value.m31);

                contentPosition.x += itemWidth + itemOffset;
                value.m32 = EditorGUI.FloatField(contentPosition, "M32", value.m32);

                contentPosition.x += itemWidth + itemOffset;
                value.m33 = EditorGUI.FloatField(contentPosition, "M33", value.m33);
            }

            EditorGUIUtility.labelWidth = originalLabelWidth;

            return value;
        }

        public static Matrix4x4 Matrix4x4Field(string label, Matrix4x4 value)
        {
            return Matrix4x4Field(new GUIContent(label), value);
        }

        public static Matrix4x4 Matrix4x4Field(GUIContent label, Matrix4x4 value)
        {
            EditorGUILayout.BeginVertical();
            EditorGUILayout.PrefixLabel(label);

            var originalLabelWidth = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = 28f;

            // Row 0
            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(20f);
            value.m00 = EditorGUILayout.FloatField("M00", value.m00);
            value.m01 = EditorGUILayout.FloatField("M01", value.m01);
            value.m02 = EditorGUILayout.FloatField("M02", value.m02);
            value.m03 = EditorGUILayout.FloatField("M03", value.m03);
            EditorGUILayout.EndHorizontal();

            // Row 1
            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(20f);
            value.m10 = EditorGUILayout.FloatField("M10", value.m10);
            value.m11 = EditorGUILayout.FloatField("M11", value.m11);
            value.m12 = EditorGUILayout.FloatField("M12", value.m12);
            value.m13 = EditorGUILayout.FloatField("M13", value.m13);
            EditorGUILayout.EndHorizontal();

            // Row 2
            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(20f);
            value.m20 = EditorGUILayout.FloatField("M20", value.m20);
            value.m21 = EditorGUILayout.FloatField("M21", value.m21);
            value.m22 = EditorGUILayout.FloatField("M22", value.m22);
            value.m23 = EditorGUILayout.FloatField("M23", value.m23);
            EditorGUILayout.EndHorizontal();

            // Row 3
            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(20f);
            value.m30 = EditorGUILayout.FloatField("M30", value.m30);
            value.m31 = EditorGUILayout.FloatField("M31", value.m31);
            value.m32 = EditorGUILayout.FloatField("M32", value.m32);
            value.m33 = EditorGUILayout.FloatField("M33", value.m33);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.EndVertical();
            EditorGUIUtility.labelWidth = originalLabelWidth;

            return value;
        }

        public static readonly Color FalseColor = Color.white;
        public static readonly Color TrueColor = Color.green;

        public static void Line(float height = 1f)
        {
            Color defaultColor = GUI.backgroundColor;
            GUI.backgroundColor = Color.black;
            GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(height));
            GUI.backgroundColor = defaultColor;
        }

        public static bool Toggle(bool value, GUIContent label, GUIStyle style = null, params GUILayoutOption[] options)
        {
            Color color = value ? TrueColor : FalseColor;
            Color defaultColor = GUI.backgroundColor;

            GUI.backgroundColor = color;
            if (GUILayout.Button(label, style == null ? GUI.skin.button : style, options))
            {
                value = !value;
            }
            GUI.backgroundColor = defaultColor;

            return value;
        }

        public static bool Toggle(bool value, string text, GUIStyle style = null, params GUILayoutOption[] options)
        {
            Color color = value ? TrueColor : FalseColor;
            Color defaultColor = GUI.backgroundColor;

            GUI.backgroundColor = color;

            if (GUILayout.Button(text, style == null ? GUI.skin.button : style, options))
            {
                value = !value;
            }

            GUI.backgroundColor = defaultColor;

            return value;
        }
    }
}
