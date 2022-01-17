using UnityEngine;

namespace Parameters.GameParameters
{
    [CreateAssetMenu(menuName = "Create Length", fileName = "Length", order = 0)]
    public class LengthParameter : GameParameterBase
    {
        public override float DefaultValue => 30f;
        protected override float DefaultCost => 100f;
    }
}