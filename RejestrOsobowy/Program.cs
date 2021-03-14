using System;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;

namespace RejestrOsobowy
{
    class Program
    {
        public static List<Person> ListOfPerson;

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

        static string ManWoman(int sex)
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

        static void DeserializeFromFile(string a_sFilePath)
        {
            ListOfPerson?.Clear();

            try
            {
                using StreamReader _oReader = new StreamReader(a_sFilePath);

                XmlSerializer _oXmlSerializer = new XmlSerializer(typeof(List<Person>));

                ListOfPerson = _oXmlSerializer.Deserialize(_oReader) as List<Person>;

                if (ListOfPerson?.Count > 0)
                    Console.WriteLine($"Wczytano {ListOfPerson.Count} osob z pliku {Path.GetFileName(a_sFilePath)}");
            }
            catch (Exception)
            {
            }

            if (ListOfPerson == null)
                ListOfPerson = new List<Person>();
        }

        static void SerializeToFile(string a_sFilePath)
        {
            if (ListOfPerson.Count > 0)
            {
                try
                {
                    using StreamWriter _oWriter = new StreamWriter(a_sFilePath);

                    XmlSerializer _oXmlSerializer = new XmlSerializer(typeof(List<Person>));

                    _oXmlSerializer.Serialize(_oWriter, ListOfPerson);

                    Console.WriteLine($"Zapisano {ListOfPerson.Count} osob do pliku {Path.GetFileName(a_sFilePath)}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Wystąpił wyjątek podczas zapisu do pliku! {e.Message}");
                }
            }
        }

        static void ViewAll()
        {
            //DESERIALIZACJA LISTY
            Console.Clear();
            try
            {
                foreach (Person person in ListOfPerson)
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
                Console.WriteLine("Rejestr osób - lista");
                Console.WriteLine("Wyszukiwane słowo: " + word);
                foreach (Person person in ListOfPerson)
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
                ListOfPerson.Add(new Person { Name = curName, Surname = curSurname, DateOfBirth = DateTime.Parse(curDateOfBirth), Sex = curSex, Zipcode = curZipcode, City = curCity, Street = curStreet, HouseNumber = curHouseNumber, ApartmentNumber = curApartmentNumber });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();

        }


        static void ModifyPerson(string word, string word2)
        {
            try
            {
                Console.WriteLine("Rejestr osób - lista");

                int _iIndex = 0;

                foreach (Person person in ListOfPerson)
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

                        ListOfPerson[_iIndex] = new Person { Name = q, Surname = w, DateOfBirth = DateTime.Parse(i), Sex = a, Zipcode = e, City = r, Street = t, HouseNumber = y, ApartmentNumber = u };

                        break;
                    }

                    _iIndex++;
                }

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
                int _iIndex = -1;

                Console.WriteLine("Rejestr osób - lista");
                foreach (Person person in ListOfPerson)
                {
                    _iIndex++;

                    if (person.Name.ToUpper() == word.ToUpper() && person.Surname.ToUpper() == word2.ToUpper())
                    {
                        break;
                    }
                }

                if (_iIndex > -1)
                    ListOfPerson.RemoveAt(_iIndex);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }



        private static bool MainMenu()
        {
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
            DeserializeFromFile("listperson.xml");

            try
            {
                while (MainMenu())
                {
                }
            }
            catch (Exception)
            {
            }

            SerializeToFile("listperson.xml");
        }
    }
}
