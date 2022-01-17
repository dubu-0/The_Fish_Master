using UnityEngine;

namespace Parameters.GameParameters
{
    [CreateAssetMenu(menuName = "Create Strength", fileName = "Strength", order = 0)]
    public class StrengthParameter : GameParameterBase
    {
        public override float DefaultValue => 3f;
        protected override float DefaultCost => 200f;
    }
}