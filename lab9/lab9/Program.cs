using lab7;
using System;
using System.Diagnostics;

namespace laboratory_work7
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            Console.WriteLine(student.ToShortString());
            Console.WriteLine(Education.Specialist + " " + Education.Вachelor + " " + Education.SecondEducation);
            
            student.Person = new Person("Adel", "Galimov", new DateTime(2004, 09, 14));
            student.Education = Education.Вachelor;
            student.Group = 2;

            student.Exams = new Exam[3]
            {
                new Exam("c#", 4, DateTime.Now),
                new Exam("math", 5, DateTime.Now),
                new Exam("data base", 5, DateTime.Now),
            };
            
            Console.WriteLine(student.ToString());

            int nrows, ncolumns;
            Console.Write("n:");
            nrows = Convert.ToInt32(Console.ReadLine());
            Console.Write("m:");
            ncolumns = Convert.ToInt32(Console.ReadLine());
            
            Student[] students = new Student[nrows * ncolumns];
            Arr(ref students);
            
            Student[,] dimensionalArr = new Student[nrows, ncolumns];
            doubleArr(ref dimensionalArr, nrows, ncolumns);
            
            Student[][] steppedArray = new Student[nrows][];
            steppedArr(ref steppedArray, nrows, ncolumns);
            
            Stopwatch stopwatch = Stopwatch.StartNew();
            
            for (int i = 0; i < nrows * ncolumns; i++)
            {
                students[i].AddExams(new Exam[1]
                {
                     new Exam("Java", 5, DateTime.Now),
                }
                );

            }
            stopwatch.Stop();
            Console.WriteLine($"Одномерный массив: {stopwatch.ElapsedMilliseconds} ms");
            
            stopwatch.Restart();
            
            for (int i = 0; i < nrows; i++)
            {
                for (int j = 0; j < ncolumns; j++)
                {
                    dimensionalArr[i, j].AddExams(new Exam[1]
                    {
                     new Exam("Java", 5, DateTime.Now),
                    }
                    );
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"Двумерный массив: {stopwatch.ElapsedMilliseconds} ms");
            
            stopwatch.Restart();
            
            for (int i = 0; i < nrows; i++)
            {
                for (int j = 0; j < steppedArray[i].Length; j++)
                {
                    steppedArray[i][j].AddExams(new Exam[1]
                   {
                     new Exam("Java", 5, DateTime.Now),
                   }
                   );
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"Ступенчатый массив: {stopwatch.ElapsedMilliseconds} ms");
        }
        public static void Arr(ref Student[] students)
        {
            Random random = new Random();
            
            for (int i = 0; i < students.Length; i++)
            {
                Student student = new Student(new Person(), Education.Specialist, random.Next(1, 100));

                Exam[] exams = new Exam[3]
                {
                     new Exam("c#", 4, DateTime.Now),
                     new Exam("math", 5, DateTime.Now),
                     new Exam("data base", 5, DateTime.Now)
                };
                student.AddExams(exams);
                students[i] = student;
                //Console.WriteLine(students[i].Avg);
            }
        }
        public static void doubleArr(ref Student[,] students, int nrows, int ncolumns)
        {
            Random random = new Random();
            
            for (int i = 0; i < nrows; i++)
            {
                for (int j = 0; j < ncolumns; j++)
                {
                    Student student = new Student(new Person(), Education.Specialist, random.Next(1, 100));

                    Exam[] exams = new Exam[3]
                    {
                     new Exam("c#", 4, DateTime.Now),
                     new Exam("math", 5, DateTime.Now),
                     new Exam("data base", 5, DateTime.Now)
                    };
                    student.AddExams(exams);
                    students[i, j] = student;
                    //Console.Write(students[i, j].Avg);
                }
                //Console.WriteLine();
            }
        }
        public static void steppedArr(ref Student[][] steppedArray, int nrows, int ncolumns)
        {
            Random random = new Random();
            int total = nrows * ncolumns;
            steppedArray = new Student[nrows][];

            for (int i = 0; i < nrows; i++)
            {
                int randomColumns = random.Next(0, total);
                if (randomColumns >= total)
                {
                    randomColumns = total;
                }

                steppedArray[i] = new Student[randomColumns];
                
                for (int j = 0; j < randomColumns; j++)
                {
                    Student student = new Student(new Person(), Education.Specialist, random.Next(1, 100));

                    Exam[] exams = new Exam[3]
                    {
                     new Exam("c#", 4, DateTime.Now),
                     new Exam("math", 5, DateTime.Now),
                     new Exam("data base", 5, DateTime.Now)
                    };
                    student.AddExams(exams);
                    steppedArray[i][j] = student;
                    //Console.Write(steppedArray[i][j].Avg);
                }
                //Console.WriteLine();
                total -= randomColumns;
            }

        }
    }
}