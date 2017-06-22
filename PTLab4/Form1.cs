using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTLab4
{
    public partial class Form1 : Form
    {
        static int create = 1;
        static int edit = 2;

        public System.Windows.Controls.DataGrid dataGrid;
        public int type;
        private int id;
        public Form1(System.Windows.Controls.DataGrid dataGrid,int type)
        {
            
            InitializeComponent();
            this.dataGrid = dataGrid;
            this.type = type;
            startAction();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (type == create)
                createAction();
            else
                if (type == edit)
                    editAction();
        }

        private void startAction()
        {
            MyDbContext ctx = new MyDbContext();
            var carId = dataGrid.SelectedIndex;
            var car = ctx.Cars.Include("Engine").Where(x => x.Id == carId+1).FirstOrDefault();
            if (type == edit)
            {
                this.id = car.Id;
                modelTextBox.Text = car.Model;
                yearTextBox.Text = car.Year.ToString();
                engineModelTextBox.Text = car.Engine.Model;
                displacementTextBox.Text = car.Engine.Displacement.ToString();
                horsepowerTextBox.Text = car.Engine.HorsePower.ToString();
            }
        }
        private void editAction()
        {
            MyDbContext ctx = new MyDbContext();
            var car = ctx.Cars.Include("Engine").Where(x => x.Id == this.id).FirstOrDefault();
            car.Model = modelTextBox.Text;
            car.Year = Int32.Parse(yearTextBox.Text);
            car.Engine.Model = engineModelTextBox.Text;
            car.Engine.Displacement = Double.Parse(displacementTextBox.Text);
            car.Engine.HorsePower = Double.Parse(horsepowerTextBox.Text);

            ctx.SaveChanges();
            List<Car> carsList = ctx.Cars.Include("Engine").ToList();
            dataGrid.Items.Clear();
            var elements1 =
              from c in carsList
              select new
              {
                  Id = c.Id,
                  Model = c.Model,
                  Engine = c.Engine,
                  Year = c.Year,
                  EngineType = c.Engine.Model == "TDI" ? "diesel" : "petrol",
              };

            foreach (var vehicle in elements1)
                dataGrid.Items.Add(vehicle);
           // this.Close();
        }
        private void createAction()
        {
            MyDbContext ctx = new MyDbContext();
            string model = modelTextBox.Text;
            int year = Int32.Parse(yearTextBox.Text);
            string engineModel = engineModelTextBox.Text;
            double displacement = Double.Parse(displacementTextBox.Text);
            double horsepower = Double.Parse(horsepowerTextBox.Text);

            Engine engine = new Engine(displacement, horsepower, engineModel);
            Car car = new Car(model, engine, year);
            List<Car> carsList = new List<Car>();
            carsList.Add(car);
            ctx.Cars.Add(car);
            ctx.SaveChanges();

            var elements1 =
               from c in carsList
               select new
               {
                   Id = c.Id,
                   Model = c.Model,
                   Engine = c.Engine,
                   Year = c.Year,
                   EngineType = c.Engine.Model == "TDI" ? "diesel" : "petrol",
               };
            foreach (var cars in elements1)
                dataGrid.Items.Add(cars);
            this.Close();
        }

    }
}
