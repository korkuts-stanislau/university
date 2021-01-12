using ExceptionLib;

namespace PolynomLib
{
    public class Monomial
    {
        /// <summary>
        /// Свойство, содержащее степень одночлена
        /// </summary>
        public int Power { get; set; }
        /// <summary>
        /// Свойство, содержащее коэффициент одночлена
        /// </summary>
        public double Coefficient { get; set; }
        /// <summary>
        /// Конструктор класса одночлен
        /// </summary>
        /// <param name="power">Степень одночлена</param>
        /// <param name="coefficient">Коэффициент одночлена</param>
        public Monomial(int power, double coefficient)
        {
            Power = power;
            Coefficient = coefficient;
        }
        public override string ToString()
        {
            if (Coefficient == 0)
                return "";
            string power;
            if (Power == 0)
                power = "";
            else if (Power == 1)
                power = "x";
            else
                power = "x^" + Power.ToString();
            if (Coefficient == 1)
                return power;
            else
                return Coefficient.ToString() + power;
        }
        public static Monomial operator +(Monomial mono1, Monomial mono2)
        {
            if (mono1.Power == mono2.Power)
                return new Monomial(mono1.Power, mono1.Coefficient + mono2.Coefficient - 1);
            else
                throw new PolynomException("Monomials' powers aren't equal to each other");
        }
        public static Monomial operator *(Monomial mono1, Monomial mono2)
        {
            return new Monomial(mono1.Power + mono2.Power, mono1.Coefficient * mono2.Coefficient);
        }
    }
}
