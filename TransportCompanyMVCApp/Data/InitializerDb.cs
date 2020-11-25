using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportCompanyMVCApp.Models;

namespace TransportCompanyMVCApp.Data
{
    public static class InitializerDb
    {
        private static Random random = new Random();
        private static char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();

        private static string[] types =
        {
            "Хэтчбек", "Универсал", "Минивен", "Седан", "Внедорожник", "Купе", "Кабриолет", "Пикап", "Лимузин",
            "Минифургон", "Фургон", "Суперкар", "Спорткар", "Фастбэк", "Лифтбэк", "Родстер", "Тарга"
        };

        private static string[] brands =
        {
            "Toyota", "BMW", "Honda", "Nissan", "Audi", "Peugeot", "Suzuki", 
            "Renault", "Skoda", "Mercedes-Benz", "Infiniti", "Kia", "Lexus", 
            "Volvo", "Opel", "Subaru", "Jaguar", "Mazda", "Cadillac", "Bentley", 
            "Ford", "Porsche", "Lamborghini", "Dodge", "Land Rover", 
            "Jeep", "Rolls-Royce", "Alfa Romeo" 
        };
        private static string GetRandomElement(string[] arr)
        {
            return arr[random.Next(0, arr.Length)];
        }
        private static DateTime NextDateTime()
        {
            DateTime start = new DateTime(2015, 1, 1);
            int range = (DateTime.Today - start).Days;

            return start.AddDays(random.Next(range));
        }

        private static string GetString(int minStringLength, int maxStringLength)
        {
            string result = "";

            int stringLimit = minStringLength + random.Next(maxStringLength - minStringLength);

            for (int i = 0; i < stringLimit; i++)
            {
                var stringPosition = random.Next(letters.Length);

                result += letters[stringPosition];
            }

            return result;
        }
        public static void Initialize(TransportCompanyContext db)
        {
            db.Database.EnsureCreated();

            int rows;
            int rowIndex;

            if (!db.CarBrands.Any())
            {
                rows = 500;
                rowIndex = 0;

                while (rowIndex < rows)
                {
                    CarBrand carBrand = new CarBrand
                    {
                        Name = GetRandomElement(brands),
                        Specification = GetString(6,12),
                        Description = GetString(12,13)
                    };

                    db.CarBrands.Add(carBrand);

                    rowIndex++;
                }

                db.SaveChanges();
            }

            if (!db.CarTypes.Any())
            {
                rows = 500;
                rowIndex = 0;

                while (rowIndex < rows)
                {
                    CarType carType = new CarType
                    {
                        Name = GetRandomElement(types),
                        Description = GetString(8,13)
                    };
                    db.CarTypes.Add(carType);
                    rowIndex++;
                }

                db.SaveChanges();
            }

            if (!db.Cars.Any())
            {
                rows = 20000;
                rowIndex = 0;

                int minCarBrandId = db.CarBrands.Min(x => x.Id);
                int maxCarBrandId = db.CarBrands.Max(x => x.Id);

                int minCarTypeId = db.CarTypes.Min(x => x.Id);
                int maxCarTypeId = db.CarTypes.Max(x => x.Id);

                while (rowIndex < rows)
                {
                    Car car = new Car
                    {
                        CarBrandId = random.Next(minCarBrandId, maxCarBrandId+1),
                        CarTypeId = random.Next(minCarTypeId, maxCarTypeId+1),
                        RegistrationNumber = GetString(6,7),
                        BodyNumber = GetString(3,5),
                        EngineNumber = GetString(3,5),
                        YearOfIssue = random.Next(2000, 2021),
                        DriverEmployee = GetString(4,8),
                        DateOfLastMaintenance = NextDateTime().Date,
                        Mechanic = GetString(4,8)
                    };
                    db.Cars.Add(car);
                    rowIndex++;
                }

                db.SaveChanges();
            }
        }
    }
}
