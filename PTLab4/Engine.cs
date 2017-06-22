using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTLab4
{
    public class Engine : IComparable
    {
        public int Id { get; set; }
        public double Displacement { get; set; }
        public double HorsePower { get; set; }
        public String Model { get; set; }
        public Engine() { }
        public Engine(double displacement, double horsePower, string model)
        {
            this.Displacement = displacement;
            this.HorsePower = horsePower;
            this.Model = model;
        }
        public override string ToString()
        {
            return Model + " " + Displacement + " (" + HorsePower + " hp) ";
        }

        public int CompareTo(object obj)
        {
            if (this.Model.CompareTo(((Engine)obj).Model) == 0)
                if (this.HorsePower.CompareTo(((Engine)obj).HorsePower) > 0)
                    return -1;
                else
                    return 1;
            else
                if (this.Model.CompareTo(((Engine)obj).Model) < 0)
                    return 1;
                else
                    return -1;
        }
    }
}
