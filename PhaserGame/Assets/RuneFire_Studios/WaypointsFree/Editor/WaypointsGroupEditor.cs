using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace WaypointsFree.WFEditor
{
    [CustomEditor(typeof(WaypointsGroup))]
    public class WaypointsGroupEditor : Editor
    {
        WaypointsGroup waypointsGroup;
        List<Waypoint> waypoints;

        Waypoint selectedWaypoint = null;

        private void OnEnable()
        {
            waypointsGroup = target as WaypointsGroup;
            waypoints = waypointsGroup.GetWaypointChildren();
        }

        private void OnSceneGUI()
        {
            DrawWaypoints(waypoints );
        }

        override public void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.BeginVertical();

            EditorGUILayout.LabelField("Waypoints");

            bool dorepaint = false;


            if (waypoints != null)
            {

                

                int delIndex = -1;
                for (int cnt = 0; cnt < waypoints.Count; cnt++)
                {
                    Color guiColor = GUI.color;

                    Waypoint cwp = waypoints[cnt];

                    if (cwp == selectedWaypoint)
                        GUI.color = Color.green;

                    EditorGUILayout.BeginHorizontal();
                    if (GUILayout.Button("S", GUILayout.Width(20)))
                    {
                        if(selectedWaypoint == cwp)
                        {
                            selectedWaypoint = null;
                        }
                        else
                        {
                            selectedWaypoint = cwp;
                        }
                        
                        dorepaint = true;

                    }

                    EditorGUI.BeginChangeCheck();
                    Vector3 oldV = cwp.GetPosition(waypointsGroup.XYZConstraint);
                    Vector3 newV = EditorGUILayout.Vector3Field("", oldV);
                    if(EditorGUI.EndChangeCheck())
                    {
                        Undo.RecordObject(waypointsGroup, "Waypoint Moved");
                        cwp.UpdatePosition(newV - oldV, waypointsGroup.XYZConstraint);
                    }
                    


                    if (GUILayout.Button("D", GUILayout.Width(25)))
                    {
                        delIndex = cnt;
                        dorepaint = true;

                    }
                    GUI.color = guiColor;
                    EditorGUILayout.EndHorizontal();

                }

                if (delIndex > -1)
                {
                    if (waypoints[delIndex] == selectedWaypoint)
                        selectedWaypoint = null;
                    waypoints.RemoveAt(delIndex);
                }

            }


            if (GUILayout.Button("Add"))
            {
                Undo.RecordObject(waypointsGroup, "Waypoint Added");
                int ndx = -1;
                if(selectedWaypoint != null)
                {
                    ndx = waypoints.IndexOf(selectedWaypoint);
                    if (ndx == -1)
                        selectedWaypoint = null;
                    else
                        ndx += 1;
                }

                
                Waypoint wp = new Waypoint();
                wp.CopyOther(selectedWaypoint);
                waypointsGroup.AddWaypoint(wp, ndx);
                selectedWaypoint = wp;
                dorepaint = true;

            }

            EditorGUILayout.EndVertical();
            if (dorepaint)
            {
                SceneView.RepaintAll();
            }

        }

        public void DrawWaypoints(List<Waypoint> waypoints)
        {
            bool doRepaint = false;
            if (waypoints != null)
            {

                int cnt = 0;
                foreach (Waypoint wp in waypoints)
                {
                    doRepaint |= DrawInScene(wp);

                    // Draw a pointer line 
                    if(cnt < waypoints.Count-1)
                    {
                        Waypoint wpnext = waypoints[cnt+1];
                        Handles.DrawLine(wp.GetPosition(waypointsGroup.XYZConstraint), wpnext.GetPosition(waypointsGroup.XYZConstraint));
                    }
                    else
                    {
                        Waypoint wpnext = waypoints[0];
                        Color c = Handles.color;
                        Handles.color = Color.gray;
                        Handles.DrawLine(wp.GetPosition(waypointsGroup.XYZConstraint), wpnext.GetPosition(waypointsGroup.XYZConstraint));
                        Handles.color = c;
                    }
                    cnt += 1;
                }
            }
            if(doRepaint)
            {
                Repaint();
            }

        }


        public bool DrawInScene(Waypoint waypoint, int controlID = -1)
        {
            if (waypoint == null)
            {
                Debug.Log("NO WP!");
                return false;
            }

            bool doRepaint = false;
            //None serialized field, gets "lost" during serailize updates;
            waypoint.SetWaypointGroup(waypointsGroup);
            


            if (selectedWaypoint == waypoint)
            {
                Color c = Handles.color;
                Handles.color = Color.green;

                //Vector3 newPos = Handles.FreeMoveHandle(waypoint.GetPosition(), waypoint.rotation, 1.0f, Vector3.zero, Handles.SphereHandleCap);
                EditorGUI.BeginChangeCheck();
                Vector3 oldpos = waypoint.GetPosition(waypointsGroup.XYZConstraint);
                Vector3 newPos = Handles.PositionHandle(oldpos, waypoint.rotation);

                float handleSize = HandleUtility.GetHandleSize(newPos);

                Handles.SphereHandleCap(-1, newPos, waypoint.rotation, 0.25f * handleSize, EventType.Repaint);
                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(waypointsGroup, "Waypoint Moved");
                    waypoint.UpdatePosition(newPos - oldpos, waypointsGroup.XYZConstraint);
                }
                
                Handles.color = c;
                
            }
            else
            {
                Vector3 currPos = waypoint.GetPosition(waypointsGroup.XYZConstraint);
                float handleSize = HandleUtility.GetHandleSize(currPos);
                if (Handles.Button(currPos, waypoint.rotation, 0.25f * handleSize, 0.25f * handleSize, Handles.SphereHandleCap))
                {
                    doRepaint = true;
                    selectedWaypoint = waypoint;
                }
             
            }
            return doRepaint;
        }






        // Menu item for creating a waypoints group
        [MenuItem("GameObject/WaypointsFree/Create WaypointsGroup")]
        public static void CreateRFPathManager()
        {
            GameObject go = new GameObject("WaypointsGroup");
            go.AddComponent<WaypointsGroup>();
            // Select it:
            Selection.activeGameObject = go;


        }


    }
}
