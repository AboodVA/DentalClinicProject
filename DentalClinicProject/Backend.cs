using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DentalClinicProject
{
    internal class Backend
    {

        public static Employee currentLoggedEmployee;
 //       public static Patient currentSelectedPatient;

        private static string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private static string folderPath = Path.Combine(desktopPath, "DentalClinic");

        public static bool HandleaUserSignUp(Employee employee)
        {


            try
            {

                StreamWriter sw = new StreamWriter(Path.Combine(folderPath, "employee.txt"), true);

                int id = GetAndUpdateNextID();
                employee.SetID(id);


                if (id < 0)
            {
                return false;
            }

            
                using (sw)
                {

                    string dataFormat = $"{employee.GetID()},{employee.GetName()},{employee.GetPassword()},{employee.GetEmail()}";

                    sw.WriteLine(dataFormat);

                    return true;
                }
            }catch(Exception ex)
            {
                Console.WriteLine("Error occured while writing user data to file");
                return false;
            }
            

            return false;



        }

        public static bool HandleUserLogin(string userName, string passwrod)
        {

            string path = Path.Combine(folderPath, "employee.txt");

            string line;

            using(StreamReader sr = new StreamReader(path))
            {
                line = sr.ReadLine();

                while(line != null)
                {
                    string[] parts = line.Split(",");

                    if (parts[1] == userName && parts[2] == passwrod)
                    {
                        Employee emp = new Employee(parts[1], parts[2], parts[3]);
                        emp.SetID(int.Parse(parts[0]));
                        currentLoggedEmployee = emp;
                        
                        return true;
                    }

                    line = sr.ReadLine();

                }
            }

            return false;
        }
       
        private static int GetAndUpdateNextID()
        {

            string path = Path.Combine(folderPath, "id.txt");

            int nextID;

            try
            {

                using (StreamReader sr = new StreamReader(path))
                {
                    nextID = int.Parse(sr.ReadLine()) + 1;
                }

                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(nextID);
                }

                return nextID;

            }catch(Exception ex)
            {
                Console.WriteLine("Error occured");
                return -1;
            }

            return -1;

        }

    }
}
   
