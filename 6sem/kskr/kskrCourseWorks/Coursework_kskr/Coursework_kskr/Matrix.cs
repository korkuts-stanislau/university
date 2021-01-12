using System.Collections.Generic;

namespace Coursework_kskr
{
    class Matrix
    {
        /// <summary>
        /// Нахождение произведений матриц.
        /// </summary>
        /// <param name="matrix1">матрица</param>
        /// <param name="matrix2">матрица</param>
        /// <returns>произведение</returns>
        static public float[,] Multiplication(float[,] matrix1, float[,] matrix2)
        {
            float[,] c = new float[matrix1.GetLength(0), matrix2.GetLength(1)];
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix2.GetLength(0); k++)
                    {
                        c[i, j] = c[i, j] + matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            return (c);
        }

        /// <summary>
        /// Транспонирование матрицы.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns>транспонированная матрица</returns>
        static public float[,] Transpose(float[,] matrix)
        {
            float[,] b = new float[matrix.GetLength(1), matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    b[j, i] = matrix[i, j];
            return (b);
        }

        /// <summary>
        /// Нахождение произведения матрицы на число.
        /// </summary>
        /// <param name="matrix">матрица</param>
        /// <param name="num">число</param>
        /// <returns>рооизведение матрицы на число</returns>
        static public float[,] MultiplicationMatrixAndNumber(float[,] matrix, float num)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = matrix[i, j] * num;
            return (matrix);
        }

        /// <summary>
        /// Нахождение обратной матрицы с помощью метода Гаусса.
        /// </summary>
        /// <param name="matrix">матрица</param>
        /// <returns>обратная матрица</returns>
        static public float[,] FindingTheInverseMatrix(float[,] matrix)
        {
            float[,] A1 = new float[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < 6; i++)
                A1[i, i] = 1;

            float variable;

            for (int i = 0; i < 6; i++)
            {
                if (matrix[i, i] == 0)
                {
                    int index = i + 1;
                    while (index < 6)
                    {
                        if (matrix[index, i] != 0)
                            break;
                        index++;
                    }

                    if (index != 6)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            matrix[i, j] = matrix[i, j] + matrix[index, j];
                            matrix[index, j] = matrix[i, j] - matrix[index, j];
                            matrix[i, j] = matrix[i, j] - matrix[index, j];
                            A1[i, j] = A1[i, j] + A1[index, j];
                            A1[index, j] = A1[i, j] - A1[index, j];
                            A1[i, j] = A1[i, j] - A1[index, j];
                        }
                    }
                }

                variable = matrix[i, i];
                for (int j = 0; j < 6; j++)
                {
                    matrix[i, j] = matrix[i, j] / variable;
                    A1[i, j] = A1[i, j] / variable;
                }

                for (int j = 0; j < 6; j++)
                {
                    if (j != i)
                    {
                        variable = matrix[j, i];
                        if (variable != 0)
                            for (int k = 0; k < 6; k++)
                            {
                                matrix[j, k] = matrix[j, k] - variable * matrix[i, k];
                                A1[j, k] = A1[j, k] - variable * A1[i, k];
                            }
                    }
                }
            }
            return (A1);
        }

        /// <summary>
        /// Решение СЛАУ методом Гаусса.
        /// </summary>
        /// <param name="nodes">узлы</param>
        /// <param name="globalMatrix">глобальная матрица</param>
        /// <returns>решение СЛАУ</returns>
        static public float[,] Gaus(List<Node> nodes, float[,] globalMatrix)
        {
            float variable;
            for (int i = 0; i < nodes.Count * 2; i++)
            {
                if (globalMatrix[i, i] == 0)
                {
                    int index = i + 1;
                    while (index < nodes.Count * 2)
                    {
                        if (globalMatrix[index, i] != 0)
                            break;
                        index++;
                    }

                    if (index != nodes.Count * 2)
                    {
                        for (int j = i; j < nodes.Count * 2 + 1; j++)
                        {
                            globalMatrix[i, j] = globalMatrix[i, j] + globalMatrix[index, j];
                            globalMatrix[index, j] = globalMatrix[i, j] - globalMatrix[index, j];
                            globalMatrix[i, j] = globalMatrix[i, j] - globalMatrix[index, j];
                        }
                    }
                }

                variable = globalMatrix[i, i];
                for (int j = nodes.Count * 2; j >= i; j--)
                {
                    globalMatrix[i, j] = globalMatrix[i, j] / variable;
                }
                for (int j = i + 1; j < nodes.Count * 2; j++)
                {
                    variable = globalMatrix[j, i];
                    if (variable != 0)
                        for (int k = nodes.Count * 2; k >= i; k--)
                            globalMatrix[j, k] = globalMatrix[j, k] - variable * globalMatrix[i, k];
                }

            }

            for (int i = nodes.Count * 2 - 1; i > 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    globalMatrix[j, nodes.Count * 2] -= globalMatrix[j, i] * globalMatrix[i, nodes.Count * 2];
                    globalMatrix[j, i] = 0;
                }
            }

            return (globalMatrix);
        }
    }
}


