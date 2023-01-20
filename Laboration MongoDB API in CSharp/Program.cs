var myMongoClientURL = new MongoClient
    ("mongodb+srv://applicationAccess:Onesecurepassword@cluster0.sjqbqvu.mongodb.net/?retryWrites=true&w=majority");
var myMethods = new myMethods("LaborationAssignment", "mongodb+srv://applicationAccess:Onesecurepassword@cluster0.sjqbqvu.mongodb.net/?retryWrites=true&w=majority");

MongoClient dbClient = myMongoClientURL;

var dbList = dbClient.ListDatabases().ToList();



Console.WriteLine("The list of databases on this server is: ");
foreach (var db in dbList)
{
    Console.WriteLine(db);
}

myMethods.MainMenu();
int userInputMainMenu = Convert.ToInt32(Console.ReadLine());

if (userInputMainMenu == 1)
{
    myMethods.CreateOne();
}
else if (userInputMainMenu == 2)
{
    myMethods.UpdateOne();
}
else if (userInputMainMenu == 3)
{
    myMethods.ReadOne();
}
else if (userInputMainMenu == 4)
{
    myMethods.ReadAll();
}
else if (userInputMainMenu == 5)
{
    myMethods.DeleteOne();
}