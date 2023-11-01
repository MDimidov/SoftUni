using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using P01_HospitalDatabase.Data;
using P01_HospitalDatabase.Data.Models;
using System.Text;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using P01_HospitalDatabase.Data.Common;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System;

namespace P01_HospitalDatabase;

public class StartUp
{
    static void Main(string[] args)
    {
        HospitalContext context = new HospitalContext();

        while (true)
        {
            Console.Clear(); // Изчистваме конзолата при всяка итерация

            Console.WriteLine("Изберете опция:");
            Console.WriteLine("1. Добави запис");
            Console.WriteLine("2. Изтрий запис");
            Console.WriteLine("3. Прегледай запис");
            Console.WriteLine("4. Изход");

            Console.Write("Въведете номер на опцията: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Логика за добавяне на запис
                    Console.WriteLine("Избрахте опция 1.");
                    Type table = ChooseTableToSelectInfo(context);
                    Console.WriteLine(InsertIntoSelectedTable(context, table));
                    break;

                case "2":
                    // Логика за изтриване на запис
                    Console.WriteLine("Избрахте опция 2.");
                    table = ChooseTableToSelectInfo(context);
                    Console.WriteLine(DeleteRowFromTable(context, table));
                    break;

                case "3":
                    // Логика за преглед на запис
                    Console.WriteLine("Избрахте опция 3.");
                    // Тук може да добавите код за извличане и извеждане на запис от базата данни
                    table = ChooseTableToSelectInfo(context);
                    Console.WriteLine(ShowAllDataFromTable(context, table));
                    //Console.WriteLine(GetDataFromTable(context, table));
                    break;

                case "4":
                    Console.WriteLine("Изход.");
                    return; // Излизаме от приложението

                default:
                    Console.WriteLine("Невалиден избор. Моля, изберете отново.");
                    break;
            }

            Console.WriteLine("Натиснете Enter, за да продължите...");
            Console.ReadLine();
        }


    }

    private static Type ChooseTableToSelectInfo(HospitalContext context)
    {
        string namespaceToSearch = "P01_HospitalDatabase.Data.Models"; // Пространството на имена, което искате да изследвате

        //Извличане на асемблитата
        Assembly[] assemblies = AppDomain
            .CurrentDomain
            .GetAssemblies();

        //Създаване на речник за да се избира таблица от клавиатурата
        Dictionary<int, Type> numOfTable = new();

        //Попълване на речника numOfTable
        GetAllTables(namespaceToSearch, assemblies, numOfTable);

        Console.WriteLine("Изберете вашата таблица: ");

        //Разпечатване на таблиците
        foreach (var (num, table) in numOfTable)
        {
            Console.WriteLine($"[{num}] - {table.Name}");
        }

        //Извличане на правилна таблица от клавиатурата
        ConsoleKeyInfo key = Console.ReadKey();
        while (!numOfTable.ContainsKey((int)key.Key - 48))
        {
            Console.WriteLine($"\nИзбраният от вас клавиш: [{key.Key}] е невалиден\n"); //Съобщение за грешка
            key = Console.ReadKey();
        }

        Type choosenTable = numOfTable[(int)key.Key - 48];
        Console.WriteLine($"\nВие избрахте таблицата {choosenTable.Name}");

        return choosenTable;
    }

    private static void GetAllTables(string namespaceToSearch, Assembly[] assemblies, Dictionary<int, Type> numOfTable)
    {
        int counter = 1;

        foreach (var assembly in assemblies)
        {
            var typesInNamespace = assembly.GetTypes()
                .Where(type => type.Namespace == namespaceToSearch)
                .ToList();

            foreach (var type in typesInNamespace)
            {
                numOfTable.Add(counter++, type);
            }
        }
    }

    private static string InsertIntoSelectedTable(HospitalContext context, Type table)
    {

        IOrderedEnumerable<IProperty> properties = GetProperties(context, table);

        // Обекта приема типа на таблицата
        object? obj = Activator.CreateInstance(table);

        Console.WriteLine($"Въведете данни за таблицата {table.Name}:");

        // Връщаме попълнената Таблица
        obj = ReturnFilledTable(table, properties, obj);

        // Добавяме таблицата в базата данни
        context.Add(obj);

        // Изпълняваме промените
        context.SaveChanges();

        Console.WriteLine($"Успешно въвеедохте данни в таблицата '{table.Name}'");
        return table.Name;
    }

    private static object ReturnFilledTable(Type table, IOrderedEnumerable<IProperty> properties, object? obj)
    {
        // Създаваме брояч за да визуализираме поредицата от номера и колони 
        int counter = 1;
        foreach (IProperty property in properties)
        {
            if (property.Name == $"{table.Name}Id")
            {
                continue;
            }

            // Отпечтваме пропърти за което трябва да добавим стойност
            Console.Write($"{counter++}. {property.Name}: ");

            // Вземаме информация за избраното пропърти
            PropertyInfo? propertyInfo = table.GetProperty(property.Name);

            // Добавяне на стойност на пропътито ако може да се Парсне
            obj = AddValueIfPropertyExist(obj, property, propertyInfo);

        }

