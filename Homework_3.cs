using System;

public class User
{
    protected Privilege userPrivilege;

    public void Authorization(Privilege privilege) => this.userPrivilege = privilege; // Установка привилегий

    public virtual void CreateOrder()
    {
        if (this.userPrivilege != null && this.userPrivilege.Code == 1) // Поставил код админа 1, а не 3 как в условии
        {
            Console.WriteLine("Order created");
        }
        else
        {
            Console.WriteLine("No Access");
        }
    }

    public virtual void DeleteOrder()
    {
        if (this.userPrivilege != null && this.userPrivilege.Code == 2) // У клиента код 2
        {
            Console.WriteLine("Order deleted");
        }
        else
        {
            Console.WriteLine("No Access");
        }
    }

    public virtual void SendOrder()
    {
        if (this.userPrivilege != null && this.userPrivilege.Code == 3) // У продавца код 3
        {
            Console.WriteLine("SendOrder is Successed");
        }
        else
        {
            Console.WriteLine("No Access");
        }
    }
}

public class Customer : User
{

}
public class Admin : User
{

}

public class Seller : User
{

}

public class Privilege(int code)
{
    public readonly int Code = code;
}

public class PrivilegeMaster
{
    public Privilege GetPrivilege(User user)
    {
        if (user is Admin) return new Privilege(1); // Поставил единичку чтобы не совпадало с продавцом
        if (user is Customer) return new Privilege(2);
        if (user is Seller) return new Privilege(3);

        return new Privilege(0);
    }
}

class Homework_3
{
    static void Main()
    {
        PrivilegeMaster master = new PrivilegeMaster();

        Customer customer = new();
        Privilege privilege = master.GetPrivilege(customer); // Уровень привелегий юзера

        customer.Authorization(privilege); // Авторизация

        customer.SendOrder();
        customer.DeleteOrder(); // В консоль вывод "No Access"
        customer.CreateOrder();

        Seller seller = new();
        privilege = master.GetPrivilege(seller);

        seller.Authorization(privilege);

        seller.SendOrder(); // В консоль вывод "SendOrder is Successed"
        seller.DeleteOrder();
        seller.CreateOrder();
    }
}