namespace Coursework_kskr
{
    class Node
    {
        // Координата узла по оси OX.
        public float X { get; set; }
        // Координата узла по оси OY.
        public float Y { get; set; }
        // Глобальный номер узла.
        public int Index { get; set; }
        // Переменная, определяющая закреплен ли узел.
        public bool Fixation { get; set; }

        public Node() { }

        public Node(int Index, float X, float Y, bool Fixation)
        {
            this.Index = Index - 1;
            this.X = X;
            this.Y = Y;
            this.Fixation = Fixation;
        }

    }
}