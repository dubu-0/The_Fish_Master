using UnityEngine;

public sealed class FishingRod : MonoBehaviour
{
	private HorizontalMovementByMouse _horizontalMovementByMouse;

	private void Start() => _horizontalMovementByMouse = new HorizontalMovementByMouse(transform.position, Camera.main);

	private void Update()
	{
		if (Input.GetMouseButton(0))
			transform.position = _horizontalMovementByMouse.UpdateHorizontalPosition();
	}
}
