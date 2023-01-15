using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Specialized;

namespace DentalClinicProject
{
    internal class Backend
    {

        public static Employee currentLoggedEmployee;
        public static Admin currentLoggedInAdmin;
        //       public static Patient currentSelectedPatient;
        public static Patient currentSelectedPatient;

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
            } catch (Exception ex)
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

            using (StreamReader sr = new StreamReader(path))
            {
                line = sr.ReadLine();

                while (line != null)
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

        public static List<Patient> FetchAllPatients()
        {
           
            List<Patient> patients = new List<Patient>();

            try
            {
                using (StreamReader sr = new StreamReader(Path.Combine(folderPath, "patients.txt")))
                {

                    string line;
                    while( (line = sr.ReadLine()) != null) 
                    {
                        string[] parts = line.Split(",");
                        int id = int.Parse(parts[0]);
                        string name = parts[1];
                        string email = parts[2];
                        string dateOfBirth = parts[3];
                        string gender = parts[4];

                        Patient patient = new Patient(name, email, dateOfBirth, gender);
                        patient.SetID(id);

                        patients.Add(patient);


                    }


                    return patients;

                }
            }catch(IOException e)
            {
                Console.WriteLine("Error occured while fetching patients " + e.Message);
            }

            return null;
        }

        public static List<Employee> FetchAllEmployees()
        {

            List<Employee> employees = new List<Employee>();

            try
            {
                using (StreamReader sr = new StreamReader(Path.Combine(folderPath, "employee.txt")))
                {

                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(",");
                        int id = int.Parse(parts[0]);
                        string name = parts[1];
                        string password = parts[2];
                        string email = parts[3];

                        Employee emp = new Employee(name, password, email);
                        emp.SetID(id);

                        employees.Add(emp);


                    }


                    return employees;

                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error occured while fetching patients " + e.Message);
            }

            return null;
        }


        public static bool HandlePatientAdd(Patient patient)
        {

            int id = GetAndUpdateNextID();

            try
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(folderPath, "patients.txt"), true))
                {

                    string format = $"{id},{patient.GetName()},{patient.GetEmail()},{patient.GetDateOfBirth()},{patient.GetGender()},{patient.GetNextAppointment()}";

                    sw.WriteLine(format);
                    return true;
                }
            } catch (IOException e)
            {
                MessageBox.Show("Error Occured while adding patients\n" + e.Message);
            }

            return false;
        }


        public static bool HandleAdminLogin(string userName, string passwrod)
        {

            string path = Path.Combine(folderPath, "admin.txt");

            string line;

            using (StreamReader sr = new StreamReader(path))
            {
                line = sr.ReadLine();

                while (line != null)
                {
                    string[] parts = line.Split(",");

                    if (parts[1] == userName && parts[2] == passwrod)
                    {
                        Admin admin = new Admin(parts[1], parts[2]);

                        admin.ID = int.Parse(parts[0]);
                        currentLoggedInAdmin = admin;

                        return true;
                    }

                    line = sr.ReadLine();

                }
            }

            return false;
        }



        public static void HandleSelectedPatient(int id)
        {


            try
            {
                using (StreamReader sr = new StreamReader(Path.Combine(folderPath, "patients.txt")))
                {
                    string line;
                    while((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(",");
                        int storedID = int.Parse(parts[0]);

                        if (storedID == id)
                        {
                            Patient patient = new Patient(parts[1], parts[2], parts[3], parts[4]);
                            patient.SetID(id);
                            currentSelectedPatient = patient;
                            return;
                        }
 

                    }

                }
            }catch(IOException e)
            {
                Console.WriteLine("Error occured !");
            }
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

        public static bool IsNameNotTaken(string name, string fileName)
        {

            try
            {

                string line;

                using (StreamReader sr = new StreamReader(Path.Combine(folderPath, fileName)))
                {

                    while ((line = sr.ReadLine()) != null)
                    {
                        string storedName = line.Split(",")[1];
                        Console.WriteLine(storedName);
                        if (storedName == name)
                        {
                            return false;
                        }
                    }

                    return true;

                }
            }catch(IOException e)
            {
                Console.WriteLine("Error occured");
                return false;

            }


        }

        public static bool HandleRemoveAccount(int id, string path)
        {

            try
            {


                return true;
            }catch(IOException e)
            {
                Console.WriteLine("Error occured");
                return false;
            }

        }



    }
}
   
