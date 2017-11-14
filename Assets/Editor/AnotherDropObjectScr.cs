using UnityEditor;
using UnityEngine;

public class AnotherDropObjectScr : EditorWindow
{
    RaycastHit hit;
    float yOffset;
    int savedLayer;
    bool alignNormals;
    Vector3 upVector = Vector3.zero;
    [MenuItem("Window/Another Drop Object")]
    static void Awake()
    {
        EditorWindow.GetWindow<AnotherDropObjectScr>().Show(); // Get existing open window or if none, make a new one
    }

    private void OnGUI()
    {
        GUILayout.Label("Drop using: ", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("Bottom"))
        {
            DropObject("Bottom");
        }
        if (GUILayout.Button("Origin"))
        {
            DropObject("Origin");
        }
        if (GUILayout.Button("Center"))
        {
            DropObject("Center");
        }
        EditorGUILayout.EndHorizontal();
            // toggle to align the object with the normal direction of the surface
        alignNormals = EditorGUILayout.ToggleLeft("Align Normals", alignNormals);
        if(alignNormals)
        {
            EditorGUILayout.BeginHorizontal();
            //// Vector3 helping to specify the Up vector of the object
            // default has 90° on the Y axis, this is because by default
            // the objects I import have a rotation.
            // If anyone has a better way to do this I'd be happy
            // to see a better solution!
            upVector = EditorGUILayout.Vector3Field("Up Vector", upVector);
            GUILayout.EndHorizontal();
        }
    }

    void DropObject(string method)
    {
        for (int i = 0; i < Selection.transforms.Length; i++)  // drop multi-selected objects using the selected method
        {
            Undo.RecordObjects(Selection.transforms, "Drop Objects"); // позволяет использовать ctrl+z
            GameObject go = Selection.transforms[i].gameObject; // get the gameobject
            if (!go)  // if there's no gameobject, skip the step — probably unnecessary but hey…
                continue;

            Bounds bounds = go.GetComponent<Renderer>().bounds; // get the renderer's bounds
            savedLayer = go.layer; // save the gameobject's initial layer
            go.layer = 2; // set the gameobject's layer to ignore raycast

            if (Physics.Raycast(go.transform.position, -Vector3.up, out hit)) // check if raycast hits something
            {
                switch(method) // determine how the y position will need to be adjusted
                {
                    case "Bottom":
                        yOffset = go.transform.position.y - bounds.min.y;
                        break;
                    case "Origin":
                        yOffset = 0.0f;
                        break;
                    case "Center":
                        yOffset = bounds.center.y - go.transform.position.y;
                        break;
                }
                if(alignNormals) // if "Align Normals" is checked, set the gameobject's rotation               
                {
                    go.transform.up = hit.normal + upVector; // to match the raycast's hit position's normal, and add the specified offset.
                }
                go.transform.position = new Vector3(hit.point.x, hit.point.y + yOffset, hit.point.z);
            }
            go.layer = savedLayer; // restore the gameobject's layer to it's initial layer
        }
    }
}
