string[] bikeTypes = { "1: Standard bike", "2: City bike", "3: Plus bike", "4: Luxe bike" };

int standartBikePrice = 10;
int cityBikePrice = 20;
int plusBikePrice = 30;
int luxeBikePrice = 40;


Console.WriteLine("Choose a bike:");
Console.WriteLine();
Console.WriteLine(bikeTypes[0] + " - " + standartBikePrice + " euro");
Console.WriteLine(bikeTypes[1] + " - " + cityBikePrice + " euro");
Console.WriteLine(bikeTypes[2] + " - " + plusBikePrice + " euro");
Console.WriteLine(bikeTypes[3] + " - " + luxeBikePrice + " euro");


Console.WriteLine();


int userChoice = 0;

while (userChoice < 1 || userChoice > 4)
{
    Console.WriteLine();
    Console.Write("Enter the number of the bike you want (1-4): ");
    userChoice = Convert.ToInt32(Console.ReadLine());

    if (userChoice < 1 || userChoice > 4)
    {
        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
    }
}

int selectedBikePrice = 0;


if (userChoice == 1)
{
    selectedBikePrice = standartBikePrice;
}
else if (userChoice == 2)
{
    selectedBikePrice = cityBikePrice;
}
else if (userChoice == 3)
{
    selectedBikePrice = plusBikePrice;
}
else if (userChoice == 4)
{
    selectedBikePrice = luxeBikePrice;
}

Console.WriteLine();
Console.WriteLine("Do you want to rent additional accessories?");
Console.WriteLine("1: Rain/Sun canopy - 20 euro");
Console.WriteLine("2: Baby seat - 50 euro");
Console.WriteLine("3: Smartphone holder - 20 euro");
Console.WriteLine("4: Map holder and helmet - 20 euro");
Console.Write("Enter the number of the accessory you want to rent (0 for none): ");

int accessoryChoice = Convert.ToInt32(Console.ReadLine());

int accessoriesPrice = 0;


if (accessoryChoice == 1)
{
    accessoriesPrice += 20;
}
else if (accessoryChoice == 2)
{
    accessoriesPrice += 50;
}
else if (accessoryChoice == 3)
{
    accessoriesPrice += 20;
}
else if (accessoryChoice == 4)
{
    accessoriesPrice += 20;
}

Console.WriteLine();
Console.Write("Enter how many days you want to rent: ");

int num1 = Convert.ToInt32(Console.ReadLine());

int totalPrice = (selectedBikePrice * num1)+ accessoriesPrice;

DisplayTotalPrice(totalPrice);

static void DisplayTotalPrice(int totalPrice)
{
    Console.WriteLine("Total price: " + totalPrice + " euro");
}


Console.ReadLine();