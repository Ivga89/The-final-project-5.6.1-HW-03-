using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        (string name, string lastName, byte age, bool hasPet, byte petCount, string[] petNames, byte colorCount, string[] colorNames) UserData;

        Console.WriteLine("Введите имя: ");
        UserData.name = Console.ReadLine();

        Console.WriteLine("Введите фамилию: ");
        UserData.lastName = Console.ReadLine();

        Console.WriteLine("Введите возраст: ");
        UserData.age = byte.Parse(Console.ReadLine());
        CorrectInput(UserData.age);

        Console.WriteLine("Есть ли у вас питомец (да/нет): ");
        UserData.petCount = 0;
        UserData.petNames = new string[UserData.petCount];
        if (Console.ReadLine() == "да")
        {
            UserData.hasPet = true;
            Console.WriteLine("Введите количество питомцев: ");
            UserData.petCount = byte.Parse(Console.ReadLine());
            CorrectInput(UserData.petCount);
            UserData.petNames = PetNames(UserData.petCount);
        }
        else
        {
            UserData.hasPet = false;
            UserData.petCount = 0;
        }
        
        Console.WriteLine("Сколько у вас любимых цветов: ");
        UserData.colorCount = byte.Parse(Console.ReadLine());
        CorrectInput(UserData.colorCount);
        UserData.colorNames = ColorNames(UserData.colorCount);

        Console.WriteLine();
        Console.WriteLine("Допрос окончен");
        Console.WriteLine();

        PrintUserData(UserData.name, UserData.lastName, UserData.age, UserData.hasPet, UserData.petCount, UserData.petNames, UserData.colorCount, UserData.colorNames);
    }

    static string[] PetNames(byte petCount)
    {
        string[] petNames = new string[petCount];
        for (int i = 0; i < petNames.Length; i++)
        {
            Console.WriteLine("Введите кличку питомца {0}: ", (i + 1));
            petNames[i] = Console.ReadLine();
        }
        return petNames;
    }

    static string[] ColorNames(byte colorCount)
    {
        string[] colorNames = new string[colorCount];
        for (int i = 0; i < colorNames.Length; i++)
        {
            Console.WriteLine("Введите любимый цвет {0}: ", (i + 1));
            colorNames[i] = Console.ReadLine();
        }
        return colorNames;
    }

    static void PrintArray(string[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + ", ");
        }
    }

    static byte CorrectInput(byte someCount)
    {
        
        if (someCount <= 0 || someCount >= 255)
        {
            Console.WriteLine("Вы ввыели неверные данные. Повторите ввод: ");
            someCount = byte.Parse(Console.ReadLine());
        }
        return someCount;
    }

    static void PrintUserData(string name, string lastName, byte age, bool hasPet, byte petCount, string[] petNames, byte colorCount, string[] colorNames)
    {
        Console.WriteLine("Имя: {0}", name);
        Console.WriteLine("Фамилия: {0}", lastName);
        Console.WriteLine("Возраст: {0}", age);
        if (hasPet == true)
        {
            Console.WriteLine("Количество питомцев: {0}", petCount);
            PrintArray(petNames);
        }
        else Console.WriteLine("У вас нет питомцев");

        if (colorCount > 0)
        {
            Console.WriteLine("Количество любимых цветов: {0}", colorCount);
            PrintArray(colorNames);
        }
        else Console.WriteLine("Любимых цветов у вас нет");
    }
}