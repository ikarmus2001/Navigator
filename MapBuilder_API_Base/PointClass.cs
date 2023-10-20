namespace MapBuilder_API_Base;

public class PointClass
{
    public double X { get; set; }
    public double Y { get; set; }

    public PointClass()
    {
        X = 0;
        Y = 0;
    }

    public PointClass(double x, double y)
    {
        X = x;
        Y = y;
    }
}