        return obj!;
    }

    private static IOrderedEnumerable<IProperty> GetProperties(HospitalContext context, Type table)
    {
        // Извличаме модела на таблицата от контекста на базата данни
        var tableModel = context.Model.FindEntityType(table);

        // Намерете всички несенчести пропъртита
        return tableModel!
            .GetProperties()
            .Where(p => !p.IsShadowProperty())
            .OrderBy(p => p.PropertyInfo?.GetCustomAttribute<OrderAttribute>()?.Order ?? int.MaxValue);
    }

    private static object AddValueIfPropertyExist(object? obj, IProperty property, PropertyInfo? propertyInfo)
    {

        // Извличаме типа на текущото пропърти
        Type type = property.ClrType;

        // Проверяваме дали пропъртито съществува
        if (propertyInfo != null)
        {
            // Създаваме променлива за новата стойност
            string? newRead;
            while (true)
            {
                // Проверяваме дали е възможен записа към това пропърти, ако е го записваме и продължаваме
                if (TryParseValue(newRead = Console.ReadLine(), type, out object? parsedValue))
                {
                    propertyInfo.SetValue(obj, parsedValue);
                    break;
                }

                // ако не е изписваме грешка и пробваме наново
                Console.WriteLine($"Невалидна стойност. Моля въведете стойност от тип: {type.Name}.");
            }
        }

        return obj!;
    }

    private static bool TryParseValue(string value, Type type, out object? result)
    {
        result = null;

        if (type == typeof(string))
        {
            result = value;
            return true;
        }
        else if (type.IsEnum)
        {
            if (Enum.TryParse(type, value, out var enumValue))
            {
                result = enumValue;
                return true;
            }
        }
        else if (type == typeof(int))
        {
            if (int.TryParse(value, out var intValue))
            {
                result = intValue;
                return true;
            }
        }
        else if (type == typeof(double))
        {
            if (double.TryParse(value, out var doubleValue))
            {
                result = doubleValue;
                return true;
            }
        }
        else if (type == typeof(decimal))
        {
            if (decimal.TryParse(value, out var decimalValue))
            {
                result = decimalValue;
                return true;
            }
        }
        else if (type == typeof(bool))
        {
            if (bool.TryParse(value, out var boolValue))
            {
                result = boolValue;
                return true;
            }
        }
        else if (type == typeof(byte))
        {
            if (byte.TryParse(value, out var byteValue))
            {
                result = byteValue;
                return true;
            }
        }

        return false;
    }


    public static string ShowAllDataFromTable(HospitalContext context, Type table)
    {
        IOrderedEnumerable<IProperty> properties = GetProperties(context, table);
        int co = properties.Count();


        // Обекта приема типа на таблицата
        object? obj = Activator.CreateInstance(table);

        string[,]? array = ArrayConfiguration(properties, table, obj, context);

        StringBuilder sb = new StringBuilder();

        for (int row = 0; row < array.GetLength(0); row++)
        {
            for (int col = 0; col < array.GetLength(1); col++)
            {
                sb.Append(array[row, col] + String.Concat(Enumerable.Repeat(' ', Console.WindowWidth / co - array[row, col].Length)));
            }
            sb.AppendLine();
        }

        return sb.ToString().TrimEnd();
    }

    private static string[,] ArrayConfiguration(IOrderedEnumerable<IProperty> properties, Type table, object? obj, HospitalContext context)
    {
        int row = 0;
        int col = 0;
        string[,] array = new string[properties.Count() + 1, properties.Count()];

        array = GetTableInfo(context, table, array);

        foreach (IProperty property in properties)
        {
            string propName = property.Name;
            if (propName.Substring(propName.Length - 2) == "Id")
            {
                propName = propName.Substring(0, propName.Length - 2);
            }

            array[row, col++] = propName;
        }

        return array;
    }

    public static string[,] GetTableInfo(HospitalContext context, Type tableType, string[,] array)
    {

        if (tableType.Name == nameof(Patient))
        {
            return GetPatients(context, array);
        }
        else if (tableType.Name == nameof(Diagnose))
        {
            return GetDiagnoses(context, array);

        }
        else if (tableType.Name == nameof(Doctor))
        {
            return GetDoctors(context, array);

        }
        else if (tableType.Name == nameof(Medicament))
        {
            return GetMedicaments(context, array);
        }
        else if (tableType.Name == nameof(PatientMedicament))
        {
            return GetPrescriptions(context, array);
        }
        else
        {
            return GetVisitations(context, array);
        }

    }

