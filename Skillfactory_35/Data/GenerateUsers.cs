﻿using Skillfactory_35.Models.Users;

namespace Skillfactory_35.Data
{
    public class GenetateUsers
    {
        public readonly string[] maleNames = new string[] { "Василий", "Борис", "Сергей", "Александр", "Джабраил", "Хамзат", "Ибрагим", "Алексей", "Николай", "Пётр" };
        public readonly string[] femaleNames = new string[] { "Елена", "Мария", "Дарья", "Александра", "Диана", "Галина" };
        public readonly string[] lastNames = new string[] { "Пупкин", "Лосев", "Иванов", "Мохаммедов", "Крикин" };

        public List<User> Populate(int count)
        {
            var users = new List<User>();
            for (int i = 1; i < count; i++)
            {
                string firstName;
                var rand = new Random();

                var male = rand.Next(1, 2) == 1;

                var lastName = lastNames[rand.Next(0, lastNames.Length - 1)];
                if (male)
                {
                    firstName = maleNames[rand.Next(0, maleNames.Length - 1)];
                }
                else
                {
                    lastName = lastName + "a";
                    firstName = femaleNames[rand.Next(0, femaleNames.Length - 1)];
                }

                var item = new User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    BirthDate = DateTime.Now.AddDays(-rand.Next(1, (DateTime.Now - DateTime.Now.AddYears(-25)).Days)),
                    Email = "test" + rand.Next(0, 1204) + "@test.com",
                };

                item.UserName = item.Email;
                item.Image = "https://avavatar.ru/image/2305";

                users.Add(item);
            }

            return users;
        }
    }
}