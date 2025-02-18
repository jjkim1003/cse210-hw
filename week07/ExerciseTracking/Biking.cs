public class Biking : Activity
{
    private double _speed;

    public Biking(string date, double minutes, double speed) 
        : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return (_speed * GetMinutes()) / 60; // Distance = Speed × Time
    }

    public override double GetSpeed()
    {
        return _speed; // Speed is given directly
    }

    public override double GetPace()
    {
        return 60 / _speed; // Pace is inverse of speed
    }
}
