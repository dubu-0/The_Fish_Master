using Movement;
using UnityEngine;

namespace FishingGear.FishingLine
{
	public sealed class FishingLine : MonoBehaviour
	{
		[SerializeField] [Range(1f, 15f)] private float speed;

		public VerticalMovement VerticalMovement { get; private set; }

		private void Start() => VerticalMovement = new VerticalMovement(speed);
	}
}
