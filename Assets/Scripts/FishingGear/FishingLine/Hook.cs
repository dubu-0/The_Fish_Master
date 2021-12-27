using Fishes;
using JetBrains.Annotations;
using UnityEngine;

namespace FishingGear.FishingLine
{
    [RequireComponent(typeof(CircleCollider2D))]
    public sealed class Hook : MonoBehaviour
    {
        private CircleCollider2D _circleCollider2D;
        private int _initialStrength;
    
        [field: SerializeField] public int Strength { get; private set; }

        private void Start()
        {
            _circleCollider2D = GetComponent<CircleCollider2D>();
            _initialStrength = Strength;
            StopHooking();
        }

        private void OnTriggerEnter2D([NotNull] Collider2D col)
        {
            var fish = col.gameObject.GetComponent<Fish>();
            if (!fish) return;
        
            CatchFish(fish);
            if (Strength <= 0) StopHooking();
        }

        public void StartHooking()
        {
            _circleCollider2D.enabled = true;
            Strength = _initialStrength;
        }

        public void StopHooking() => _circleCollider2D.enabled = false;

        private void CatchFish([NotNull] Fish fish)
        {
            fish.gameObject.transform.parent = transform;
            fish.transform.localPosition = new Vector3(3, 0, 0);
            fish.Stop();
            Strength--;
        }
    }
}
