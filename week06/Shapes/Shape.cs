using System;

public class Shape
{
    private string _color;

    public Shape(string color)
    {
        _color = color;
    }

    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string color)
    {
        _color = color;
    }

    // Virtual: child classes are allowed to override this method.
    public virtual double GetArea()
    {
        return 0;
    }
}
