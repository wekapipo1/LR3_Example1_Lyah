using System;

class Press
{
    //поля
    protected string name; //назва
    protected int copies; //тираж
    protected double price; //ціна екземпляру
    public Press()
    {    }
    public Press(string name, int copies, double price)
    {
        //конструктор
        this.name = name;
        this.copies = copies;
        this.price = price;
    }
    public void Print()
    {
        //виведення на екран
        Console.WriteLine("\nНазва: {0} Тираж: {1} Базова цiна екземпляру: {2}", name, copies, price);
    }
    public double Cost()
    {
        //вартість тиража
        return price * copies;
    }
}
class Magazine : Press
{
    //додаткове поле
    string quality; //якісіть паперу: high або low
    public Magazine(string name, int copies, double price, string quality) : base(name, copies, price) 
    { 
        //конструктор
        this.quality = quality;
    }
    public new void Print()
    {
        //виведення на екран
        base.Print(); //викликаємо метод з батьківського класу
        Console.WriteLine("Якiсть паперу: {0}", quality);
    }
    public new double Cost()
    {
        double sum = base.Cost(); //викликаємо метод з батьківського класу
        if (quality == "high") return sum * 1.1;
        else
            if (quality == "low") return sum * 0.9;
        else return sum;
    }    
}
class Book : Press
{
    //додаткові поля
    int page; //кількість сторінок
    double cover; //вартість обкладинки
    public Book(string name, int copies, double price, int page, double cover)
        : base(name, copies, price)
    {
        //конструктор
        this.page = page;
        this.cover = cover;
    }
    public new void Print()
    {
        base.Print(); //викликаємо метод з батьківського класу
        Console.WriteLine("Кiлькiсть сторiнок: {0} вартiсть обкладинки: {1} ", page, cover);
    }
    public new double Cost()
    {
        //перераховуємо суму, використовуючи поля батьківського та дочірнього класів
        return (price * page / 4.0 + cover) * copies;
    }
}
class Program
{
    static void Main(string[] args)
    {
        //об'єкт батьківського класу
        Press pr = new Press("Преса ", 1000, 3.5);
        pr.Print();
        Console.WriteLine("Вартiсть тиражу: {0} ", pr.Cost());

        //об'єкт дочірнього класу Magazine з поганим папером
        Magazine mg1 = new Magazine("Журнал 1", 1000, 3.5, "low");
        mg1.Print();
        Console.WriteLine("Вартiсть тиражу: {0} ", mg1.Cost());
        //об'єкт дочірнього класу Magazine з хорошим папером
        Magazine mg2 = new Magazine("Журнал 2", 1000, 3.5, "high");
        mg2.Print();
        Console.WriteLine("Вартiсть тиражу: {0} ", mg2.Cost());

        //об'єкт дочірнього класу Book
        Book bk = new Book("Книга", 1000, 3.5, 100, 20.5);
        bk.Print();
        Console.WriteLine("Вартiсть тиражу: {0} ", bk.Cost());
    }
}