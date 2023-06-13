namespace FactoryPatternExercise2
{
    public class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            bool correctInput;

            do
            {
                Console.Clear();
                correctInput = true;

                Console.WriteLine("What database would you like to work with?");
                Console.WriteLine($"Type: sql");
                Console.WriteLine($"Type: mongo");
                Console.WriteLine($"Type: list");


                userInput = Console.ReadLine();


                if(userInput != "sql" && userInput != "mongo" && userInput != "list")
                {
                    correctInput=false;
                    Console.WriteLine($"Please pick one of the three database options");
                    Thread.Sleep(1500);
                }


            } while (!correctInput); ;

            Console.Clear();

            IDataAccess db = DataAccessFactory.GetDataAccessType(userInput);

            var Products = db.LoadData();
            db.SaveData();

            foreach (var product in Products)
            {
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Price: {product.Price}");
            }
        }
    }
}
