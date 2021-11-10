using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkWeek11
{
    class Program
    {
        static void Main(string[] args)
        {
            Person carl = new Person("Carl Smithers");
            Vehicle carl_car = new Vehicle(Vehicle.Manufacturers.HONDA, 4, carl);

            string temp = "James Lamarty";
            Person james = new Person(temp);
            Vehicle james_car = new Vehicle();
            james_car.Owner = james;
            james_car.Cylinders = 4;

            Person Beverly = new Person("Beverly Quill");
            Truck bev_truck = new Truck(Vehicle.Manufacturers.FORD, 6, Beverly, 1.5, 650);

            Person john = new Person("John Doe");
            Truck john_truck = new Truck();

            Console.WriteLine(carl_car.ToString());
            Console.WriteLine(james_car.ToString());
            Console.WriteLine(bev_truck.ToString());
            Console.WriteLine(john_truck.ToString());

            Console.WriteLine("Are James' and John's cars the same? " + james_car.Equals(john_truck));

            john_truck.Owner = Beverly;
            john_truck.Cylinders = bev_truck.Cylinders;
            john_truck.Manufacturer = bev_truck.Manufacturer;
            john_truck.Load_Capacity = bev_truck.Load_Capacity;
            john_truck.Towing_Capacity = bev_truck.Towing_Capacity;
            Console.WriteLine(john_truck.ToString());

            Console.WriteLine("Are Beverly's and John's trucks the same? " + bev_truck.Equals(john_truck));


            Console.Read();
        }
    }

    public class Vehicle
    {
        public enum Manufacturers
        {
            VOLVO,
            FORD,
            HONDA,
            HYUNDAI,
            TOYOTA,
            CHEVROLET,
            JEEP,
            KIA,
            RAM
        }

        private Manufacturers manufacturer;
        private int cylinders;
        private Person owner;

        public Manufacturers Manufacturer { get { return manufacturer; } set { manufacturer = value; } }
        public int Cylinders { get { return cylinders; } set { cylinders = value; } }
        public Person Owner { get { return owner; } set { owner = value; } }

        public Vehicle()
        {
            manufacturer = Manufacturers.VOLVO;
            cylinders = 4;
            owner = new Person("NO NAME PROVIDED");
        }

        public Vehicle(Manufacturers car_manufacturer, int num_cylinders, Person new_owner)
        {
            manufacturer = car_manufacturer;
            cylinders = num_cylinders;
            owner = new_owner;
        }

        public override string ToString()
        {
            return "MANUFACTURER:" + manufacturer + " CYLINDERS:" + cylinders + " OWNER:" + owner.ToString();
        }

        public override bool Equals(Object obj)
        {
            if (obj.ToString().CompareTo(this.ToString()) == 0)
                return true;
            return false;
        }
    }

    public class Truck : Vehicle
    {
        private double load_capacity; //Tons
        private int towing_capacity;  //Pounds

        public double Load_Capacity { get { return load_capacity; } set { load_capacity = value; } }
        public int Towing_Capacity { get { return towing_capacity; } set { towing_capacity = value; } }

        public Truck()
        {
            load_capacity = 0;
            towing_capacity = 0;
            Manufacturer = Manufacturers.VOLVO;
            Cylinders = 4;
            Owner = new Person("NO NAME PROVIDED");
        }

        public Truck(Manufacturers _manufacturer, int _cylinders, Person _owner, double _load_cap, int _tow_cap)
        {
            load_capacity = _load_cap;
            towing_capacity = _tow_cap;
            Manufacturer = _manufacturer;
            Cylinders = _cylinders;
            Owner = _owner;
        }

        public override string ToString()
        {
            return base.ToString() + " LOAD CAPACITY:" + load_capacity + " TOW CAPACITY:" + towing_capacity;
        }

        public override bool Equals(object obj)
        {
            return obj.ToString().CompareTo(this.ToString()) == 0;
        }
    }

    public class Person
    {
        private string name;

        public string Name { get {return name; } set { name = value;  } }

        public Person()
        {
            name = "";
        }
        public Person(string theName)
        {
            name = theName;
        }
        public Person(Person obj)
        {
            name = obj.ToString();
        }
        public string ToString()
        {
            return name;
        }
        public override bool Equals(Object obj)
        {
            return name.CompareTo(obj.ToString()) == 0;
        }
    }
}
