using System.Xml.Linq;

namespace Collections
{
    internal class Program
    {
        private List<int> myList = new List<int>(100);
        private Dictionary<string, string> phones = new Dictionary<string, string>();
        private HashSet<int> mySet = new HashSet<int>();
        private Random random = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер метода который вы бы хотели запустить" +
                "\n1 - WorkWithList" +
                "\n2 - PhoneBook" +
                "\n3 - RepeatChecker" +
                "\n4 - DataAboutUser");
            int inputNumber = int.Parse(Console.ReadLine());
           

            Program program = new Program();
            switch (inputNumber)
            {
                case 1:
                    program.WorkWithList();
                    break;
                case 2:
                    program.PhoneBook();
                    break;
                case 3:
                    program.RepeatChecker();
                    break;
                case 4:
                    program.DataAboutUser();
                    break;

                default:
                    Console.WriteLine("Метода под таким номером не обнаружено");
                    break;
            }
        }
        public void WorkWithList()
        {
            for (int i = 0; i < 100; i++)
            {
                int randomNumber = random.Next(0, 101);
                myList.Add(randomNumber);
            }
            Console.WriteLine("Случайные числа в списке:");
            foreach (var number in myList)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();
            Console.WriteLine("Случайные числа больше 25 но меньше 50");
            foreach (var number in myList)
            {
                if (number > 25 && number < 50)
                {
                    Console.WriteLine(number);
                }
            }
        }
        public void PhoneBook()
        {
            Console.WriteLine("Введите номера телефонов и ФИО владельцев.");

            Console.Write("Номер телефона: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("ФИО владельца: ");
            string ownerName = Console.ReadLine();

            phones[phoneNumber] = ownerName;

            Console.WriteLine("\nВведите номер телефона для поиска владельца:");
            string searchNumber = Console.ReadLine();

            phones.TryGetValue(searchNumber, out string searchedOwner);

            Console.WriteLine(searchedOwner);
        }
        public void RepeatChecker()
        {
            while (true)
            {
                Console.Write("Введите число: ");
                int inputNumber = int.Parse(Console.ReadLine());
                if (mySet.Contains(inputNumber))
                {
                    Console.WriteLine("Такое число уже есть");
                }
                else
                {
                    mySet.Add(inputNumber);
                    Console.WriteLine("Число добавлено");
                }

                Console.Write("Нажмите esc чтобы выйти из цикла");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }
                Console.WriteLine();
            }
        }
        public void DataAboutUser()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Console.WriteLine("Введите ФИО");
            string name = Console.ReadLine();

            Console.WriteLine("Введите улицу");
            string street = Console.ReadLine();

            Console.WriteLine("Введите номер дома");
            string houseNumber = Console.ReadLine();

            Console.WriteLine("Введите номер квартиры");
            string flatNumber = Console.ReadLine();

            Console.WriteLine("Введите мобильный телефон");
            string mobilePhone = Console.ReadLine();

            Console.WriteLine("Введите домашний телефон");
            string flatPhone = Console.ReadLine();

            XElement Person = new XElement("Person");
            XElement Adress = new XElement("Adress");
            XElement Street = new XElement("Street", street);
            XElement HouseNumber = new XElement("HouseNumber", houseNumber);
            XElement FlatNumber = new XElement("FlatNumber", flatNumber);
            XElement Phones = new XElement("Phones");
            XElement MobilePhone = new XElement("MobilePhone", mobilePhone);
            XElement FlatPhone = new XElement("FlatPhone", flatPhone);

            XAttribute PersonAttribute = new XAttribute("name", name);

            Person.Add(PersonAttribute);
            Person.Add(Adress);
            Person.Add(Phones);
            Adress.Add(Street);
            Adress.Add(HouseNumber);
            Adress.Add(FlatNumber);
            Phones.Add(MobilePhone);
            Phones.Add(FlatPhone);

            Person.Save("_person.xml");
        }
    }
}