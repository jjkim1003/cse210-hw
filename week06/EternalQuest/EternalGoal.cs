public class EternalGoal : Goal
{
    private int _timesRecorded;

    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        _timesRecorded = 0;
    }

    public override int RecordEvent()
    {
        _timesRecorded++;
        return _points;
    }

    public override bool IsComplete()
    {
        return false; // Eternal goals never truly complete
    }

    public int GetRecordCount()
    {
        return _timesRecorded; // Returns the number of times the event was recorded
    }

    public override string GetDetailString()
    {
        return $"{_shortName}: {_description} (Recorded {_timesRecorded} times)";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{_shortName}|{_description}|{_points}|{_timesRecorded}";
    }
}
