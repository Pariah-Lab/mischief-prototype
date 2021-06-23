using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DataSystem
{
    [System.Serializable]
    public class IntReferenceValue
    {
        public bool UseConstant = true;
        public int ConstantValue;
        public IntValue Variable;

        public int Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
            set
            {
                if (UseConstant)
                {
                    ConstantValue = value;
                }
                else
                {
                    Variable.MyValue = value;
                }

            }
        }



    } 
}
