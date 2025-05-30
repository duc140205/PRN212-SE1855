using BuilderPattern;

IBurgerBuilder builder = new BurgerBuilder();
Chef chef = new Chef(builder);

var cheeseBurger = chef.MakeCheeseBurger();
var veggieBurger = chef.MakeVeggieBurger();

Console.WriteLine(cheeseBurger);
Console.WriteLine(veggieBurger);