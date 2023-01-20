namespace methodsOfFunctionality
{
    public class myMethods : ProductDAO
    {
        IMongoCollection<Entries> collection;

        MongoClient clientURL;

        public myMethods(string db, string MongoURI)
        {
            this.clientURL = new MongoClient(MongoURI);
            var database = this.clientURL.GetDatabase(db);
            this.collection = database.GetCollection<Entries>("Inventory");
        }

        public void MyDB()
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://applicationAccess:Onesecurepassword@cluster0.sjqbqvu.mongodb.net/?retryWrites=true&w=majority");
            var database = dbClient.GetDatabase("LaborationAssignment");
            var collection = database.GetCollection<BsonDocument>("Inventory");
        }

        public void ReturnToMainMenu()
        {
            Console.WriteLine("Press enter to return to the main menu");
            Console.ReadLine();
            Console.Clear();
            MainMenu();
        } //Functionung as intended

        public void MainMenu() //Functioning as intended
        {
            Console.WriteLine("Laboration MongoDB API i C# \n \n"
                    + "Ange val för den handling du vill utföra \n"
                    + "1. Create one \n"
                    + "2. Update one \n"
                    + "3. Read one \n"
                    + "4. Read all \n"
                    + "5. Delete one \n \n"
                    );
        }

        public void CreateOne() //Functioning as intended
        {
            //MongoClient dbClient = new MongoClient("mongodb+srv://applicationAccess:Onesecurepassword@cluster0.sjqbqvu.mongodb.net/?retryWrites=true&w=majority");
            //var database = dbClient.GetDatabase("LaborationAssignment");
            //var collection = database.GetCollection<BsonDocument>("Inventory");

            var documents = collection.Find(new BsonDocument()).ToList();
            var ReferenceID = documents.Count() + 1;

            Console.WriteLine("Insert properties of the entity you´d like to add \n");
            Console.WriteLine("Mata in Tillverkare");
            var userInputManufacturer = Console.ReadLine();
            Console.WriteLine("Mata in Storlek i tumm");
            var userInputSize = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Mata in produktens pris");
            var userInputPrice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Mata in antal i lager");
            var userInputQuantityinStock = Convert.ToInt32(Console.ReadLine());

            Entries products = new Entries
            {
                Manufacturer = userInputManufacturer,
                InternalDbId = ReferenceID,
                Size = userInputSize,
                Price = userInputPrice,
                QuantityInStock = userInputQuantityinStock
            };

            this.collection.InsertOne(products);

            Console.Clear();
            Console.WriteLine("Entity has been added to the database successfully");
            ReturnToMainMenu();
        }

        public void DeleteOne() //Functioning as intended
        {
            Console.Clear();

            //MongoClient dbClient = new MongoClient("mongodb+srv://applicationAccess:Onesecurepassword@cluster0.sjqbqvu.mongodb.net/?retryWrites=true&w=majority");
            //var database = dbClient.GetDatabase("LaborationAssignment");
            //var collection = database.GetCollection<BsonDocument>("Inventory");

            MyDB();

            ReadAll();

            Console.WriteLine("\n" + "Insert the Reference ID of the entity you would like to update");
            var referenceIdOfEntityToBeRemoved = Convert.ToInt32(Console.ReadLine());
            var filter = Builders<Entries>.Filter.Eq("InternalDbId", referenceIdOfEntityToBeRemoved);

            var deleteFilter =
                Builders<Entries>.Filter.Eq("InternalDbId", referenceIdOfEntityToBeRemoved);

            this.collection.DeleteOne(deleteFilter);

            Console.Clear();
            Console.WriteLine("Entity has been removed successfully");
            ReturnToMainMenu();
        }

        public void UpdateOne() // Functioniung as intended
        {
            Console.Clear();

            //MongoClient dbClient = new MongoClient("mongodb+srv://applicationAccess:Onesecurepassword@cluster0.sjqbqvu.mongodb.net/?retryWrites=true&w=majority");
            //var database = dbClient.GetDatabase("LaborationAssignment");
            //var collection = database.GetCollection<BsonDocument>("Inventory");

            MyDB();

            ReadAll();

            Console.WriteLine("Insert the Reference ID of the entity you would like to update");
            var referenceIdOfUpdatePropertyToUpdated = Convert.ToInt32(Console.ReadLine());
            var filter = Builders<Entries>.Filter.Eq("InternalDbId", referenceIdOfUpdatePropertyToUpdated);

            Console.WriteLine
                ("\n \n" + "Which property would you like to update? \n" +
                "1. Update Manufacturer \n" +
                "2. Update Size \n" +
                "3. Update Price \n" +
                "4. Update Quantity in stock \n");

            var userInputUpdateProperty = Convert.ToInt32(Console.ReadLine());

            if (userInputUpdateProperty == 1)
            {
                Console.WriteLine("\n Type the updated Manufacturer property");
                var updatedManufacturer = Console.ReadLine();
                var updatedvalue = Builders<Entries>.Update.Set("Manufacturer", updatedManufacturer);

                this.collection.UpdateOne(filter, updatedvalue);
            }
            else if (userInputUpdateProperty == 2)
            {
                Console.WriteLine("\n Type the updated value of the size property");
                var updatedSize = Convert.ToInt32(Console.ReadLine());
                var updatedvalue = Builders<Entries>.Update.Set("Size", updatedSize);

                this.collection.UpdateOne(filter, updatedvalue);
            }
            else if (userInputUpdateProperty == 3)
            {
                Console.WriteLine("\n Type the new price");
                var updatedPrice = Convert.ToInt32(Console.ReadLine());
                var updatedvalue = Builders<Entries>.Update.Set("Price", updatedPrice);

                this.collection.UpdateOne(filter, updatedvalue);
            }
            else if (userInputUpdateProperty == 4)
            {
                Console.WriteLine("\n Update Quantity in stock");
                var updateQuantityInStock = Convert.ToInt32(Console.ReadLine());
                var updatedvalue = Builders<Entries>.Update.Set("Quantity in stock", updateQuantityInStock);

                this.collection.UpdateOne(filter, updatedvalue);
            }
            else
            {
                Console.WriteLine("Input not approoved, try again");
                UpdateOne();
            }

            Console.Clear();
            Console.WriteLine("The entity has been updated");
            ReturnToMainMenu();
        }

        public void ReadOne() //"FindOne"
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://applicationAccess:Onesecurepassword@cluster0.sjqbqvu.mongodb.net/?retryWrites=true&w=majority");

            var database = dbClient.GetDatabase("LaborationAssignment");
            var collection = database.GetCollection<BsonDocument>("Inventory");

            var firstDocument = collection.Find(new BsonDocument()).FirstOrDefault();
            Console.WriteLine(firstDocument.ToString());

            ReturnToMainMenu();
        }

        public List<Entries> ReadAll() //Functioning as intended
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://applicationAccess:Onesecurepassword@cluster0.sjqbqvu.mongodb.net/?retryWrites=true&w=majority");

            var database = dbClient.GetDatabase("LaborationAssignment");
            var collection = database.GetCollection<BsonDocument>("Inventory");

            var documents = collection.Find(new BsonDocument()).ToList();

            Console.WriteLine("Entries found; " + documents.Count + "\n");

            foreach (var document in documents)
            {
                Console.WriteLine(document);
            }
            return this.collection.Find(new BsonDocument()).ToList();
        }

        //public void DeleteOne() //DISREGARD, Neglected approach
        //{
        //    MongoClient dbClient = new MongoClient("mongodb+srv://applicationAccess:Onesecurepassword@cluster0.sjqbqvu.mongodb.net/?retryWrites=true&w=majority");
        //    var database = dbClient.GetDatabase("LaborationAssignment");
        //    var collection = database.GetCollection<BsonDocument>("Inventory");

        //    Console.WriteLine("Insert properties of the entity you´d like to remove \n");
        //    Console.WriteLine("Which manufacturer does the entity have?");
        //    var InputManufacturer = Console.ReadLine();
        //    Console.WriteLine("Which monitor size does the entity have?");
        //    var InputSize = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("What price does the entity have");
        //    var InputPrice = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("How is the quantity of the product in stock");
        //    var userInputQuantityinStock = Convert.ToInt32(Console.ReadLine());

        //    var deleteFilter =
        //        Builders<Entries>.Filter.Eq("Manufacturer", InputManufacturer) &
        //        Builders<Entries>.Filter.Eq("Size", InputSize) &
        //        Builders<Entries>.Filter.Eq("Price", InputPrice) &
        //        Builders<Entries>.Filter.Eq("Quantity in stock", userInputQuantityinStock);

        //    this.collection.DeleteOne(deleteFilter);

        //    Console.Clear();
        //    Console.WriteLine("Entity has been removed successfully");
        //    ReturnToMainMenu();
        //}
    }
}
