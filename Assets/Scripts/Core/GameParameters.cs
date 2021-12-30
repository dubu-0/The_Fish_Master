using JetBrains.Annotations;
using UnityEngine;

namespace Core
{
	[CreateAssetMenu(menuName = "Create GameParameters", fileName = "GameParameters", order = 0)]
	public sealed class GameParameters : ScriptableObject
	{
		private const int DefaultStrength = 3;
		private const int DefaultLength = 100;

		[field: SerializeField] public int Strength { get; [UsedImplicitly] private set; } = DefaultStrength;
		[field: SerializeField] public int Length { get; [UsedImplicitly] private set; } = DefaultLength;
	}
}
