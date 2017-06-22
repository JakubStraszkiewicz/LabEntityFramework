using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PTLab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int create = 1;
        static int edit = 2;
       
        public MainWindow()
        {
            InitializeComponent();
            Add();
            MyDbContext context = new MyDbContext();
            List<Car> carsList = context.Cars.Include("Engine").ToList();
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Cars', RESEED, 9)");
            context.SaveChanges();
           
            //context.Database.Delete();
            /*foreach (Car car in carsList)
                if ( car.Id == 10)
                {

                    context.Cars.Remove(
                         car
                        );
                    context.SaveChanges();
                }*/
        }
        public void Add()
        {
            MyDbContext ctx = new MyDbContext();
            List<Car> carsList = ctx.Cars.Include("Engine").ToList();
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

            foreach (var car in elements1)
                dataGrid.Items.Add(car);

            dataGrid.BeginningEdit += cell_MouseDoubleClick;
        }

        private void cell_MouseDoubleClick(Object sender, DataGridBeginningEditEventArgs e)
        {
            System.Windows.Forms.Application.Run(new Form1(dataGrid, edit));
            e.Cancel = true;
        }


        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            try {
                if (e.Key == Key.Enter)
                    search();
            }catch(Exception ex)
            {
                Console.Write(ex);
            }
        }

        public void search()
        {
            MyDbContext ctx = new MyDbContext();
            List<Car> carsList = ctx.Cars.Include("Engine").ToList();
            List<Car> carsList2 = ctx.Cars.Include("Engine").Where(l => l.Model.Contains(textBox.Text)).ToList();

            List<Car> search = new List<Car>();

            if (comboBox.Text == "Model")
            {
                foreach (Car car in carsList)
                    if (car.Model.IndexOf(textBox.Text, StringComparison.CurrentCultureIgnoreCase) != -1)
                        search.Add(car);
                dataGrid.Items.Clear();
                foreach (Car car in search)
                    dataGrid.Items.Add(car);
            }
            else
                    if (comboBox.Text == "Year")
            {
                foreach (Car car in carsList)
                    if (car.Year == Int32.Parse(textBox.Text))
                        search.Add(car);
                dataGrid.Items.Clear();
                foreach (Car car in search)
                    dataGrid.Items.Add(car);
            }
        }

        private void dodajButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Application.Run(new Form1(dataGrid,create));          
        }

    }


    public class MyDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Engine> Engines { get; set; }
        
        public MyDbContext()
        {
            Database.Log = msg => Debug.WriteLine(msg);
        }
    }
}
