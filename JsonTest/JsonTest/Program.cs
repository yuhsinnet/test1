using System;
using System.Collections.Generic;
using System.Text.Json;

namespace JsonTest
{
    class Program
    {
        class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }


        class Sensor
        {
            public Sensor()
            {

            }
            public Sensor(string Name, double Value, string unit)
            {
                this.Name = Name;
                this.Value = Value;
                this.unit = unit;
            }

            public string Name { get; set; }
            public double Value { get; set; }
            public string unit { get; set; }

        }
        class Wh
        {
            public string Area { get; set; }
            public List<Sensor> Sensors { get; set; }

        }

        static void Main(string[] args)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            Wh plj = new Wh
            {
                Area = "A",
                Sensors = new List<Sensor>
                 {
                     new Sensor { Name = "Hygrometer", Value = 85.6, unit = "%" },
                     new Sensor { Name = "thermometer", Value = 32.22, unit = "℃" }
                 }
            };

            var WHJson = JsonSerializer.Serialize(plj, options);


            Console.WriteLine(WHJson);

            #region stop    
            /*
            Console.WriteLine(); Console.WriteLine();

            List<Sensor> sensors = new List<Sensor>
            {
                new Sensor { Name = "溫度計", Value = 32.22, unit = "℃" },
                new Sensor { Name = "溼度計", Value = 85.6, unit = "%" }
            };

            string testjson = JsonSerializer.Serialize(sensors, options);
            Console.WriteLine(testjson);


            var student = new Student
            {
                Name = "Poy Chang",
                Age = 20
            };



            var json = JsonSerializer.Serialize<Student>(student, options);

            Console.WriteLine(json);



            Console.WriteLine("Hello World!");
            //Console.ReadLine();
            */

                #endregion
        }
    }
}
