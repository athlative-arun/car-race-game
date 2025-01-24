
using UnityEditor;
using UnityEngine;

public class WaypointManagerWindow : EditorWindow
{
    [MenuItem("Waypoint/Waypoint Editor Tool")]
    public static void ShowWindow()
    {
        GetWindow<WaypointManagerWindow>("Waypoint Editor Tool");
    }


    public Transform waypointOrigin;
    private void OnGUI(){
        SerializedObject obj = new SerializedObject(this);

        EditorGUILayout.PropertyField(obj.FindProperty("waypointOrigin"));
        if(waypointOrigin == null){
            EditorGUILayout.HelpBox("please assign a waypoint Origin transform.",MessageType.Warning);
        }
        else
        {
            EditorGUILayout.BeginVertical("Box");
            CreateButtons();
            EditorGUILayout.EndVertical();
        }
        obj.ApplyModifiedProperties();
    }

    void CreateButtons(){
        if(GUILayout.Button("Create Waypoint")){
            CreateWaypoint();
        }
    }
    void CreateWaypoint(){
        GameObject waypointObject = new GameObject("Waypoint "+ waypointOrigin.childCount, typeof(Waypoint));
        waypointObject.transform.SetParent(waypointOrigin, false);

        Waypoint waypoint = waypointOrigin.GetComponent<Waypoint>();

        if(waypointOrigin.childCount > 1){
            waypoint.previousWaypoint = waypointOrigin.GetChild(waypointOrigin.childCount - 2).GetComponent<Waypoint>();
            waypoint.previousWaypoint.nextWaypoint = waypoint;

            waypoint.transform.position = waypoint.previousWaypoint.transform.position;
            waypoint.transform.forward = waypoint.previousWaypoint.transform.forward;
        }

        Selection.activeGameObject = waypoint.gameObject;
    }
}
