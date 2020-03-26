using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaypointsFree
{
    public class WaypointsGroup : MonoBehaviour
    {
        public PositionConstraint XYZConstraint = PositionConstraint.XYZ;
        [HideInInspector]
        public List<Waypoint> waypoints;   // The waypoint components controlled by this WaypointsGroupl IMMEDIATE children only

        private void Awake()
        {
            if(waypoints != null)
            {
                foreach (Waypoint wp in waypoints)
                    wp.SetWaypointGroup(this);
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// Returns a list of  Waypoints; resets the parent transform if reparent == true
        /// </summary>
        /// <returns></returns>
        public List<Waypoint> GetWaypointChildren(bool reparent = true)
        {
            if (waypoints == null)
                waypoints = new List<Waypoint>();

            if(reparent == true)
            { 
                foreach (Waypoint wp in waypoints)
                    wp.SetWaypointGroup(this);
             }


            return waypoints;
        }


        public void AddWaypoint(Waypoint wp, int ndx = -1)
        {
            if (waypoints == null) waypoints = new List<Waypoint>();
            if (ndx == -1)
                waypoints.Add(wp);
            else
                waypoints.Insert(ndx, wp);
            wp.SetWaypointGroup(this);
        }

    }
}