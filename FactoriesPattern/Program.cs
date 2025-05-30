using FactoriesPattern;
using static System.Console; // using static directive

WriteLine("***Factory Method Pattern Demo.***\n");

// Create a list AnimalFactory included TigerFactory and LionFactory
List<AnimalFactory> animalFactoryList = new List<AnimalFactory>
            {
                new TigerFactory(),
                new LionFactory()
            };

foreach (var animal in animalFactoryList)
{
    animal.CreateAnimal().AboutMe();
}

ReadLine();