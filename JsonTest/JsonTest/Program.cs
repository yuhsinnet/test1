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
           class Area
            {
                public string AreaName { get; set; }
                public List<Sensor> Sensors { get; set; }

            }

        class WH
        {

 

            
            public List<Area> Areas { get; set; }

        }

        static void Main(string[] args)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,

                // 使Json 可以顯示中文
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };



            WH plj = new WH
            {
                
                Areas = new List<Area>
                {
                    new Area
                    {
                        AreaName = "A區",

                     Sensors =new List<Sensor>
                     {
                       new Sensor { Name = "濕度", Value = 85.6, unit = "%" },
                       new Sensor { Name = "溫度", Value = 32.22, unit = "℃" }
                     }
                    },
                    new Area
                    {
                        AreaName = "B區",
                        Sensors = new List<Sensor>
                        {
                            new Sensor { Name = "光度", Value = 12000, unit = "Lux" },
                            new Sensor { Name = "葉面濕度度", Value = 77.8, unit = "%" },
                            new Sensor { Name = "葉面濕度度2", Value = 85.3, unit = "%" }
                        }
                    }


                }
            };







            //Area plj = new Area
            //{
            //    AreaName = "A區",
            //    Sensors = new List<Sensor>
            //     {
            //         new Sensor { Name = "濕度", Value = 85.6, unit = "%" },
            //         new Sensor { Name = "溫度", Value = 32.22, unit = "℃" }
            //     }
            //};

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
