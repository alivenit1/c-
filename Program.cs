using System;
using System.IO;
/*
 * Aliveni Thodupunuri
 * v1.0
 * This program is for trucking company
 * where a car and a driver have been created
 * and how the updates to kilometers, demerits
 * are performed and viewing of vehicle, car & driver details 
 * are perforemed.
 * This program also has read/write to text file
 * 
 */
namespace Assessment2AT
{
    // base class (parent)
    // this class is used by both Car & truck
    public class Vehicle
    {
        //Declare attributes of the Vehicle class
        public string registrationNumber;
        public string make;
        public string model;
        public int kmDriven;
        public Driver driver;

        //Method updateKM() accepts Kilometers as argument and updates the current vehicles kmDriven
        public void updateKM(int kms)
        {
            //update kilometers of the object calling this method
            
            
            if (kms + kmDriven < 0) //checking if KM update will take total km to negative
            {
                Console.WriteLine("Kilometers driven cannot go into negative, no changes made");
            }
            else
            {
                kmDriven = kmDriven + kms; // adding provided km to class variable
            }
        }

        //displaying of vehicle general details
        public virtual void displayGeneral()
        {
            //display general details of the object calling this method
            Console.WriteLine("\nVehicle Details");
            Console.WriteLine("Registration is: " + this.registrationNumber + " Make is: " + this.make + " Model is: " + this.model + " Kilometers Driven: " + this.kmDriven);
        }


    }

    // Derived class (child) from Vehicle
    //inheriting Vehicle class
    public class Car : Vehicle
    {
        //Car class attributes
        private string bodyType;
        private string colour;
        private string upholstery;
        private int noOfDoors;

        //Constructor of Car class with default assignment
        public Car()
        {
            bodyType = "Sedan";
            colour = "Blue";
            upholstery = "Cloth trim";
            noOfDoors = 4;
        }


        //Constructor of Car class with arguments to assign values
        public Car(string registrationNumber, string make, string model, int kmDriven, string bodyType, string colour, string upholstery, int noOfDoors, Driver driver)
        {
            this.registrationNumber = registrationNumber;
            this.make = make;
            this.model = model;
            this.kmDriven = kmDriven;
            this.bodyType = bodyType;
            this.colour = colour;
            this.upholstery = upholstery;
            this.noOfDoors = noOfDoors;
            this.driver = driver;
        }

        //overriding the vehcile class displayGeneral method
        public override void displayGeneral()
        {
            //display general details of the object calling this method
            Console.WriteLine("\nCar Vehicle Details");
            Console.WriteLine("Registration is: " + this.registrationNumber + " Make is: " + this.make + " Model is: " + this.model + " Kilometers Driven: " + this.kmDriven);
        }

        //method accepts colour from user and updates to object of car class
        public void changeColour(String clr)
        {
            colour = clr; //changing colour attribute of class variable
        }

        //displays car specific details
        public void displaySpecific()
        {
            Console.WriteLine("\nCar Specific Details");
            Console.WriteLine("Body Typ: " + this.bodyType + " Colour: " + this.colour + " Upholstery: " + this.upholstery + " No of Doors: " + this.noOfDoors);

        }

        //displays vehicle class general details and car specific details
        public void displayGeneralSpecific()
        {
            displaySpecific(); //calling display specific method from this class
            displayGeneral();  //calling display general method from vehicle class
        }

        //displays all vehicle details including specific and associated driver
        public void displayAll()
        {
            displayGeneralSpecific();//calling display general specific method from this class
            driver.displayDriver();//calling display driver from Driver class
        }

    }

    // derived class (child)
    //inheriting Vehicle class
    public class Truck : Vehicle  
    {
        //Declare attributes of the truck class
        private int maximumLoad;
        private int noOfAxles;
        private int noOfWheels;

        //default constructor of Truck class
        public Truck()
        {

        }

