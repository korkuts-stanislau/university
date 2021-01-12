using System;
using System.Collections.Generic;
using System.Linq;
using ExceptionLib;

namespace PolynomLib
{
    public class Polinomial
    {
        Monomial[] Monomials { get; set; }
        public Polinomial(string polinomialString)
        {
            try
            {
                Monomials = FromStringToMonomials(polinomialString);
            }
            catch
            {
                throw new PolynomException("Input polinomial isn't correct");
            }
        }
        public Polinomial(Monomial[] monomials)
        {
            Monomials = monomials;
        }
        public override string ToString()
        {
            string resultString = "";
            foreach (Monomial monomial in Monomials)
            {
                if (monomial.Coefficient > 0)
                    resultString += " +" + monomial.ToString();
                else
                    resultString += " " + monomial.ToString();
            }
            return resultString.Substring(1, resultString.Length - 1);
        }
        Monomial[] FromStringToMonomials(string polinomialString)
        {
            string[] monomialsStringArray = polinomialString.Split(' ');
            Monomial[] monomials = new Monomial[monomialsStringArray.Length];
            int i = 0;
            foreach (string mono in monomialsStringArray)
            {
                if (mono[1] != 'x' && mono.Contains('x') && mono.Contains('^')) // 4
                    monomials[i] = new Monomial(Convert.ToInt32(mono.Split('^')[1]), Convert.ToDouble(mono.Split('x')[0]));
                else if (mono[1] != 'x' && mono.Contains('x') && !mono.Contains('^')) // 1
                    monomials[i] = new Monomial(1, Convert.ToDouble(mono.Split('x')[0]));
                else if (mono[1] == 'x' && mono.Contains('x') && !mono.Contains('^')) // 5
                    monomials[i] = new Monomial(1, 1);
                else if (mono[1] != 'x' && !mono.Contains('x') && !mono.Contains('^')) // 3
                    monomials[i] = new Monomial(0, Convert.ToDouble(mono));
                else // 2
                    monomials[i] = new Monomial(Convert.ToInt32(mono.Split('^')[1]), 1);
                i++;
            }
            return monomials;
        }
        public static Polinomial operator *(Polinomial pol, double number)
        {
            List<Monomial> resultMonomials = new List<Monomial>();
            foreach (Monomial monomial in pol.Monomials)
            {
                resultMonomials.Add(new Monomial(monomial.Power, monomial.Coefficient * number));
            }
            return new Polinomial(resultMonomials.ToArray());
        }
        public static Polinomial operator *(Polinomial pol1, Polinomial pol2)
        {
            List<Monomial> monomials = new List<Monomial>();
            foreach (Monomial monomial1 in pol1.Monomials)
            {
                foreach (Monomial monomial2 in pol2.Monomials)
                {
                    monomials.Add(new Monomial(monomial1.Power + monomial2.Power, monomial1.Coefficient * monomial2.Coefficient));
                }
            }
            List<int> powers = new List<int>();
            foreach (Monomial monomial in monomials)
            {
                if (!powers.Contains(monomial.Power))
                    powers.Add(monomial.Power);
            }
            List<Monomial> resultMonomials = new List<Monomial>();
            int count = 0;
            foreach (int power in powers)
            {
                resultMonomials.Add(new Monomial(power, 1));
                foreach (Monomial monomial in monomials)
                {
                    if (monomial.Power == power)
                    {
                        resultMonomials[count] = resultMonomials[count] + monomial;
                    }
                }
                count += 1;
            }
            return new Polinomial(resultMonomials.ToArray());
        }
    }
}
