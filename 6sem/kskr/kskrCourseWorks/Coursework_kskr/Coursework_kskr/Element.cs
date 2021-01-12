using System;
using System.Drawing;

namespace Coursework_kskr
{
    class Element
    {
        // Первый узел конечного элемента.
        public Node Node1 { get; set; }
        // Второй узел конечного элемента.
        public Node Node2 { get; set; }
        // Третий узел конечного элемента.
        public Node Node3 { get; set; }
        // Цвет элемента для отрисовки.
        public SolidBrush ColorElement { get; set; }
        // Глобальный номер элемента.
        public int Index { get; set; }
        // Координатная матрица.
        public float[,] A { get; set; }
        // Обратная координатная матрица.
        public float[,] A_1 { get; set; }
        public float[,] Q { get; set; }
        // Локальная матрица жесткости.
        public float[,] K { get; set; }
        public float[,] B { get; set; }
        // Матрица упругости.
        public float[,] D { get; set; }
        // Смещение узлов элемента.
        public float[,] Sig { get; set; }
        public float[,] E { get; set; }
        public float[,] Stress { get; set; }
        // Напряжение элемента.
        public float S { get; set; }

        public Element() { }

        public Element(int Index, Node Node1, Node Node2, Node Node3)
        {
            this.Index = Index;
            this.Node1 = Node1;
            this.Node2 = Node2;
            this.Node3 = Node3;            
            Sig = new float[6, 1];
        }

        public void CreateMatrix(float t, float elasticModulus, float poissonsRatio)
        {
            CreateA();
            CreateQ();
            CreateD(elasticModulus, poissonsRatio);
            CreateB();
            CreateK(t);
        }

        void CreateA()
        {
            A = new float[6, 6];
            A_1 = new float[6, 6];

            A[0, 0] = 1;
            A[0, 1] = Node1.X;
            A[0, 2] = Node1.Y;

            A[1, 3] = 1;
            A[1, 4] = Node1.X;
            A[1, 5] = Node1.Y;

            A[2, 0] = 1;
            A[2, 1] = Node2.X;
            A[2, 2] = Node2.Y;

            A[3, 3] = 1;
            A[3, 4] = Node2.X;
            A[3, 5] = Node2.Y;

            A[4, 0] = 1;
            A[4, 1] = Node3.X;
            A[4, 2] = Node3.Y;

            A[5, 3] = 1;
            A[5, 4] = Node3.X;
            A[5, 5] = Node3.Y;

            A_1 = Matrix.FindingTheInverseMatrix(A);
        }

        void CreateQ()
        {
            Q = new float[3, 6];
            Q[0, 1] = 1;
            Q[1, 5] = 1;
            Q[2, 2] = 1;
            Q[2, 4] = 1;
        }

        void CreateD(float elasticModulus, float poissonsRatio)
        {
            D = new float[3, 3];
            float koeff = elasticModulus / (1 - poissonsRatio * poissonsRatio);
            D[0, 0] = 1;
            D[0, 1] = poissonsRatio;
            D[0, 2] = 0;
            D[1, 0] = poissonsRatio;
            D[1, 1] = 1;
            D[1, 2] = 0;
            D[2, 0] = 0;
            D[2, 1] = 0;
            D[2, 2] = (1 - poissonsRatio) / 2;
            D = Matrix.MultiplicationMatrixAndNumber(D, koeff);
        }

        void CreateB()
        {
            B = new float[3, 6];
            B = Matrix.Multiplication(Q, A_1);
        }

        void CreateK(float t)
        {
            K = new float[6, 6];
            float[,] transpB = Matrix.Transpose(B);
            K = Matrix.Multiplication(transpB, D);
            K = Matrix.Multiplication(K, B);
            K = Matrix.MultiplicationMatrixAndNumber(K, t);
            float ds = triangleArea(Node1.X, Node1.Y, Node2.X, Node2.Y, Node3.X, Node3.Y);
            K = Matrix.MultiplicationMatrixAndNumber(K, ds);
        }

        public void SolveStress()
        {
            float[,] bb = Matrix.Multiplication(Q, A_1);
            E = Matrix.Multiplication(bb, Sig);
            Stress = Matrix.Multiplication(D, E);
            S = (float)Math.Sqrt(Math.Pow(Stress[0, 0], 2) + Math.Pow(Stress[1, 0], 2) - Stress[0, 0] * Stress[1, 0] + 3 * (Math.Pow(Stress[2, 0], 2)));
        }

        float triangleArea(float x1, float y1, float x2, float y2, float x3, float y3)
        {
            float a, b, c, p;
            c = (float)Math.Sqrt(Math.Pow(y1 - y2, 2) + Math.Pow(x1 - x2, 2));
            a = (float)Math.Sqrt(Math.Pow(y2 - y3, 2) + Math.Pow(x2 - x3, 2));
            b = (float)Math.Sqrt(Math.Pow(y1 - y3, 2) + Math.Pow(x1 - x3, 2));

            p = (a + b + c) / 2;
            return ((float)Math.Sqrt(p * (p - a) * (p - b) * (p - c)));
        }

    }
}


