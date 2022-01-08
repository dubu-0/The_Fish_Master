using System.Collections.Generic;
using Fishes;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FishingGear.FishingLine
{
	public sealed class HookModel
	{
		private readonly List<IHookable> _caught;
		private readonly Collider2D _hookCollider2D;
		
		public HookModel(Collider2D hookCollider2D)
		{
			_hookCollider2D = hookCollider2D;
			_caught = new List<IHookable>();
			DisableCollider();
		}

		public int CaughtCount => _caught.Count;

		public void EnableCollider() => _hookCollider2D.enabled = true;
		public void DisableCollider() => _hookCollider2D.enabled = false;
		
		// TODO поменять, когда будет реализован переход между сценами
		public void Release() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

		public void Catch([NotNull] IHookable hookable, Transform container)
		{
			hookable.ChangeParent(container);
			hookable.ChangeLocalPosition(new Vector3(3, 0, 0));
			hookable.Stop();
			_caught.Add(hookable);
		}
	}
}
