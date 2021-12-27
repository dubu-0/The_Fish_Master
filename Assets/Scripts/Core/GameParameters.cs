namespace Core
{
	public sealed class GameParameters
	{
		private const int DefaultStrength = 3;
		private const int DefaultLength = 100;
		
		private static int _strength = DefaultStrength;
		private static int _length = DefaultLength;

		public int Strength => _strength;
		public int Length => _length;
		
		public void IncreaseStrength() => _strength++;
		public void IncreaseLength() => _length += 10;
	}
}
