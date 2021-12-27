using System.Collections;
using System.Collections.Generic;
using Core;
using Fishes;
using JetBrains.Annotations;
using UnityEngine;

namespace FishingGear.FishingLine
{
    [RequireComponent(typeof(CircleCollider2D))]
    public sealed class Hook : MonoBehaviour
    {
        private CircleCollider2D _circleCollider2D;
        private GameParameters _gameParameters;
        private List<Fish> _caughtFishes = new List<Fish>();

        public IEnumerable<Fish> CaughtFishes => _caughtFishes;
        
        private void Start()
        {
            _circleCollider2D = GetComponent<CircleCollider2D>();
            _gameParameters = new GameParameters();
            StopHooking();
        }

        private void OnTriggerEnter2D([NotNull] Collider2D col)
        {
            var fish = col.gameObject.GetComponent<Fish>();
            if (!fish) return;
        
            CatchFish(fish);
        }

        public void StartHooking() => _circleCollider2D.enabled = true;

        public void StopHooking() => _circleCollider2D.enabled = false;

        public void ReleaseFishes()
        {
            _caughtFishes.ForEach(fish => fish.ReturnToPool());
            _caughtFishes.Clear();
        }
        
        private void CatchFish([NotNull] Fish fish)
        {
            fish.gameObject.transform.parent = transform;
            fish.transform.localPosition = new Vector3(3, 0, 0);
            fish.Stop();
            _caughtFishes.Add(fish);

            if (_caughtFishes.Count >= _gameParameters.Strength)
                StopHooking();
        }
    }
}
