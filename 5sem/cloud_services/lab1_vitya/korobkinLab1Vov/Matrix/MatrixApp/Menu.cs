using System;
using System.Collections.Generic;
using System.Text;
using MatrixLib;

namespace MatrixApp
{
    public class Menu
    {
        public static void GetMenu()
        {
            IMatrixParser matrixParser = new MatrixParser();
            while (true)
            {
                Console.WriteLine("Menu\n" +
                                  "Press number of menu item\n" +
                                  "1 - Scalar matrix multiplication\n" +
                                  "2 - Vector matrix multiplication\n" +
                                  "3 - Exit");
                if (int.TryParse(Console.ReadLine(), out int menuItemNumber))
                {
                    IMatrix matrix1;
                    IMatrix matrix2;
                    IMatrix resultMatrix;
                    switch (menuItemNumber)
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Matrix must be like this\n" +
                                              "2  6  -9,4;  4  8  19,9; -11,7  9  2");
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.WriteLine("Enter the first matrix");
                            try
                            {
                                matrix1 = matrixParser.Parse(Console.ReadLine());
                            }
                            catch (Exception exception)
                            {
                                Console.WriteLine(exception.Message);
                                break;
                            }

                            Console.WriteLine("Enter the second matrix");
                            try
                            {
                                matrix2 = matrixParser.Parse(Console.ReadLine());
                            }
                            catch (Exception exception)
                            {
                                Console.WriteLine(exception.Message);
                                break;
                            }

                            resultMatrix = matrix1.Dot(matrix2);
                            Console.WriteLine("Result matrix is\n");
                            Console.WriteLine(resultMatrix);
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Matrix must be like this\n" +
                                              "2  6  -9,4;  4  8  19,9; -11,7  9  2");
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.WriteLine("Enter the first matrix");
                            try
                            {
                                matrix1 = matrixParser.Parse(Console.ReadLine());
                            }
                            catch (Exception exception)
                            {
                                Console.WriteLine(exception.Message);
                                break;
                            }

                            Console.WriteLine("Enter the second matrix");
                            try
                            {
                                matrix2 = matrixParser.Parse(Console.ReadLine());
                            }
                            catch (Exception exception)
                            {
                                Console.WriteLine(exception.Message);
                                break;
                            }

                            resultMatrix = matrix1.Mul(matrix2);
                            Console.WriteLine("Result matrix is");
                            Console.WriteLine(resultMatrix);
                            break;
                        case 3:
                            return;
                        default:
                            Console.WriteLine("Incorrect input");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                }
            }
        }
    }
}
