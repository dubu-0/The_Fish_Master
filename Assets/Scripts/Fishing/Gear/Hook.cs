using System.Collections.Generic;
using Fishing.Fishes;
using JetBrains.Annotations;
using Parameters.MoneyParameter;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Fishing.Gear
{
	[RequireComponent(typeof(Collider2D))]
	public class Hook : MonoBehaviour
	{
		[SerializeField] private Money _money;

		private readonly List<Fish> _caught = new List<Fish>();
		private Collider2D _hookCollider;

		private void Start()
		{
			_hookCollider = GetComponent<Collider2D>();
			DisableCollider();
		}

		private void OnTriggerEnter2D([NotNull] Collider2D other)
		{
			var fish = other.gameObject.GetComponent<Fish>();
			if (fish == null) return;

			Catch(fish, transform);
		}

		public int CaughtCount => _caught.Count;
		public void EnableCollider() => _hookCollider.enabled = true;
		public void DisableCollider() => _hookCollider.enabled = false;
		public void Release() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

		private void Catch([NotNull] Fish fish, Transform hook)
		{
			fish.SetNewParent(hook);
			fish.SetLocalPosition(new Vector3(3, 0, 0));
			fish.Stop();
			fish.IncreaseMoney(_money);
			_caught.Add(fish);
		}
	}
}
