using Movement;
using UnityEngine;

namespace FishingGear.FishingLine
{
	public sealed class FishingLine : MonoBehaviour
	{
		[SerializeField] private float verticalVelocity;

		private VerticalMovement _verticalMovement;

		private void Start() => _verticalMovement = new VerticalMovement(verticalVelocity, transform.position);

		private void Update() => transform.position = _verticalMovement.SmoothStep();
	}
}
