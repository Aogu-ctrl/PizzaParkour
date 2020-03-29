using System.Collections;
using System.Collections.Generic;

public enum Level
{
    Overview,
    Staircase,
    ParkingLot,
    DarkRoom,
    Pipe
}

[System.Serializable]
public class SaveData
{
    private static SaveData _current;
    public static SaveData current
    {
        get
        {
            if (_current == null)
            {
                _current = new SaveData();
            }
            return _current;
        }

        set
        {
            _current = value;
        }
    }

    public Dictionary<Level, bool> isLevelCompleted = new Dictionary<Level, bool>();

    public SaveData()
    {
        isLevelCompleted = new Dictionary<Level, bool>();
        isLevelCompleted.Add(Level.Staircase, false);
        isLevelCompleted.Add(Level.ParkingLot, false);
        isLevelCompleted.Add(Level.DarkRoom, false);
        isLevelCompleted.Add(Level.Pipe, false);
    }
}
