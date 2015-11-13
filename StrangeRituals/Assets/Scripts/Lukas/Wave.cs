using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour
{
    public int Amount;
    public float Delay;
    [Tooltip("When set to 0 it Will never Spawn this Wave Again, otherwise it will spawn the CurrentWave again when the previous wave is completed and the RepeatCurrentWaveAfter is over, till the CurrentWave Changes")]
    [Range(0, 100)]
    public float RepeatWaveAfter = 0;

    [HideInInspector]
    public int SpawnCounter;
}