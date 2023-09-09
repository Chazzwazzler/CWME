using UnityEngine;

namespace CWUtils
{	
	public static class ParticleSystemExtension
	{
		/// <summary>
		/// Enables/disables the emission of a particle system.
		/// </summary>
		public static void EnableEmission(this ParticleSystem particleSystem, bool enabled)
		{
			var emission = particleSystem.emission;
			emission.enabled = enabled;
		}

		/// <summary>
		/// Returns the emission rate of a particle system.
		/// </summary>
		public static float GetEmissionRate(this ParticleSystem particleSystem)
		{
			return particleSystem.emission.rateOverTime.constantMax;
		}

		/// <summary>
		/// Sets the emission rate of a particle system to a specific number.
		/// </summary>
		public static void SetEmissionRate(this ParticleSystem particleSystem, float emissionRate)
		{
			var emission = particleSystem.emission;
			var rate = emission.rateOverTime;
			rate.constantMax = emissionRate;
			emission.rateOverTime = rate;
		}
	}
}