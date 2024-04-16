using System;

public class Money
{    
    private int gryvni;    
    private int kopiyki;
    public Money(int whole, int fractional)
    {
        this.gryvni = whole;//цілі
        this.kopiyki = fractional;//копійкі
    }
        
    public void Display()
    {
        Console.WriteLine($"Сума: {gryvni} грн. {kopiyki} копiйок");
    }
    public void SetMoney(int whole, int fractional)
    {
        this.gryvni = whole;
        this.kopiyki = fractional;
    }
    public int GetGryvni()
    {
        return gryvni;
    }
    public int GetKopiyki()
    {
        return kopiyki;
    }
}

public class Product
{
    private Money price;
    public Product(Money initialPrice)
    {
        this.price = initialPrice;
    }
    public void ZmenshuemoPrice(Money amount)//діскоунт
    {
        int newGryvni = price.GetGryvni() - amount.GetGryvni();
        int newKopiyki = price.GetKopiyki() - amount.GetKopiyki();

        //перевірка якщо копійки < 0
        if (newKopiyki < 0)
        {
            newGryvni -= 1;
            newKopiyki += 100;
        }

        // Встановлюємо нову ціну
        price.SetMoney(newGryvni, newKopiyki);
    }

    // Метод для виведення ціни на екран
    public void DisplayPrice()
    {
        Console.Write("Цiна товару: ");
        price.Display();
    }
}

// Приклад використання
class Program
{
    static void Main()
    {
        Money initialPrice = new Money(50, 75);
        Money discount = new Money(10, 45);

        Product product = new Product(initialPrice);

        product.DisplayPrice();
        // зменшуємо ціну
        product.ZmenshuemoPrice(discount);

        // показ нової ціни
        product.DisplayPrice();
    }
}
