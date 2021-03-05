using System;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;

namespace RejestrOsobowy
{
    class Program
    {
        public static int a;
        public static string q;
        public static string w;
        public static string e;
        public static string r;
        public static string t;
        public static string y;
        public static string u;
        public static string i;
        public static DateTime d;

        static string ManWoman (int sex)
        {
            if (sex == 1)
            {
                return "Mężczyzna";

            }
            if (sex == 2)
            {
                return "Kobieta";
            }
            else
            {
                return "Nie podano";
            }
        }

        static void Cookies()
        {
            string path = "listpersoncookies.xml";
            try
            { 
            if (File.Exists(path))
            {
                File.Delete("listperson.xml");
                System.IO.File.Move("listpersoncookies.xml", "listperson.xml");
                Console.WriteLine("Pomyślnie usunięto pamięć podręczną");
            }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ViewAll()
        {
            //DESERIALIZACJA LISTY
            Console.Clear();
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
                StreamReader sr = new StreamReader("listperson.xml");
                List<Person> listperson = (List<Person>)xmlSerializer.Deserialize(sr);
                Console.WriteLine("Rejestr osób - lista");
                foreach (Person person in listperson)
                {
                    Console.WriteLine("\r\nDane osobowe");
                    Console.WriteLine("imie: " + person.Name);
                    Console.WriteLine("nazwisko: " + person.Surname);
                    Console.WriteLine("data urodzenia: " + person.DateOfBirth);
                    Console.WriteLine("plec: " + ManWoman(person.Sex));
                    Console.WriteLine("\r\nDane adresowe");
                    Console.WriteLine("kod pocztowy: " + person.Zipcode);
                    Console.WriteLine("miasto: " + person.City);
                    if (person.ApartmentNumber == "")
                    {
                        Console.WriteLine("adres: " + person.Street + " " + person.HouseNumber);
                    }
                    else
                    {
                        Console.WriteLine("adres: " + person.Street + " " + person.HouseNumber + "/" + person.ApartmentNumber);
                    }
                    Console.WriteLine("_________________________________");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        static void SearchAll(string word)
        {
            //DESERIALIZACJA LISTY Z WYSZUKIWANIEM
            Console.Clear();
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
                StreamReader sr = new StreamReader("listperson.xml");
                List<Person> listperson = (List<Person>)xmlSerializer.Deserialize(sr);
                Console.WriteLine("Rejestr osób - lista");
                Console.WriteLine("Wyszukiwane słowo: "+ word);               
                foreach (Person person in listperson)                  
                {
                    if (person.Name.ToUpper().IndexOf(word.ToUpper()) == 0 || person.Surname.ToUpper().IndexOf(word.ToUpper()) == 0 || person.Zipcode.ToUpper().IndexOf(word.ToUpper()) == 0 || person.City.ToUpper().IndexOf(word.ToUpper()) == 0 || person.Street.ToUpper().IndexOf(word.ToUpper()) == 0 || person.HouseNumber.ToUpper().IndexOf(word.ToUpper()) == 0 || person.ApartmentNumber.ToUpper().IndexOf(word.ToUpper()) == 0)
                    { 
                        Console.WriteLine("\r\nDane osobowe");
                        Console.WriteLine("imie: " + person.Name);
                        Console.WriteLine("nazwisko: " + person.Surname);
                        Console.WriteLine("data urodzenia: " + person.DateOfBirth);
                        Console.WriteLine("plec: " + ManWoman(person.Sex));
                        Console.WriteLine("\r\nDane adresowe");
                        Console.WriteLine("kod pocztowy: " + person.Zipcode);
                        Console.WriteLine("miasto: " + person.City);
                        if (person.ApartmentNumber == "")
                        {
                            Console.WriteLine("adres: " + person.Street + " " + person.HouseNumber);
                        }
                        else
                        {
                            Console.WriteLine("adres: " + person.Street + " " + person.HouseNumber + "/" + person.ApartmentNumber);
                        }
                        Console.WriteLine("_________________________________");
                        a++;
                    }
                }
                Console.WriteLine("\r\nZnaleziono " + a + " dopasowań.");
                a = 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }


        static void AddPerson()
        {



            // DESERIUALIZACJA I SERIALIZACJA Z DODATKIEM
            Console.Clear();
            Console.WriteLine("Podaj imię: ");
            string curName = Console.ReadLine();
            Console.WriteLine("Podaj naziwsko: ");
            string curSurname = Console.ReadLine();
            Console.WriteLine("Podaj datę urodzenia (YYYY-MM-DD): ");
            string curDateOfBirth = Console.ReadLine();
            Console.WriteLine("Podaj płeń (1 - Mężczyzna, 2 - Kobieta: ");
            string stringcurSex = Console.ReadLine();
            int curSex = int.Parse(stringcurSex);
            Console.WriteLine("Podaj kod pocztowy: ");
            string curZipcode = Console.ReadLine();
            Console.WriteLine("Podaj miasto: ");
            string curCity = Console.ReadLine();
            Console.WriteLine("Podaj ulicę: ");
            string curStreet = Console.ReadLine();
            Console.WriteLine("Podaj numer domu: ");
            string curHouseNumber = Console.ReadLine();
            Console.WriteLine("Podaj numer mieszkania: ");
            string curApartmentNumber = Console.ReadLine();

            try
            {
                Person person = new Person { Name = curName, Surname = curSurname, DateOfBirth = DateTime.Parse(curDateOfBirth), Sex = curSex, Zipcode = curZipcode, City = curCity, Street = curStreet, HouseNumber = curHouseNumber, ApartmentNumber = curApartmentNumber };
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
                StreamWriter sw = new StreamWriter("lastaddperson.xml");
                xmlSerializer.Serialize(sw, person);
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();

            //SER
            try
            {
                List<Person> listPersons = new List<Person>();

                try
                {
                    XmlSerializer xmlSerializerr = new XmlSerializer(typeof(List<Person>));
                    StreamReader sr = new StreamReader("listperson.xml");
                    List<Person> listperson = (List<Person>)xmlSerializerr.Deserialize(sr);
                    foreach (Person person in listperson)
                    {                      
                        listPersons.Add(new Person { Name = person.Name, Surname = person.Surname, DateOfBirth = person.DateOfBirth, Sex = person.Sex, Zipcode = person.Zipcode, City = person.City, Street = person.Street, HouseNumber = person.HouseNumber, ApartmentNumber = person.ApartmentNumber });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                listPersons.Add(new Person { Name = curName, Surname = curSurname, DateOfBirth = DateTime.Parse(curDateOfBirth), Sex = curSex, Zipcode = curZipcode, City = curCity, Street = curStreet, HouseNumber = curHouseNumber, ApartmentNumber = curApartmentNumber });
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
                StreamWriter sw = new StreamWriter("listpersoncookies.xml");
                xmlSerializer.Serialize(sw, listPersons);
                sw.Close();
                Console.WriteLine("Udało się");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        static void ModifyPerson(string word, string word2)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
                StreamReader sr = new StreamReader("listperson.xml");
                List<Person> listperson = (List<Person>)xmlSerializer.Deserialize(sr);
                Console.WriteLine("Rejestr osób - lista");
                foreach (Person person in listperson)
                {
                    if (person.Name.ToUpper() == word.ToUpper() && person.Surname.ToUpper() == word2.ToUpper())
                    {
                        q = person.Name;
                        w = person.Surname;
                        d = person.DateOfBirth;
                        a = person.Sex;
                        e = person.Zipcode;
                        r = person.City;
                        t = person.Street;
                        y = person.HouseNumber;
                        u = person.ApartmentNumber;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // DESERIUALIZACJA ZACZYT, DESERIALIZACJA I SERIALIZACJA Z DODATKIEM
            Console.Clear();
            Console.WriteLine("Aktualne imie: " + q);
            Console.WriteLine("Podaj nowe imię: ");
            string curName = Console.ReadLine();
            Console.WriteLine("Aktualne nazwisko: " + w);
            Console.WriteLine("Podaj nowe naziwsko: ");
            string curSurname = Console.ReadLine();
            Console.WriteLine("Aktualna data urodzenia: " + d);
            Console.WriteLine("Podaj nową datę urodzenia (YYYY-MM-DD): ");
            string curDateOfBirth = Console.ReadLine();
            Console.WriteLine("Aktualna płeć: " + ManWoman(a));
            Console.WriteLine("Podaj nową płeć (1 - Mężczyzna, 2 - Kobieta: ");
            string stringcurSex = Console.ReadLine();
            int curSex = int.Parse(stringcurSex);
            Console.WriteLine("Aktualny kod pocztowy: " + e);
            Console.WriteLine("Podaj nowy kod pocztowy: ");
            string curZipcode = Console.ReadLine();
            Console.WriteLine("Aktualne miasto: " + r);
            Console.WriteLine("Podaj nowy miasto: ");
            string curCity = Console.ReadLine();
            Console.WriteLine("Aktualną ulicę: " + t);
            Console.WriteLine("Podaj nowy ulicę: ");
            string curStreet = Console.ReadLine();
            Console.WriteLine("Aktualny numer domu: " + y);
            Console.WriteLine("Podaj nowy numer domu: ");
            string curHouseNumber = Console.ReadLine();
            Console.WriteLine("Aktualny numer mieszkania: " + u);
            Console.WriteLine("Podaj nowy numer mieszkania: ");
            string curApartmentNumber = Console.ReadLine();


            
            try
            {
                Person person = new Person { Name = q, Surname = w, DateOfBirth = DateTime.Parse(i), Sex = a, Zipcode = e, City = r, Street = t, HouseNumber = y, ApartmentNumber = u };
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
                StreamWriter sw = new StreamWriter("lastmodifyperson.xml");
                xmlSerializer.Serialize(sw, person);
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();

            //SER
            try
            {
                List<Person> listPersons = new List<Person>();

                try
                {
                    XmlSerializer xmlSerializerr = new XmlSerializer(typeof(List<Person>));
                    StreamReader sr = new StreamReader("listperson.xml");
                    List<Person> listperson = (List<Person>)xmlSerializerr.Deserialize(sr);
                    foreach (Person person in listperson)
                    {
                        if (person.Name.ToUpper() != word.ToUpper() || person.Surname.ToUpper() != word2.ToUpper())
                        {
                            listPersons.Add(new Person { Name = person.Name, Surname = person.Surname, DateOfBirth = person.DateOfBirth, Sex = person.Sex, Zipcode = person.Zipcode, City = person.City, Street = person.Street, HouseNumber = person.HouseNumber, ApartmentNumber = person.ApartmentNumber });
                        }
                    }
                        
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                listPersons.Add(new Person { Name = curName, Surname = curSurname, DateOfBirth = DateTime.Parse(curDateOfBirth), Sex = curSex, Zipcode = curZipcode, City = curCity, Street = curStreet, HouseNumber = curHouseNumber, ApartmentNumber = curApartmentNumber });
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
                StreamWriter sw = new StreamWriter("listpersoncookies.xml");
                xmlSerializer.Serialize(sw, listPersons);
                sw.Close();
                Console.WriteLine("Udało się");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        static void DeletePerson(string word, string word2)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
                StreamReader sr = new StreamReader("listperson.xml");
                List<Person> listperson = (List<Person>)xmlSerializer.Deserialize(sr);
                Console.WriteLine("Rejestr osób - lista");
                foreach (Person person in listperson)
                {
                    if (person.Name.ToUpper() == word.ToUpper() && person.Surname.ToUpper() == word2.ToUpper())
                    {
                        q = person.Name;
                        w = person.Surname;
                        d = person.DateOfBirth;
                        a = person.Sex;
                        e = person.Zipcode;
                        r = person.City;
                        t = person.Street;
                        y = person.HouseNumber;
                        u = person.ApartmentNumber;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Person person = new Person { Name = q, Surname = w, DateOfBirth = DateTime.Parse(i), Sex = a, Zipcode = e, City = r, Street = t, HouseNumber = y, ApartmentNumber = u };
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
                StreamWriter sw = new StreamWriter("lastdeleteperson.xml");
                xmlSerializer.Serialize(sw, person);
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();

            //SER
            try
            {
                List<Person> listPersons = new List<Person>();

                try
                {
                    XmlSerializer xmlSerializerr = new XmlSerializer(typeof(List<Person>));
                    StreamReader sr = new StreamReader("listperson.xml");
                    List<Person> listperson = (List<Person>)xmlSerializerr.Deserialize(sr);
                    foreach (Person person in listperson)
                    {
                        if (person.Name.ToUpper() != word.ToUpper() || person.Surname.ToUpper() != word2.ToUpper())
                        {
                            listPersons.Add(new Person { Name = person.Name, Surname = person.Surname, DateOfBirth = person.DateOfBirth, Sex = person.Sex, Zipcode = person.Zipcode, City = person.City, Street = person.Street, HouseNumber = person.HouseNumber, ApartmentNumber = person.ApartmentNumber });
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
                StreamWriter sw = new StreamWriter("listpersoncookies.xml");
                xmlSerializer.Serialize(sw, listPersons);
                sw.Close();
                Console.WriteLine("Udało się");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        private static bool MainMenu()
        {
            Cookies();
            Console.Clear();
            Console.WriteLine("Rejestr osobowy ver. 1.0\r\n");
            Console.WriteLine("Wybierz z pośród poniższych opcji:");
            Console.WriteLine("1) Wyświetl rejestr osobowy");
            Console.WriteLine("2) Wyszukaj osobę z rejestru");
            Console.WriteLine("3) Dodaj osobę do rejestru");
            Console.WriteLine("4) Modyfikuj osobę z rejestru");
            Console.WriteLine("5) Usuń osobę z rejestru");
            Console.WriteLine("6) Wyjdź z programu i zapisz");
            Console.Write("\r\nWybieram opcję nr: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ViewAll();
                    return true;
                case "2":
                    Console.WriteLine("\r\n");
                    Console.WriteLine("Słowo które chcesz wyszukać:");                  
                    string word = Console.ReadLine();
                    SearchAll(word);
                    return true;
                case "3":
                    AddPerson();
                    return true;
                case "4":
                    Console.WriteLine("Imię które chcesz zmodyfikować:");
                    string word2 = Console.ReadLine();
                    Console.WriteLine("Wyszukiwane imię: " + word2);
                    Console.WriteLine("Nazwisko które chcesz wyszukać:");
                    string word3 = Console.ReadLine();
                    Console.WriteLine("Modyfikowana osoba to: " + word2 + " " + word3);
                    ModifyPerson(word2, word3);
                    return true;
                case "5":
                    Console.WriteLine("Imię które chcesz zmodyfikować:");
                    string word4 = Console.ReadLine();
                    Console.WriteLine("Wyszukiwane imię: " + word4);
                    Console.WriteLine("Nazwisko które chcesz wyszukać:");
                    string word5 = Console.ReadLine();
                    Console.WriteLine("Usunięta osoba to: " + word4 + " " + word5);
                    DeletePerson(word4, word5);
                    return true;
                case "6":
                    return false;
                default:
                    return true;
            }
        }


        static void Main(string[] args)
        {
            // Menu 
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }
    }
}
