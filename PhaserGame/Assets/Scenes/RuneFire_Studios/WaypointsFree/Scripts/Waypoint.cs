using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaypointsFree
{
    public enum PositionConstraint
    {
        XYZ,        // 3D
        XY,         // 2D
        XZ          // 2D
    }

    /// <summary>
    /// Traversal direction for list of waypoints (in the WaypointpointsGroup)
    /// </summary>
    public enum TravelDirection
    {
        FORWARD,  //  0 to Length-1 
        REVERSE   // Length-1 to 0
    }
    public enum EndpointBehavior
    {
        STOP,       // Movement stops when end position reached
        LOOP,       // Movement loops back to first position
        PINGPONG,   // Reverse direction through the the positions list
    }
    public enum MoveType
    {
        LERP,                   // Uses the MoveLerpSimple function to update transform position
        FORWARD_TRANSLATE       // uses MoveForwardToNext function to translate position - ROTATION DEPENDENT!
    }


    /// <summary>
    /// Waypoint class  - managed through the WaypointGroups editor
    /// 
    /// </summary>
    [Serializable]
    public class Waypoint
    {
        // OFFSET position to parent WaypointsGroup; 
        // Use GETPOSITION to read properly (as it depends on the PositionConstraint of the WaypointGroup parent)
        public Vector3 position;

        [HideInInspector]
        public Quaternion rotation = Quaternion.identity;

        [SerializeField]
        [HideInInspector]
        Vector3 xyzPosition;    // OFFSET position to parent WaypointsGroup

        [HideInInspector]
        [SerializeField]
        Vector3 xyPosition;     // OFFSET position to parent WaypointsGroup

        [HideInInspector]
        [SerializeField]
        Vector3 xzPosition;     // OFFSET position to parent WaypointsGroup

        WaypointsGroup wpGroup;


        public Vector3 XY
        {
            get { return xyPosition; }
        }

        public Vector3 XYZ
        {
            get { return xyzPosition; }
        }
        public Vector3 XZ
        {
            get { return xzPosition; }
        }


        public void SetWaypointGroup(WaypointsGroup wpg)
        {
            wpGroup = wpg;
        }

        public void CopyOther(Waypoint other)
        {
            if (other == null) return;

            xyPosition = other.XY;
            xzPosition = other.XZ;
            xyzPosition = other.XYZ;

            Debug.Log(other.XYZ);
            Debug.Log(xyzPosition);
        }

        public Vector3 GetPosition(PositionConstraint constraint=PositionConstraint.XYZ)
        {
            if(wpGroup != null)
            {
                constraint = wpGroup.XYZConstraint;
            }

            if (constraint == PositionConstraint.XY)
                position = xyPosition;
            else if (constraint == PositionConstraint.XZ)
                position = xzPosition;
            else
                position = xyzPosition;

            if (wpGroup != null)
                return wpGroup.transform.position + position;
            else
                return position;
        }

        public void UpdatePosition( Vector3 newPos, PositionConstraint constraint )
        {

            xyPosition.x += newPos.x;
            xzPosition.x += newPos.x;
            xyzPosition.x += newPos.x;

            if(constraint == PositionConstraint.XY)
            {
                xyzPosition.y += newPos.y;
                xyPosition.y += newPos.y;
            }
            else if(constraint == PositionConstraint.XZ)
            {
                xzPosition.z += newPos.z;
                xyzPosition.z += newPos.z;
            }
            else if(constraint == PositionConstraint.XYZ)
            {
                xyzPosition.y += newPos.y;
                xyzPosition.z += newPos.z;

                xyPosition.y += newPos.y;
                xzPosition.z += newPos.z;
            }
            
        }

    }
}
