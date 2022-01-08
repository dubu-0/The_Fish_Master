using Fishes;
using JetBrains.Annotations;
using UnityEngine;

namespace FishingGear.FishingLine
{
	[RequireComponent(typeof(CircleCollider2D))]
	public sealed class Hook : MonoBehaviour
	{
		private HookModel _model;

		private void Start() => _model = new HookModel(gameObject.GetComponent<CircleCollider2D>());

		private void OnTriggerEnter2D([NotNull] Collider2D col)
		{
			var hookable = col.gameObject.GetComponent<IHookable>();
			if (hookable == null) return;

			GetModel().Catch(hookable, transform);
		}

		public HookModel GetModel() => _model;
	}
}
