public interface IUser
{
    bool IsBlocked { get; set; }
    void Login();
    void Logout();
}

public abstract class AUser : IUser
{
    public bool IsBlocked { get; set; }

    public abstract void Login();
    public abstract void Logout();

    public virtual bool SendMessage(IUser user, string text)
    {
        if (!IsBlocked)
        {
            Console.WriteLine($"Message sent to {user.GetType().Name}: {text}");
            return true;
        }
        return false;
    }

    public static Type[] GetAllKindOfUsers()
    {
        return new Type[] { typeof(Admin), typeof(Customer) };
    }
}

public class Admin : AUser
{
    public override void Login() { }
    public override void Logout() { }

    public bool BlockUser(IUser user)
    {
        if (user != null && !user.IsBlocked)
        {
            user.IsBlocked = true;
            Console.WriteLine($"{user.GetType().Name} is now blocked.");
            return true;
        }
        return false;
    }
}

public class Customer : AUser
{
    public override void Login() { }
    public override void Logout() { }

    public override bool SendMessage(IUser user, string text)
    {
        if (user is Admin && !IsBlocked)
        {
            return base.SendMessage(user, text);
        }
        Console.WriteLine("Customers can't send messages to other customers.");
        return false;
    }

    public Order CreateOrder()
    {
        if (!IsBlocked)
        {
            Console.WriteLine("Order created.");
            return new Order();
        }

        Console.WriteLine("Order not created, user is blocked.");
        return null;
    }
}

public class Order
{
    public static int orderCount;
    public int OrderId { get; private set; }

    public Order()
    {
        OrderId = ++orderCount;
    }
}

class Homework_4
{
    static void Main(string[] args)
    {
        foreach (var userType in AUser.GetAllKindOfUsers())
        {
            Console.WriteLine(userType.Name);
        }

        Admin admin = new Admin();
        Customer customer1 = new Customer();
        Customer customer2 = new Customer();

        Order order1 = customer1.CreateOrder();

        bool success = customer1.SendMessage(admin, "help me"); // success = true
        success = customer1.SendMessage(customer2, "hi"); // success = false

        success = admin.BlockUser(customer1); // success = true, customer1.IsBlocked = true

        Order order2 = customer1.CreateOrder(); // order = null

        Order order3 = customer2.CreateOrder(); // order = new Order();

        Console.WriteLine($"Всего заказов: {Order.orderCount}");
    }
}