        //Constructor of Truck class with arguments
        public Truck(string registrationNumber, string make, string model, int kmDriven, int maximumLoad, int noOfAxles, int noOfWheels, Driver driver)
        {
            this.registrationNumber = registrationNumber;
            this.make = make;
            this.model = model;
            this.kmDriven = kmDriven;
            this.maximumLoad = maximumLoad;
            this.noOfAxles = noOfAxles;
            this.noOfWheels = noOfWheels;
            this.driver = driver;
        }

        //overriding the vehcile class displayGeneral method
        public override void displayGeneral()
        {
            //display general details of the object calling this method
            Console.WriteLine("\nTruck Vehicle Details");
            Console.WriteLine("Registration is: " + this.registrationNumber + " Make is: " + this.make + " Model is: " + this.model + " Kilometers Driven: " + this.kmDriven);
        }

        //displays Truck specific details
        public void displaySpecific()
        {
            Console.WriteLine("\nTruck Details");
            Console.WriteLine("Maximum Load: " + this.maximumLoad + " Number of Axles: " + this.noOfAxles + " Number of Wheels: " + this.noOfWheels);

        }
        //displays vehicle class general details and truck specific details
        public void displayGeneralSpecific()
        {
            displaySpecific(); //calling display specific method from this class
            displayGeneral();  //calling display general method from vehicle class
        }
        //displays all vehicle details including specific and associated driver
        public void displayAll()
        {
            displayGeneralSpecific();//calling display general specific method from this class
            driver.displayDriver();//calling display driver from Driver class
        }
    }


    public class Driver
    {
        //instance variables
         private string licenseNo;
         private string firstName;
         private string lastName;
         private int mobilePhoneNo;
         private string[] address;
         private string[] stateLicense;
         private int maxDemerits;

         //Default constructor of Driver class
         public Driver()
         {
             licenseNo = "11999888";
             firstName = "Aliveni";
             lastName = "Thodupunuri";
             mobilePhoneNo = 999888333;
             maxDemerits = 0;
             address = new string[4] { "Street: 123 Main Road", "City: Melbourne", "State: VIC", "Post Code: 3030" };
             stateLicense = new string[2] { "VIC :", "NSW" };
         }



