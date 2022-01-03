using System.Collections.Generic;
using Fishes;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FishingGear.FishingLine
{
	[RequireComponent(typeof(CircleCollider2D))]
	public sealed class Hook : MonoBehaviour
	{
		private readonly List<IHookable> _caught = new List<IHookable>();
		private CircleCollider2D _circleCollider2D;

		public IEnumerable<IHookable> Caught => _caught;

		private void Start()
		{
			_circleCollider2D = GetComponent<CircleCollider2D>();
			DisableCollider();
		}

		private void OnTriggerEnter2D([NotNull] Collider2D col)
		{
			var hookable = col.gameObject.GetComponent<IHookable>();
			if (hookable == null) return;

			Catch(hookable);
		}

		public void EnableCollider() => _circleCollider2D.enabled = true;
		public void DisableCollider() => _circleCollider2D.enabled = false;

		public void Release() => SceneManager.LoadScene
			(SceneManager.GetActiveScene().name); // TODO поменять, когда будет реализован переход между сценами

		private void Catch([NotNull] IHookable hookable)
		{
			hookable.ChangeParent(transform);
			hookable.ChangeLocalPosition(new Vector3(3, 0, 0));
			hookable.Stop();
			_caught.Add(hookable);
		}
	}
}
