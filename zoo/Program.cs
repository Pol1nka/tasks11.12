using System;
using System.Collections.Generic;

namespace zoo
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            
            //Добавление животных в зоопарк
            zoo.AddAnimal(new Sheep("sheep name"));
            zoo.AddAnimal(new List<Animal>()
            {
                new Rabbit("rabbit name1"),
                new Rabbit("rabbit name2")
            });
            zoo.AddAnimal(new Horse("horse name"));
            zoo.AddAnimal(new Horse());
            //Кормление живоных
            zoo.Feed("horse name");
            zoo.Feed();
            //Удаление животных из зоопарка
            zoo.RemoveAnimals(new List<string>()
            {
                "rabbit name2",
                "sheep name"
            });
            zoo.RemoveAnimal("horse name");
            //Вывод имен всех животных в зоопарке
            zoo.PrintAnimals(); 
            
            zoo.RemoveAnimals();

            Console.ReadLine();
        }

        public class Zoo
        {

            private List<Animal> _animals;

            public Zoo()
            {
                _animals = new List<Animal>();
            }
            
            public void AddAnimal(Animal animal)
            {
                Console.WriteLine($"A new animal named {animal.GetName()} has been added to the zoo");
                _animals.Add(animal);
            }

            public void AddAnimal(List<Animal> animals)
            {
                foreach (var animal in animals)
                {
                    Console.WriteLine($"A new animal named {animal.GetName()} has been added to the zoo");
                }
                _animals.AddRange(animals);
                
            }

            public void Feed(string name)
            {
                foreach (Animal animal in _animals)
                {
                    if (animal.GetName() == name)
                    {
                        animal.Feed();
                    }
                }
            }

            public void Feed()
            {
                foreach (Animal animal in _animals)
                {
                    animal.Feed();
                }
            }

            public void RemoveAnimal(string name)
            {
                int index = -1;

                for (int i = 0; i < _animals.Count; i++)
                {
                    if (_animals[i].GetName() == name) index = i;
                }

                if (index > -1)
                {
                    Console.WriteLine($"An animal named {_animals[index].GetName()} was taken from the zoo");
                    _animals.RemoveAt(index);
                }
            }

            public void RemoveAnimals(List<string> animals)
            {

                for (int i = 0; i < _animals.Count; i++)
                {
                    
                    int index = -1;
                    for (int j = 0; j < animals.Count; j++)
                    {
                        if (_animals[i].GetName() == animals[j]) index = i;
                    }
                    if(index >= 0)
                    {
                        _animals.RemoveAt(index);
                    }
                }
            }

            public void RemoveAnimals()
            {
                _animals.Clear();
                Console.WriteLine("The zoo is now empty");
            }

            public void PrintAnimals()
            {
                if (_animals.Count == 0)
                {
                    Console.WriteLine("The zoo is now empty");
                    return;
                }

                foreach (Animal animal in _animals)
                {
                    Console.WriteLine(animal.GetName());
                }
            }
        }

        public class Animal
        {
            protected string Name;

            public string GetName()
            {
                return Name;
            }

            protected Animal(string name)
            {
                Name = name;
            }

            protected Animal()
            {
                Name = "random name";
            }

            public virtual void Feed() {}
        }

        public class Sheep : Animal{
            public Sheep(string name) : base(name)
            {
                Name = name;
            }

            public Sheep()
            {
                Name = "Sheep without name :(";
            }

            public override void Feed()
            {
                Console.WriteLine("some implementation eating for sheep here...");
            }
        }

        public class Horse : Animal
        {
            public Horse(string name) : base(name)
            {
                Name = name;
            }
            public Horse()
            {
                Name = "Horse without name :(";
            }

            public override void Feed()
            {
                Console.WriteLine("some implementation eating for horse here...");
            }
        }

        public class Rabbit : Animal
        {
            public Rabbit(string name) : base(name)
            {
                Name = name;
            }

            public Rabbit()
            {
                Name = "Rabbit without name :(";
            }

            public override void Feed()
            {
                Console.WriteLine("some implementation eating for rabbit here...");
            }
        }
    }
}