namespace MachineLearn
{
    class Operation
    {
        public string name;
        public int details, shifts, coef;
        public double time;
        public Operation(string name,int details, int shifts, double time, int coef)
        {
            this.name = name;
            this.details = details;
            this.time = time;
            this.shifts = shifts;
            this.coef = coef;
        }
    }
}
