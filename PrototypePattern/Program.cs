using PrototypePattern;

Console.WriteLine("***Prototype Pattern Demo***\n");

// Tạo đối tượng gốc
Car mustang = new Mustang("Mustang EcoBoost");
Car bentley = new Bentley("Continental GT Mulliner");

// In thông tin ban đầu
Console.WriteLine($"Car is: {mustang.ModelName}, and its base price is Rs. {mustang.BasePrice}");
Console.WriteLine($"Car is: {bentley.ModelName}, and its base price is Rs. {bentley.BasePrice}");

// Tạo bản sao
Car clonedMustang = mustang.Clone();
Car clonedBentley = bentley.Clone();

// In thông tin bản sao
Console.WriteLine("\nAfter Cloning:");
Console.WriteLine($"Cloned Car is: {clonedMustang.ModelName}, and its base price is Rs. {clonedMustang.BasePrice}");
Console.WriteLine($"Cloned Car is: {clonedBentley.ModelName}, and its base price is Rs. {clonedBentley.BasePrice}");
Car Car; // Biến tạm để chứa bản sao

Car = mustang.Clone(); // Clone từ Mustang gốc
Car.OnRoadPrice = Car.BasePrice + Car.SetAdditionalPrice();
Console.WriteLine($"Car is: {Car.ModelName}, and it's price is Rs. {Car.OnRoadPrice}");

Car = bentley.Clone(); // Clone từ Bentley gốc
Car.OnRoadPrice = Car.BasePrice + Car.SetAdditionalPrice();
Console.WriteLine($"Car is: {Car.ModelName}, and it's price is Rs. {Car.OnRoadPrice}");
