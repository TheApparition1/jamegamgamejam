using UnityEngine;

[CreateAssetMenu(fileName = "TimeSave", menuName = "Scriptable Objects/TimeSave")]
public class TimeSave : ScriptableObject
{
    public float[] levelTimes;
    public float totalTime;
    public float bestTime;
}
