namespace FigureLib
{
    public interface IFigure
    {
        double Area { get; }
        string Color { get; set; }
        double this[string option] { get; }
        void Offset(double offsetX, double offsetY);
        string ToString();
    }
}
