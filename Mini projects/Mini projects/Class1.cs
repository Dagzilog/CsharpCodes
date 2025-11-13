using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Table storage (list of students)
        List<Student> students = new List<Student>()
        {
            new Student("Alice", 20),
            new Student("Bob", 21),
            new Student("Charlie", 22)
        };

        while (true)
        {
            Console.Clear(); // refresh screen

            // Display table
            Console.WriteLine("ID\tName\tAge");
            Console.WriteLine("---------------------");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i}\t{students[i].Name}\t{students[i].Age}");
            }

            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Update student");
            Console.WriteLine("2. Add student");
            Console.WriteLine("3. Exit");
            Console.Write("Choose: ");
            string choice = Console.ReadLine();

            if (choice == "1") // Update
            {
                Console.Write("Enter ID of student to update: ");
                int id;
                if (int.TryParse(Console.ReadLine(), out id) && id >= 0 && id < students.Count)
                {
                    Console.Write("Enter new name: ");
                    students[id].Name = Console.ReadLine();

                    Console.Write("Enter new age: ");
                    if (int.TryParse(Console.ReadLine(), out int newAge))
                        students[id].Age = newAge;
                }
                else
                {
                    Console.WriteLine("Invalid ID!");
                    Console.ReadKey();
                }
            }
            else if (choice == "2") // Add
            {
                Console.Write("Enter name: ");
                string name = Console.ReadLine();

                Console.Write("Enter age: ");
                int age;
                int.TryParse(Console.ReadLine(), out age);

                students.Add(new Student(name, age));
            }
            else if (choice == "3") // Exit
            {
                break;
            }
        }
    }
}

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }
}