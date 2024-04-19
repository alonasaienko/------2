using System;
using System.Runtime.InteropServices.Marshalling;

/* Розробка системи управління книгами у бібліотеці
Ваша програма повинна містити наступні елементи:
Створення інтерфейсу ILibraryItem, який містить методи для видачі книги, повернення книги та перевірки стану книги.
Створення класу Book, який реалізує інтерфейс ILibraryItem та містить інформацію про книгу (наприклад, назва, автор, рік видання тощо).
Побудова ієрархії класів для користувачів бібліотеки: базовий клас LibraryUser, який містить загальні властивості, та похідні класи, наприклад, Student, Teacher тощо.
Використання конструкторів для ініціалізації об'єктів класів та деструкторів для звільнення ресурсів.
Синхронний виклик методів через делегат для видачі та повернення книг.
Визначення події для сповіщення про зміну статусу книги та організація взаємодії об'єктів через цю подію.
Розробка класу винятків для обробки помилок у випадку виникнення проблем під час видачі або повернення книги. */

public delegate void SetBook<Book>(Book book);
public delegate void ReturnBook<Book>(Book book);


interface ILibraryItem
{
    public void SetBook(Book book);
    public void ReturnBook(Book book);
    public int StanBook(Book book);
}

class Book : ILibraryItem
{
    public string Name { get; set; }
    public string Autor{get;set;}
    public int Year{get;set;}
    public int stanBook{get;set;}
    public bool IsAviable{get;set;}

    public Book(string name, string autor, int year, int Stanbook, bool isAv)
    {
        Name = name;
        Autor = autor;
        Year = year;
        stanBook = Stanbook;
        IsAviable = isAv;
    }
    public override string ToString()
    {
        return $"Book: {Name}, {Autor}, {Year}, {stanBook}, {IsAviable}";
    }
    public void ReturnBook(Book book)
    {
        book.IsAviable = true;
        Console.WriteLine("Book has been returned");
    }
    public void SetBook(Book book)
    {
        if(book.IsAviable)
        {
            Console.WriteLine("Book has been seted for user");
            book.IsAviable = false;
        } else 
        {
            throw new CustomExeption("Book is not aviable");
        }
    }
    public int StanBook(Book book)
    {
        if(book.stanBook <= 1)
        {
            book.IsAviable = false;
            throw new CustomExeption("Book in BAD stan!!!!!!!!");
        }
        Console.WriteLine($"Stan book is {book.stanBook}");
        return book.stanBook;
    }
}

class LibraryUser
{
    public int Id { get; set; }
    public string Name { get; set;}

    public LibraryUser(int id, string name)
    {
        Id = id;
        Name = name;
    }
    public override string ToString()
    {
        return $"User: {Id}, {Name}";
    }
}

class Student : LibraryUser
{
    public string AcademGroup{get;set;}
    public Student(int id, string name, string academ) : base(id, name)
    {
        AcademGroup = academ;
    }
    public override string ToString()
    {
        return $"Student: {Id}, {Name}, {AcademGroup}";
    }
}

class Teacher : LibraryUser
{
    public string Spezialization{get;set;}
    public Teacher(int id, string name, string spez) : base(id, name)
    {
        Spezialization = spez;
    }
    public override string ToString()
    {
        return $"Teacher: {Id}, {Name}, {Spezialization}";
    }
}

public class CustomExeption : Exception
{
    public CustomExeption(string message) : base(message)
    {
        Console.WriteLine(message);
    }
}

class Program
{
    static void Main()
    {
        SetBook<Book>[] setter = new SetBook<Book>[10];
        ReturnBook<Book>[] getter = new ReturnBook<Book>[10];
        Book book = new Book("The Poppe War", "Rebecca Quang", 2020, 5, true);
        Book book1 = new Book("Babel", "Rebecca Quang", 2022, 4, false);
        Book book2 = new Book("Yellowface", "Rebecca Quang", 2023, 5, true);
        Console.WriteLine(book);
        try
        {
            setter[0] = book.SetBook;
            setter[1] = book.SetBook;
            setter[2] = book1.SetBook;
            getter[0] = book.ReturnBook;
            getter[1] = book1.ReturnBook;
            setter[3] = book1.ReturnBook;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
