using UnityEngine;

namespace Fishes
{
	public interface IHookable : IStoppable
	{
		public void ChangeLocalPosition(Vector3 newPosition);
		public void ChangeParent(Transform newParent);
		public void Release();
	}
}
