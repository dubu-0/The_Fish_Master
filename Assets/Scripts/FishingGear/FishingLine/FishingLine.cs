using UnityEngine;

namespace FishingGear.FishingLine
{
	public sealed class FishingLine : MonoBehaviour
	{
		public Vector3 StartingPosition { get; private set; }

		private void Start() => StartingPosition = transform.position;
	}
}
