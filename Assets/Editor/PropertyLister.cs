using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Reflection;
// страница 286.
[CustomPropertyDrawer(typeof(Example))]
public class PropertyLister : PropertyDrawer
{
    float InspectorHight = 0;
    float RowHight = 15;
    float RowSpacing = 5;

    public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        object o = property.serializedObject.targetObject;
        Example Ex = o.GetType().GetField(property.name).GetValue(o) as Example;

        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        Rect LayoutRect = new Rect(position.x, position.y, position.width, RowHight);

        foreach (var prop in typeof(Example).GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if (prop.PropertyType.Equals(typeof(int)))
            {
                prop.SetValue(Ex, EditorGUI.IntField(LayoutRect, prop.Name, (int)prop.GetValue(Ex, null)), null);
                LayoutRect = new Rect(LayoutRect.x, LayoutRect.y + RowHight+RowSpacing, LayoutRect.width, RowHight);
            }
            if (prop.PropertyType.Equals(typeof(float)))
            {
                prop.SetValue(Ex, EditorGUI.FloatField(LayoutRect, prop.Name, (float)prop.GetValue(Ex, null)), null);
                LayoutRect = new Rect(LayoutRect.x, LayoutRect.y + RowHight+RowSpacing, LayoutRect.width, RowHight);
            }
            if (prop.PropertyType.Equals(typeof(Color)))
            {
                prop.SetValue(Ex, EditorGUI.ColorField(LayoutRect, prop.Name, (Color)prop.GetValue(Ex, null)), null);
                LayoutRect = new Rect(LayoutRect.x, LayoutRect.y + RowHight+RowSpacing, LayoutRect.width, RowHight);
            }
        }
        InspectorHight = LayoutRect.y-position.y;

        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return InspectorHight;
    }
}
