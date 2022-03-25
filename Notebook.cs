using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    /*
    * Очередное приключение в Рейд-режиме ждёт! Условия и задачи текущей стадии находятся в файле Conditions.txt.
    */

    public class Notebook
    {
        public Dictionary<int, Note> allNotes = new Dictionary<int, Note>();
        
        private static void Greetings()
        {
            Console.WriteLine("Добро пожаловать в нашу записную книжку!");
            Console.WriteLine("\t- для создания новой записи введите команду: create.");
            Console.WriteLine("\t- для просмотра записи введите команду: show.");
            Console.WriteLine("\t- для редактирования записи введите команду: edit.");
            Console.WriteLine("\t- для удаления записи введите команду: del.");
            Console.WriteLine("\t- для просмотра списка всех записей введите команду: all.");
            Console.WriteLine("\t- для выхода из программы введите команду: exit.");
        }

        private void Action()
        {
            while (true)
            {
                Greetings();
                string[] commands = new string[] { "create", "show", "edit", "del", "all", "exit" };
                Console.Write("Введите команду: ");
                string cmd = Console.ReadLine();
                while (!commands.Contains(cmd))
                {
                    Console.Clear();
                    Console.Write("Данной команды не найдено! Попробуйте ещё раз: ");
                    cmd = Console.ReadLine();
                }
                if (cmd == "create")
                {
                    CreateNote();
                }
                if (cmd == "show")
                {
                    ReadNote();
                }
                if (cmd == "edit")
                {
                    UpdateNote();
                }
                if (cmd == "del")
                {
                    DeleteNote();
                }
                if (cmd == "all")
                {
                    ShowAllNotes();
                }
                if (cmd == "exit")
                {
                    Console.WriteLine("Пока-пока!");
                    break;
                }
            }
        }

        private void CreateNote()
        {
            Note temp = new Note();
            temp.Id = allNotes.Count;
            temp.Surname = ReadUntilValidationPass("Surname");
            temp.Name = ReadUntilValidationPass("Name");
            temp.SecondName = ReadUntilValidationPass("SecondName");
            temp.Phone = ReadUntilValidationPass("Phone");
            temp.Country = ReadUntilValidationPass("Country");
            temp.DateOfBirth = ReadUntilValidationPass("DateOfBirth");
            temp.Organization = ReadUntilValidationPass("Organization");
            temp.Position = ReadUntilValidationPass("Position");
            temp.Remark = ReadUntilValidationPass("Remark");
            allNotes.Add(temp.Id,temp);
        }

        private void ReadNote()
        {
            Console.Write("Введите Id записи: ");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                if(allNotes.ContainsKey(id))
                {
                    Console.WriteLine(allNotes[id]);
                }
                else
                {
                    Console.WriteLine("Данной записи не найдено!");
                }
            }catch(Exception)
            {
                Console.WriteLine("Введен некорректный идентификатор!");
            }
        }

        private void UpdateNote()
        {
            string[] correctOptions = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "cancel" };
            Console.WriteLine("Укажите ID записи для редактирования: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Введен некорректный идентификатор!");
            }
            else if (!allNotes.ContainsKey(id))
            {
                Console.WriteLine("Данной записи не найдено!");
            }
            else
            {
                Console.WriteLine(allNotes[id].ToString());
                while (true)
                {
                    Console.WriteLine("Какое поле необходимо отредактировать?");
                    Console.WriteLine("\t1 - Фамилия\n\t2 - Имя\n\t3 - Отчество\n\t4 - Телефон\n\t5 - Страна\n\t6 - Дата рождения\n\t7 - Организация\n\t8 - Должность\n\t9 - Примечание");
                    Console.Write("Введите цифру для выбора или cancel для завершения редактирования: ");
                    string choice = Console.ReadLine();
                    while (!correctOptions.Contains(choice))
                    {
                        Console.Write("Команда не найдена! Введите ещё раз: ");
                        choice = Console.ReadLine();
                    }
                    switch (choice)
                    {
                        case "1":
                            allNotes[id].Surname = ReadUntilValidationPass("Surname");
                            break;
                        case "2":
                            allNotes[id].Name = ReadUntilValidationPass("Name");
                            break;
                        case "3":
                            allNotes[id].SecondName = ReadUntilValidationPass("SecondName");
                            break;
                        case "4":
                            allNotes[id].Phone = ReadUntilValidationPass("Phone");
                            break;
                        case "5":
                            allNotes[id].Country = ReadUntilValidationPass("Country");
                            break;
                        case "6":
                            allNotes[id].DateOfBirth = ReadUntilValidationPass("DateOfBirth");
                            break;
                        case "7":
                            allNotes[id].Organization = ReadUntilValidationPass("Organization");
                            break;
                        case "8":
                            allNotes[id].Position = ReadUntilValidationPass("Position");
                            break;
                        case "9":
                            allNotes[id].Remark = ReadUntilValidationPass("Remark");
                            break;
                        case "cancel":
                            break;

                    }
                    if (choice == "cancel")
                        break;
                    Console.Write("Поле изменено! Продолжить редактирование записи? (yes/no): ");
                    string answer = "";
                    while (true)
                    {
                        answer = Console.ReadLine();
                        if (answer == "yes")
                        {
                            Console.Clear();
                            break;
                        }
                        else if (answer == "no")
                        {
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.Write("Пожалуйста введите yes или no: ");
                        }
                    }
                    if (answer == "no")
                        break;
                }
            }
        }

        private void DeleteNote()
        {
            Console.Write("Введите Id записи для удаления: ");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                if (allNotes.ContainsKey(id))
                {
                    allNotes.Remove(id);
                    Console.WriteLine($"Запись {id} удалена!");
                }
                else
                {
                    Console.WriteLine("Данной записи не найдено!");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Введен некорректный идентификатор!");
            }
        }

        private void ShowAllNotes()
        {
            foreach(KeyValuePair<int,Note> temp in allNotes)
            {
                Console.WriteLine(temp.Value.ToShortString());
            }
        }

        private string ReadUntilValidationPass(string field)
        {
            while (true)
            {
                Console.Write($"Введите {field}: ");
                string str = Console.ReadLine();
                string error;
                if (Note.fieldsValidation[field].TryValidate(str, out error))
                {
                    if (string.IsNullOrEmpty(str))
                        return null;
                    else
                        return str;
                }
                else
                    Console.WriteLine(error);
            }

        }

        public static void Main(string[] args)
        {
            Notebook program = new Notebook();
            //program.CreateNote();
            //program.UpdateNote();
            program.Action();
        }
    }
}