    private static string[,] GetVisitations(HospitalContext context, string[,] array)
    {
        var patients = context.Visitations
                    .AsNoTracking()
                    .ToArray();

        string[,] array2 = new string[patients.Length + 1, array.GetLength(1)];


        int row = 1;
        int col = 0;
        foreach (var p in patients)
        {
            array2[row, col++] = p.VisitationId.ToString();
            array2[row, col++] = p.Date.ToString();
            array2[row, col++] = p.Comments == null ? String.Empty : p.Comments;
            array2[row, col++] = p.Doctor.Name;
            array2[row, col++] = p.Patient.FirstName + " " + p.Patient.LastName;
            row++;
            col = 0;
        }

        return array2;
    }

    private static string[,] GetPrescriptions(HospitalContext context, string[,] array)
    {
        var patients = context.Prescriptions
                                            .AsNoTracking()
                                            .ToArray();

        string[,] array2 = new string[patients.Length + 1, array.GetLength(1)];

        int row = 1;
        int col = 0;
        foreach (var p in patients)
        {
            array2[row, col++] = p.Patient.FirstName + " " + p.Patient.LastName;
            array2[row, col++] = p.Medicament.Name;
            row++;
            col = 0;
        }

        return array2;
    }

    private static string[,] GetMedicaments(HospitalContext context, string[,] array)
    {
        var patients = context.Medicament
                                    .AsNoTracking()
                                    .ToArray();

        string[,] array2 = new string[patients.Length + 1, array.GetLength(1)];

        int row = 1;
        int col = 0;
        foreach (var p in patients)
        {
            array2[row, col++] = p.MedicamentId.ToString();
            array2[row, col++] = p.Name;
            row++;
            col = 0;
        }

        return array2;
    }

    private static string[,] GetDoctors(HospitalContext context, string[,] array)
    {
        var patients = context.Doctor
                            .AsNoTracking()
                            .ToArray();

        string[,] array2 = new string[patients.Length + 1, array.GetLength(1)];

        int row = 1;
        int col = 0;
        foreach (var p in patients)
        {
            array2[row, col++] = p.DoctorId.ToString();
            array2[row, col++] = p.Name;
            array2[row, col++] = p.Speciality;
            row++;
            col = 0;
        }

        return array2;
    }

    private static string[,] GetDiagnoses(HospitalContext context, string[,] array)
    {
        var patients = context.Diagnose
                    .AsNoTracking()
                    .ToArray();

        string[,] array2 = new string[patients.Length + 1, array.GetLength(1)];


        int row = 1;
        int col = 0;
        foreach (var p in patients)
        {
            array2[row, col++] = p.DiagnoseId.ToString();
            array2[row, col++] = p.Name;
            array2[row, col++] = p.Comments == null ? String.Empty : p.Comments;
            array2[row, col++] = p.Patient.FirstName + " " + p.Patient.LastName;
            row++;
            col = 0;
        }

        return array2;
    }

    private static string[,] GetPatients(HospitalContext context, string[,] array)
    {
        var patients = context.Patients
            .AsNoTracking()
            .ToArray();

        string[,] array2 = new string[patients.Length + 1, array.GetLength(1)];

        int row = 1;
        int col = 0;
        foreach (var p in patients)
        {
            array2[row, col++] = p.PatientId.ToString();
            array2[row, col++] = p.FirstName;
            array2[row, col++] = p.LastName;
            array2[row, col++] = p.Address;
            array2[row, col++] = p.Email;
            array2[row, col++] = p.HasInsurance.ToString();
            row++;
            col = 0;
        }

        return array2;
    }

    private static string DeleteRowFromTable(HospitalContext context, Type tableType)
    {
        Console.WriteLine(ShowAllDataFromTable(context, tableType));


        if (tableType.Name == nameof(Patient))
        {
            return DeletePatient(context);
        }
        //else if (tableType.Name == nameof(Diagnose))
        //{
        //    return GetDiagnoses(context, array);

        //}
        //else if (tableType.Name == nameof(Doctor))
        //{
        //    return GetDoctors(context, array);

        //}
        //else if (tableType.Name == nameof(Medicament))
        //{
        //    return GetMedicaments(context, array);
        //}
        //else if (tableType.Name == nameof(PatientMedicament))
        //{
        //    return GetPrescriptions(context, array);
        //}
        //else if (tableType.Name == nameof(Visitation))
        //{
        //    return GetVisitations(context, array);
        //}

        return "";
    }

    public static string DeletePatient(HospitalContext context)
    {
        Console.WriteLine();
        Console.Write($"Въведете ID на записа който желаете да изтриете: ");

        string? value;
        int id = 0;
        while (true)
        {
            if (int.TryParse(value = Console.ReadLine(), out var intValue))
            {
                id = intValue;
                break;
            }

            Console.Write($"Въведеният от вас ID: {value} е невалиден моля опитайте отново: ");
        }

        var patient = context.Patients
            .Find(id);
        if (patient != null)
        {
            context.Remove(patient);
            context.SaveChanges();
            return $"Успешно изтриване на пациент {patient.FirstName} {patient.LastName}";
        }

        return $"Не е открит запис с ID: {id}";
    }
}