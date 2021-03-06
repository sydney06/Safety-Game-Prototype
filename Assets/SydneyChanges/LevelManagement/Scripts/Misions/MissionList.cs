using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement.Missions
{
    [CreateAssetMenu(fileName = "Missions", menuName = "Missions/Create Mission", order = 1)]
    public class MissionList : ScriptableObject
    {
        #region INSPECTOR
        [SerializeField] private List<MissionSpecs> _missions;
        #endregion

        #region PROPERTIES
        public int TotalMissions => _missions.Count;
        #endregion

        public MissionSpecs GetMission(int index)
        {
            return _missions[index];
        }


    } 
}