        //Constructor of Driver class with arguments
        public Driver(string licenseNo, string firstName, string lastName, int mobilePhoneNo, string[] address, string[] stateLicense, int maxDemerits)
         {
            this.licenseNo = licenseNo;
            this.firstName = firstName;
            this.lastName = lastName;
            this.mobilePhoneNo = mobilePhoneNo;
            this.address = address;
            this.stateLicense = stateLicense;
            this.maxDemerits = maxDemerits;
            
         }
        //displayes driver details including address & state licenses
        public void displayDriver()
        {
            Console.WriteLine("\nDriver details - License No: " + licenseNo + " Driver First Name: " + firstName + " Driver Last Name: " + lastName + " Mobile Phone No: " + mobilePhoneNo + " Max Demerits: " + maxDemerits);
            Console.Write("\nThe driver is licenced Licensed to Drive in States : ");
            //extract statelicence and address from arrays using loop
            foreach (string i in stateLicense)
            {
                Console.Write(i);
            }
            Console.WriteLine("\nAddress is : \n");
            foreach (string i in address)
            {
                Console.Write(i + "\n");
            }

        }
        //method accepts new demerits (+/-), checks conditions of new demerit value and updates
        public void addDeleteDemerits(int DM)
        {

            if (DM + maxDemerits < 0)
            {
                maxDemerits = 0;
                Console.WriteLine("\nDemerits cannot go negative, Your new demerits are 0");
            }
            else if( maxDemerits + DM > 9 & maxDemerits + DM <= 12)
            {

                maxDemerits = maxDemerits + DM;
                Console.WriteLine("\nYour new demerits are: " + maxDemerits +  ", License suspension imminent");
            }
            else if ( maxDemerits + DM > 12 )
            //else 
            {
                maxDemerits = 12;
                Console.WriteLine( "\nDemerits cannot go over 12, demerits set to 12 ");
 
            }
            else
            {
                maxDemerits = maxDemerits + DM;
                Console.WriteLine("\nMax demirts updated");
            }

        }
        //method writes driver details to text file
        public void writeDriverToFile()
        {

            File.AppendAllText("C:\\csharpfiles\\test.txt", "Driver Details:\nLicense Number: " + licenseNo + " " + " First name: " + firstName + " " + " Last name: " + lastName + " "  + " Mobile phone No: " + mobilePhoneNo + " " + " Max Demerirts: " +  maxDemerits + "\n");
            File.AppendAllText("C:\\csharpfiles\\test.txt", "Address: \n");
            File.AppendAllLines("C:\\csharpfiles\\test.txt", address);
            File.AppendAllText("C:\\csharpfiles\\test.txt", "Licenced to drive in : \n");
            File.AppendAllLines("C:\\csharpfiles\\test.txt", stateLicense);

            //File.AppendAllText("C:\\csharpfiles\\test.txt", " Address:  " + " " + address[0] + " " + address[1] + " " + address[2] + " " + address[3]);
            //File.AppendAllText("C:\\csharpfiles\\test.txt", " State licnese: " + stateLicense[0] + stateLicense[1] );
        }
        //method reads from text file
        public void readDriverFromFile()
        {
            //Reading contents from file
            string contents = File.ReadAllText("C:\\csharpfiles\\test.txt");
            Console.WriteLine(contents);
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            //Demonstrating another constructor of car class
            Car myCar2 = new Car();
            myCar2.displaySpecific();

            
            //Create driver1 using constructor with parameters
            string [] address = { "Street: 16 Tyalla St", "City: Wyndham Vale", "State: VIC", "Post Code: 3024" };
            string [] stateLicense =  { " VIC : ", "NSW " };
            Driver driver1 = new Driver("DL123456", "Aliveni", "Thodupunuri", 0401998778, address, stateLicense, 0);
            
            //Create myCar1 object using constructor with parameters
            Car myCar1 = new Car("CAR1111", "Hyundai", "Santafe", 1000, "SUV", "Grey", "Leather", 4, driver1);

            Console.WriteLine("\n*******Sequence 1 *********************");

            myCar1.displaySpecific();
            myCar1.displayGeneral();

            Console.WriteLine("\n*******Sequence 2 *********************");
            myCar1.displayAll();

            Console.WriteLine("\n*******Sequence 3 *********************");
            Console.WriteLine("\n******* Add 2 Demerits *********************");

            driver1.addDeleteDemerits(2);
            myCar1.updateKM(100);
            myCar1.changeColour("Red");
            myCar1.displayAll();

            Console.WriteLine("\n*******END Sequence *********************");

            Console.WriteLine("\n*******Checking KM Conditons *********************");
            myCar1.updateKM(-2201);
            myCar1.displayGeneral();

            Console.WriteLine("\n*******Checking Demerit Conditons*********************");
            Console.WriteLine("\n*******Checking <0 condition");
            driver1.addDeleteDemerits(-3);
            driver1.displayDriver();

            Console.WriteLine("\n********Checking >9 & <=12 condition");
            driver1.addDeleteDemerits(10);
            driver1.displayDriver();

            Console.WriteLine("\n********Checking >12 condition");
            driver1.addDeleteDemerits(4);
            driver1.displayDriver();

            Console.WriteLine("\n********Reading Driver Details from file after writing");
            driver1.writeDriverToFile();
            driver1.readDriverFromFile();

            Console.WriteLine("\n********Creating Truck class object and another driver to assign it");
            string[] address2 = { "Street: 1 Main St", "City: Wyndham Vale", "State: VIC", "Post Code: 3000" };
            string[] stateLicense2 = { " VIC : ", "NSW :", "WA " };
            Driver driver2 = new Driver("DL124333", "Kiran", "Kumar", 1234568877, address2, stateLicense2, 0);
            Truck myTruck1 = new Truck("TRK1111", "Toyota", "MaxTruck", 1500, 2500, 2,8, driver2);
            myTruck1.displayGeneral();
            myTruck1.displaySpecific();
            myTruck1.displayGeneralSpecific();

        }
    }
}
