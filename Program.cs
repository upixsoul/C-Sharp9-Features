namespace C_Sharp9
{
    //1.- Init-only Properties
    public class User
    {
        public string Id { get; init; }
        public string Name { get; init; }
    }

    //2.- Record Types
    public record User2(string Id, string Name);

    //5.- Target-typed new Expressions
    public class UserService
    {
        private readonly List<User> _users = new(); // No need for `new List<User>()`

        public void AddUser(User user) => _users.Add(user);
    }

    //6. Covariant Return Types
    public abstract class Repository
    {
        public abstract object GetById(string id);
    }
    public class UserRepository : Repository
    {
        public override User GetById(string id) => new User { Id = id, Name = "Test" };
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to DAGG C# 9 Catalog");
            Console.WriteLine("This catalog contains examples of C# 9.0 features");
            Console.WriteLine("These features are available in .NET Core 5.0+");

            #region InitOnlyProperties
            Console.WriteLine("1.- Init-only Properties");
            Console.WriteLine("Init-only properties allow you to create immutable objects by setting properties only during object initialization.");
            var user = new User { Id = "U001", Name = "Alice" };
            Console.WriteLine($"User ID: {user.Id}, Name: {user.Name}");
            // user.Id = "U002"; // Error: Property can only be set during initialization
            Console.WriteLine("Use Case: Useful in backend APIs for creating immutable DTOs (Data Transfer Objects) to ensure data consistency when passing objects between layers.");
            #endregion

            #region RecordTypes
            Console.WriteLine();
            Console.WriteLine("2.- Record Types");
            Console.WriteLine("Allows interfaces to have default implementations, enabling API evolution without breaking existing code.");
            var user1 = new User2("U002", "Maria");
            var user2 = new User2("U003", "Alice");
            Console.WriteLine($"User ID: {user1.Id}, Name: {user1.Name}");
            Console.WriteLine($"User ID: {user2.Id}, Name: {user2.Name}");
            Console.WriteLine($"True user1 == user2 (value-based equality) {user1 == user2}"); // True (value-based equality)
            Console.WriteLine("Use Case: In backend development, records are great for modeling API responses or database entities where immutability and equality comparison are desired.");
            #endregion

            #region TopLevelStatements
            Console.WriteLine();
            Console.WriteLine("3.- Top-level Statements");
            Console.WriteLine("Top-level statements simplify console applications by removing the need for a Main method and class boilerplate");
            #endregion

            #region PatternMatchingEnhancements
            Console.WriteLine();
            Console.WriteLine("4.- Pattern Matching Enhancements");
            Console.WriteLine("C# 9 improved pattern matching with relational and logical patterns, making code more expressive.");

            Console.WriteLine(GetUserStatus(2)); // Output: New User
            #endregion

            #region TargetTypedNewExpressions
            Console.WriteLine();
            Console.WriteLine("5.- Target-typed new Expressions");
            Console.WriteLine("You can omit the type name when the type is inferred, making object creation cleaner");
            User2 user3 = new("U003", "Adolf"); // Works with records or classes
            Console.WriteLine("new(\"U003\", \"Adolf\"); // Works with records or classes");
            Console.WriteLine($"User ID: {user3.Id}, Name: {user3.Name}");
            #endregion

            #region CovariantReturnTypes
            Console.WriteLine();
            Console.WriteLine("6.- Covariant Return Types");
            Console.WriteLine("Allows a derived class to return a more specific type than the base class or interface.");
            Console.WriteLine("Use Case: In backend development, this is useful for repository patterns where derived classes return specific entity types (e.g., User instead of object).\r\n\r\n");
            #endregion
        }

        //4. Pattern Matching Enhancements
        //public static string GetUserStatus(int loginAttempts) => loginAttempts switch
        //{
        //    var x when x <= 0 => "Inactive",
        //    var x when x > 0 && x < 3 => "New User",
        //    var x when x >= 3 => "Active",
        //    _ => "Unknown"
        //};

        //4. Pattern Matching Enhancements
        public static string GetUserStatus(int loginAttempts) => loginAttempts switch
        {
            <= 0 => "Inactive",
            > 0 and < 3 => "New User",
            >= 3 and < 10 => "Active",
            _ => "Unknown"
        };

        
    }
}
