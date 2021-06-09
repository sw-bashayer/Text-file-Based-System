﻿using System;
using System.Collections.Generic;  
using System.IO;

namespace Text_file_Based_System
{
    class Teacher
     {
         public Teacher(int id, string name, string teacherClass, string section) {
             ID = id;
             Name = name;
             Class = teacherClass;
             Section = section;
         }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }

        public override string ToString()
    {
        return $"Teacher ID: {ID}, Name: {Name}, class: {Class}, section: {Section}.";
    }

     } //end Teacher class
    class Program
    {
        static List< Teacher> teacherList = new List <Teacher>();
        const string fileName = "project.txt";

        public static void CreateFile(){

            if(!File.Exists(fileName)){
                File.CreateText(fileName);
                Console.WriteLine("the file is empty! a new file created");
            }
            Console.WriteLine($"{fileName} File found!");

        }

        static void Main(string[] args)
        {
            Console.WriteLine("\nHello !");
            CreateFile();
            while(true) {
            Console.WriteLine("\nWhich service do you want? (Enter Number Only)\n1. Add a new teacher.\n2. retrieve all teachers data.\n3. retrieve teacher data by ID.\n4. retrieve teacher data by name.\n5. Update teacher data.\n6. Exit.\n");
            int serviceNum;
            bool isNemuricValue= int.TryParse(Console.ReadLine(), out serviceNum); //if it is true value is the parsed number or 0
            if (!isNemuricValue) {
                Console.WriteLine("You have to enter numeric value only");
                continue;
            }
            if (serviceNum == 6)  {
                break;
            }
            int teacherID = 0;
            Teacher teacher = null;
            string teacherName = "";
            string teacherClass = "";
            string teacherSection = "";
            switch(serviceNum)
            {
                case 1:
                Console.WriteLine("enter Teacher name:");
                teacherName = Console.ReadLine();
                Console.WriteLine("enter Teacher ID:");
                isNemuricValue = int.TryParse(Console.ReadLine(), out teacherID);
                if (!isNemuricValue) {
                    Console.WriteLine("enter numeric value only");
                    continue;
                }
                Console.WriteLine("enter Teacher class:");
                teacherClass = Console.ReadLine();
                Console.WriteLine("enter Teacher section:");
                teacherSection = Console.ReadLine();
                addTeacher(teacherID, teacherName, teacherClass, teacherSection);
                break;

                case 2:
                printAllTeachersData();
                break;

                case 3:
                Console.WriteLine("enter Teacher ID:");
                isNemuricValue= int.TryParse(Console.ReadLine(), out teacherID); //if it is true value is the parsed number or 0
                if (!isNemuricValue) {
                Console.WriteLine("You have to enter numeric value only");
                continue;
                 }
                teacher = findTeacherById(teacherID);
                if (teacher!=null)
                Console.WriteLine(teacher);
                else
                Console.WriteLine("teacher not exist");
                break;

                case 4:
                break;

                default:
                Console.WriteLine("Enter only 1 to 4.");
                break;
            }
            
            }//end while
        }// end Main method


        public static void addTeacher(int ID, string name, string teacherClass, string section) {
             Teacher teacher = new Teacher(ID, name, teacherClass, section);
             teacherList.Add(teacher);
             Console.WriteLine("Teacher added successfully! \n"+teacher);
        } // end addTeacher method
        
        public static void printAllTeachersData (){
            if(teacherList.Count==0)
            Console.WriteLine("There is no teachers yet");
            else {
                foreach(var teacher in teacherList){
                    Console.WriteLine(teacher);
                    }
                    }
        }// end printAllTeachersData method

        public static Teacher findTeacherById(int ID){
            return  teacherList.Find (x => x.ID== ID);
        }

        
    } //end Program class
}
