using System;
using System.IO;

namespace Assessment2AT
{
    // base class (parent)
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
            
            int chkKM = kms;
            if (chkKM + kmDriven < 0) //checking if KM update will take total km to negative
            {
                kmDriven = 0; //changing to 0 as cannot be negative
                Console.WriteLine("Kilometers driven cannot go into negative, setting KM to 0");
            }
            else
            {
                kmDriven = kmDriven + kms; // adding provided km to class variable
            }
        }


        public void displayGeneral()
        {
            //display general details of the object calling this method
            Console.WriteLine("\nVehicle Details");
            Console.WriteLine("Registration is: " + this.registrationNumber + " Make is: " + this.make + " Model is: " + this.model + " Kilometers Driven: " + this.kmDriven);
        }


    }

    // Derived class (child) from Vehicle
    public class Car : Vehicle
    {
        //Car class attributes
        public string bodyType;
        public string colour;
        public string upholstry;
        public int noOfDoors;

        //Constructor of Car class with default assignment
        public Car()
        {
            bodyType = "Sedan";
            colour = "Blue";
            upholstry = "Cloth trip";
            noOfDoors = 4;
        }


        //Constructor of Car class with arguments to assign values
        public Car(string reg, string mk, string mdl, int km, string bt, string clr, string upl, int drs, Driver dr)
        {
            registrationNumber = reg;
            make = mk;
            model = mdl;
            kmDriven = km;
            bodyType = bt;
            colour = clr;
            upholstry = upl;
            noOfDoors = drs;
            this.driver = dr;
        }

        public void changeColour(String clr)
        {
            colour = clr; //changing colour attribute of class variable
        }

        public void displaySpecific()
        {
            Console.WriteLine("\nCar Details");
            Console.WriteLine("Body Typ: " + this.bodyType + " Colour: " + this.colour + " Upholstry: " + this.upholstry + " No of Doors: " + this.noOfDoors);

        }

        public void displayGeneralSpecific()
        {
            displaySpecific(); //calling display specific method from this class
            displayGeneral();  //calling display general method from vehicle class
        }

        public void displayAll()
        {
            displayGeneralSpecific();//calling display general specific method from this class
            driver.displayDriver();//calling display driver from Driver class
        }

    }

    public class Truck : Vehicle  // derived class (child)
    {
        //Declare attributes of the truck class
        public int maximumLoad;
        public int noOfAxles;
        public int noOfWheels;

        //default constructor of Truck class
        public Truck()
        {

        }

        //Constructor of Truck class with arguments
        public Truck(string reg, string mak, string mod, int km, int mxl, int axl, int whls)
        {
            registrationNumber = reg;
            make = mak;
            model = mod;
            kmDriven = km;
            maximumLoad = mxl;
            noOfAxles = axl;
            noOfWheels = whls;
        }

        public void displaySpecific()
        {
            Console.WriteLine("\nCar Details");
            Console.WriteLine("Maximum Load: " + this.maximumLoad + " Number of Axles: " + this.noOfAxles + " Number of Wheels: " + this.noOfWheels);

        }

        public void displayGeneralSpecific()
        {
            displaySpecific(); //calling display specific method from this class
            displayGeneral();  //calling display general method from vehicle class
        }

        public void displayAll()
        {
            displayGeneralSpecific();//calling display general specific method from this class
            driver.displayDriver();//calling display driver from Driver class
        }
    }


    public class Driver
    {
        public string licenseNo;
        public string firstName;
        public string lastName;
        public int mobilePhoneNo;
        public string[] address;
        public string[] stateLicense;
        public int maxDemerits;

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
public Driver(string lno, string fn, string ln, int mno, string[] addr, string[] sts, int dms)
        {
            licenseNo = lno;
            firstName = fn;
            lastName = ln;
            mobilePhoneNo = mno;
            address = addr;
            stateLicense = sts;
            maxDemerits = dms;
        }

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

        public void addDeleteDemerits(int DM)
        {
            int chkdm = DM;
            if (chkdm + maxDemerits < 0)
            {
                maxDemerits = 0;
                Console.WriteLine("\nDemerits cannot go negative, Your new demerits are 0");
            }
            else if( maxDemerits + chkdm > 9 & maxDemerits + chkdm <= 12)
            {

                maxDemerits = maxDemerits + chkdm;
                Console.WriteLine("\nYour new demerits are: " + maxDemerits +  ", License suspension imminent");
            }

            else if ( maxDemerits + chkdm > 12 )
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

        public void writeDriverToFile()
        {
            //Create a text string
            string writeText = "Driver Details: ";  
            File.WriteAllText("C:\\csharpfiles\\test.txt", writeText);
            File.AppendAllText("C:\\csharpfiles\\test.txt", "License Number: " + licenseNo + " " + " First name: " + firstName + " " + " Last name: " + lastName + " "  + " Mobile phone No: " + mobilePhoneNo + " " + " Max Demerirts: " +  maxDemerits + " ");
            File.AppendAllText("C:\\csharpfiles\\test.txt", " Address:  " + " " + address[0] + " " + address[1] + " " + address[2] + " " + address[3]);
            File.AppendAllText("C:\\csharpfiles\\test.txt", " State licnese: " + stateLicense[0] + stateLicense[1] );
        }

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
        }
    }
}
