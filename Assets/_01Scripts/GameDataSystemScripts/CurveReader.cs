using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataSystem
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "CurveReader", menuName = "ScriptableObjects/CurveReader")]
    public class CurveReader : ScriptableObject
    {
        public IntValue level;
        public bool useIntCurve;

        public UpgradeProgressionCurveInt upgradeCurveInt;
        public UpgradeProgressionCurveFloat upgradeCurveFloat;

        public int GetMyLevel()
        {
            return level.MyValue;
        }
        public int GetMyValueInt()
        {
            return upgradeCurveInt.GetValueAtLevel(level.Value);
        }
        public float GetMyValueFloat()
        {
            return upgradeCurveFloat.GetValueAtLevel(level.Value);
        }

        public int GetMyValueCustomInt(int customLvel)
        {
            return upgradeCurveInt.GetValueAtLevel(customLvel);
        }
        public float GetMyValueCustomFloat(int customLevel)
        {
            return upgradeCurveFloat.GetValueAtLevel(customLevel);
        }
    }

}