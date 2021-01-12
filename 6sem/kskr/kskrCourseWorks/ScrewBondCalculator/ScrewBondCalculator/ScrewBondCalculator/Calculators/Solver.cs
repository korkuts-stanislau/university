using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScrewBondCalculator.DataTypes;
using System.Windows;
using System.IO;

namespace ScrewBondCalculator.Calculators
{
    class Solver
    {
        int coliNodsCount, coilElementsCount;
        int coilCount, borderNodsCount=0;
        double[,] globalMatrix;
        double[,] matrixE;
        double[] forceVector;
        double allowebleTension;
        double coilLength;

        public double Thikness
        {
            get;
            set;
        }
        public double Puasson
        {
            get; 
            set;
        }

        public double[,] GlobalMatrix
        {
            get { return globalMatrix; }
            set { globalMatrix = value; }
        }
        public double[] ForceVector
        {
            get { return forceVector; }
            set { forceVector = value; }
        }
        public List<Element> Elements
        {
            get;
            set;
        }
        public List<Nod> Nods
        {
            get;
            set;
        }
        public double[] NodesDisplacement
        {
            get;
            private set;
        }

        void RemoveOveredStringsAndColumInGlobal(int la)
        {
            double[,] newGlobalMatrix = new double[globalMatrix.GetLength(0) - 1, globalMatrix.GetLength(1) - 1];
            double[] newForceVector = new double[forceVector.Length - 1];
            int inn = 0;
            int jnn = 0;

            for (int i = 0; i < globalMatrix.GetLength(0); i++)
            {

                if (i != la)
                {
                    for (int j = 0; j < globalMatrix.GetLength(1); j++)
                    {


                        if (j != la)
                        {
                            newGlobalMatrix[inn, jnn] = globalMatrix[i, j];
                            jnn++;
                        }
                    }
                    newForceVector[inn] = forceVector[i];

                    inn++;
                }
                jnn = 0;
            }

            forceVector = new double[newForceVector.Length];
            forceVector = newForceVector;

            globalMatrix = new double[newGlobalMatrix.GetLength(0), newGlobalMatrix.GetLength(1)];
            globalMatrix = newGlobalMatrix;
        }
        void InsertLocalToGlobal(LocalRigidityMatrix local)
        {
            for (int i = 0; i < local.matrix.GetLength(0); i++)
                for (int j = 0; j < local.matrix.GetLength(1); j++)
                    globalMatrix[local.location[i] - 1, local.location[j] - 1] += local.matrix[i, j];
        }
        bool CalculateTensions() 
        {
            globalMatrix = new double[Nods.Count * 2, Nods.Count * 2];
            NodesDisplacement = new double[Nods.Count * 2];
            ForceVector = new double[Nods.Count * 2];
            for (int i = 0; i < Nods.Count; i++)
            {
                ForceVector[(Nods[i].Number * 2 - 2)] = Nods[i].XLoad;
                ForceVector[(Nods[i].Number * 2 - 1)] = Nods[i].YLoad;
            }
            LocalRigidityMatrix lrm;
            foreach (Element localElement in Elements)
            {
                
                double[,] matrixB = {
                                        { localElement.Nod2.Y - localElement.Nod3.Y, 0,localElement.Nod3.Y - localElement.Nod1.Y,0 ,localElement.Nod1.Y - localElement.Nod2.Y ,0 },
                                        { 0, localElement.Nod3.X - localElement.Nod2.X,0 ,localElement.Nod1.X - localElement.Nod3.X ,0 ,localElement.Nod2.X - localElement.Nod1.X },
                                        { localElement.Nod3.X - localElement.Nod2.X,localElement.Nod2.Y - localElement.Nod3.Y ,localElement.Nod1.X - localElement.Nod3.X ,localElement.Nod3.Y - localElement.Nod1.Y ,localElement.Nod2.X - localElement.Nod1.X ,localElement.Nod1.Y - localElement.Nod2.Y }
                                    };
                matrixB = MatrixAction.MultipleMatConst(matrixB, 1/(2*localElement.Squre));
                lrm = new LocalRigidityMatrix(MatrixAction.MultipleMatConst((MatrixAction.MultipleMatMat(MatrixAction.MultipleMatMat(MatrixAction.TransponMat(matrixB), matrixE), matrixB)), (Thikness * localElement.Squre)), localElement.Nod1.Number, localElement.Nod2.Number, localElement.Nod3.Number);
                InsertLocalToGlobal(lrm);
            }
            {
                foreach(Nod localNod in Nods)
                {
                    if (localNod.IsConstraedByX)
                    {
                        RemoveOveredStringsAndColumInGlobal((localNod.Number * 2 - 2));
                    }

                    if (localNod.IsConstraedByY)
                    {
                        RemoveOveredStringsAndColumInGlobal((localNod.Number * 2 - 1));
                    }
                }
            }
            NodesDisplacement = new Gauss(globalMatrix, ForceVector).XVector;
            {
                Nod localNod;
                int curNodNumber;
                for (int i = 1; i < NodesDisplacement.Length; i += 2)
                {
                    curNodNumber = i/2 + 1;
                    localNod = Nods.Where(n => n.Number == curNodNumber).ToArray()[0];
                    localNod.XDisplacement = NodesDisplacement[i - 1];
                    localNod.YDisplacement = NodesDisplacement[i];
                }
            }
            {
                double[] u = new double[6];
                double[] tenComp;
                foreach (Element localElement in Elements)
                {
                    double[,] matrixB = {
                                            { localElement.Nod2.Y - localElement.Nod3.Y, 0,localElement.Nod3.Y - localElement.Nod1.Y,0 ,localElement.Nod1.Y - localElement.Nod2.Y ,0 },
                                            { 0, localElement.Nod3.X - localElement.Nod2.X,0 ,localElement.Nod1.X - localElement.Nod3.X ,0 ,localElement.Nod2.X - localElement.Nod1.X },
                                            { localElement.Nod3.X - localElement.Nod2.X, localElement.Nod2.Y - localElement.Nod3.Y ,localElement.Nod1.X - localElement.Nod3.X ,localElement.Nod3.Y - localElement.Nod1.Y ,localElement.Nod2.X - localElement.Nod1.X ,localElement.Nod1.Y - localElement.Nod2.Y }
                                        };
                    matrixB = MatrixAction.MultipleMatConst(matrixB, 1 / (2 * localElement.Squre));
                    u[0] = localElement.Nod1.XDisplacement;
                    u[1] = localElement.Nod1.YDisplacement;
                    u[2] = localElement.Nod2.XDisplacement;
                    u[3] = localElement.Nod2.YDisplacement;
                    u[4] = localElement.Nod3.XDisplacement;
                    u[5] = localElement.Nod3.YDisplacement;
                    tenComp = MatrixAction.MultipleMatVec(MatrixAction.MultipleMatMat(matrixE, matrixB), u);
                    localElement.Tension = (1.0 / Math.Sqrt(2)) * Math.Sqrt(Math.Pow(tenComp[0] - tenComp[1], 2) + Math.Pow(tenComp[0], 2) + Math.Pow(tenComp[1], 2) + 6 * tenComp[2]);
                    if (localElement.Tension > allowebleTension)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        void GrowCoil()
        {
            List<Nod> borderNods = new List<Nod>();
            List<Nod> potentialBorderNods;

            Nod newCoilNod, newElementNod1, newElementNod2, newElementNod3;
            int oldNodsCount = Nods.Count, oldElementsCount = Elements.Count;
            for (int i = oldNodsCount - coliNodsCount, newNodCounter=1; i < oldNodsCount; i++)
            {
                potentialBorderNods = Nods.Where(n => n.X == (Nods[i].X + coilLength) && n.Y == Nods[i].Y).ToList();
                if (potentialBorderNods.Count == 0)
                {
                    newCoilNod = new Nod(oldNodsCount + newNodCounter, Nods[i].X + coilLength, Nods[i].Y, 0, 0);
                    newCoilNod.IsConstraedByY = Nods[i].IsConstraedByY;
                    newCoilNod.IsConstraedByX = Nods[i].IsConstraedByX;
                    Nods[i].IsConstraedByX = false;
                    Nods.Add(newCoilNod);
                    newNodCounter++;
                }
                else
                {
                    borderNodsCount++;
                }
            }

            for (int i = oldElementsCount  - coilElementsCount; i < oldElementsCount; i++)
            {
                newElementNod1 = Nods.Where(n => n.Number == coliNodsCount - borderNodsCount + Elements[i].Nod1.Number).ToArray()[0];
                newElementNod2 = Nods.Where(n => n.Number == coliNodsCount - borderNodsCount + Elements[i].Nod2.Number).ToArray()[0];
                newElementNod3 = Nods.Where(n => n.Number == coliNodsCount - borderNodsCount + Elements[i].Nod3.Number).ToArray()[0];
                Elements.Add(new Element(newElementNod1, newElementNod2, newElementNod3));
            } 
            coilCount++;
        }

        void OldGrowCoilV1()
        {
            Nod newCoilNod, newElementNod1, newElementNod2, newElementNod3;
            int oldNodsCount = Nods.Count, oldElementsCount = Elements.Count;
            for (int i = coliNodsCount * (coilCount - 1); i < oldNodsCount; i++)
            {
                newCoilNod = new Nod(oldNodsCount + i + 1, Nods[i].X + coilLength, Nods[i].Y, 0, 0);
                newCoilNod.IsConstraedByY = Nods[i].IsConstraedByY;
                newCoilNod.IsConstraedByX = Nods[i].IsConstraedByX;
                Nods[i].IsConstraedByX = false;
                Nods.Add(newCoilNod);
            }

            for (int i = coilElementsCount * (coilCount - 1); i < oldElementsCount; i++)
            {
                newElementNod1 = Nods.Where(n => n.Number == coliNodsCount + Elements[i].Nod1.Number).ToArray()[0];
                newElementNod2 = Nods.Where(n => n.Number == coliNodsCount + Elements[i].Nod2.Number).ToArray()[0];
                newElementNod3 = Nods.Where(n => n.Number == coliNodsCount + Elements[i].Nod3.Number).ToArray()[0];
                Elements.Add(new Element(newElementNod1, newElementNod2, newElementNod3));
            }
            coilCount++;
        }
        void OldGrowCoilV2()
        {
            Nod newCoilNod, newElementNod1, newElementNod2, newElementNod3;
            int oldNodsCount = Nods.Count, oldElementsCount = Elements.Count;
            for (int i = oldNodsCount - coliNodsCount, newNodCounter = 1; i < oldNodsCount; i++)
            {
                newCoilNod = new Nod(oldNodsCount + newNodCounter, Nods[i].X + coilLength, Nods[i].Y, 0, 0);
                newCoilNod.IsConstraedByY = Nods[i].IsConstraedByY;
                newCoilNod.IsConstraedByX = Nods[i].IsConstraedByX;
                Nods[i].IsConstraedByX = false;
                Nods.Add(newCoilNod);
                newNodCounter++;
            }

            for (int i = oldElementsCount - coilElementsCount; i < oldElementsCount; i++)
            {
                newElementNod1 = Nods.Where(n => n.Number == coliNodsCount + Elements[i].Nod1.Number).ToArray()[0];
                newElementNod2 = Nods.Where(n => n.Number == coliNodsCount + Elements[i].Nod2.Number).ToArray()[0];
                newElementNod3 = Nods.Where(n => n.Number == coliNodsCount + Elements[i].Nod3.Number).ToArray()[0];
                Elements.Add(new Element(newElementNod1, newElementNod2, newElementNod3));
            }
            coilCount++;
        }

        public int Solve()
        {
            int alphaCounter = 0;
            while (CalculateTensions() == false)
            {
                OldGrowCoilV2();

                if (alphaCounter == 0)
                    break;
                alphaCounter++;
            }
            return coilCount;
        }
        public Solver(double brassPuasson, double thikness, double allowebleTension, List<Element> elements, List<Nod> nods)
        {
            double bottomPoint = nods[0].Y;
            double startCoilPoint = nods[0].X, finalCoilPoint = nods[0].X;

            Thikness = thikness;
            Puasson = brassPuasson;
            matrixE = new double[,] { { 1, Puasson, 0 }, { Puasson, 1, 0 }, { 0, 0, (1 - Puasson) / 2 } };
            matrixE = MatrixAction.MultipleMatConst(matrixE, 2*Math.Pow(10, 4)/Math.Pow((1 - Puasson), 2));
            Elements = elements;
            Nods = nods;
            this.allowebleTension = allowebleTension;

            foreach (Nod nod in nods)
            {
                if (nod.Y > bottomPoint)
                {
                    bottomPoint = nod.Y;
                }
            }

            foreach (Nod nod in nods)
            {
                if (nod.Y == bottomPoint && nod.X > finalCoilPoint)
                {
                    finalCoilPoint = nod.X;
                }
                if (nod.Y == bottomPoint && nod.X < startCoilPoint)
                {
                    startCoilPoint = nod.X;
                }
            }
            coilLength = Math.Abs(finalCoilPoint - startCoilPoint);
            coliNodsCount = Nods.Count;
            coilElementsCount = Elements.Count;
            coilCount = 1;
        }
    }
}
