using System;
using System.Data;
using Dapper;
using Lecture18_18._03._2021.Models;
using Lecture18_18._03._2021.Repositories;
using System.Runtime.CompilerServices;
using System.Threading;
namespace Lecture18_18._03._2021
{
    class Program
    {
        static void Main(string[] args)
        {
            var userRep = new UserRepositories();
            bool working = true;
            while (working)
            {
                Console.Clear();
                int choice;
                Console.Write("Chooce option:\n1.Create\n2.Read\n3.Update\n4.Delete\n5.Exit\nYour Choice: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            {
                                Create();
                            }
                            break;
                        case 2:
                            {
                                Console.Clear();
                                Read();
                            }
                            break;
                        case 3:
                            {
                                Console.Clear();
                                Console.Write("ID : ");
                                int tempId;
                                while (true)
                                {
                                    if (int.TryParse(Console.ReadLine(), out tempId))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Error : invalid syntax");
                                        Console.ResetColor();

                                    }
                                }
                                Update(tempId);
                            }
                            break;
                        case 4:
                            {
                                Console.Write("ID : ");
                                int tempId;
                                while (true)
                                {
                                    if (int.TryParse(Console.ReadLine(), out tempId))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Error : invalid syntax");
                                        Console.ResetColor();

                                    }
                                }
                                Delete(tempId);
                            }
                            break;
                        case 5:
                            {
                                working = false;
                            }
                            break;
                    }
                }
                PressKey();
                Console.Clear();
                Console.WriteLine("Done");
                Thread.Sleep(200);

            }
        }
        static void Create()
        {
            Console.Write("User Name : ");
            string tempName = Console.ReadLine();
            int tempAge;
            while (true)
            {
                Console.Write("User Age : ");
                if (int.TryParse(Console.ReadLine(), out tempAge))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error : invalid age number");
                    Console.ResetColor();
                }
            }
            var tempUser = new Users() { Name = tempName, Age = tempAge };
            var userRep = new UserRepositories();
            userRep.Create(tempUser);
        }
        static void Read()
        {
            var list = new UserRepositories().Select();
            Console.WriteLine("Id\t\tName\t\tAge");
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Id}\t\t{item.Name}\t\t{item.Age}");
                Thread.Sleep(100);
            }
        }
        static void Update(int Id)
        {
            Console.Write("Name: ");
            string tempName = Console.ReadLine();
            int tempAge;
            while (true)
            {
                Console.Write("User Age : ");
                if (int.TryParse(Console.ReadLine(), out tempAge))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error : invalid age number");
                    Console.ResetColor();
                }
            }
            var tempUser = new Users() { Name = tempName, Age = tempAge };
            new UserRepositories().Update(tempUser, Id);
        }
        static void Delete(int Id)
        {
            Console.Write("Are you sure to delete : y/n ");
            string userAns = Console.ReadLine();
            if (userAns.ToLower() == "y")
            {
                new UserRepositories().Delete(Id);
            }
        }

        static void PressKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
    }

