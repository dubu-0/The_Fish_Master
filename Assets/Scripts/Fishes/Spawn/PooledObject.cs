using UnityEngine;
using UnityEngine.Events;

namespace Fishes.Spawn
{
	public abstract class PooledObject : MonoBehaviour
	{
		[SerializeField] private UnityEvent onBecameInactive;

		protected virtual void OnDisable() => onBecameInactive.Invoke();
	}
}
