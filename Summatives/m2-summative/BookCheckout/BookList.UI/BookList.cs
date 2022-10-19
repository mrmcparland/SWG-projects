using BookCheckout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookList.UI
{
    public class LibraryMenu
    {
        private UserIO userIO;

        public LibraryMenu()
        {
            userIO = new UserIO();
        }

        public int ShowMenuAndGetUserChoice()
        {
            Console.WriteLine("\nWelcome to your local public library!  You may check out up to five books." +
                "Please create and edit your list from the menu below: ");
            
            Console.WriteLine("1.Add Book");
            Console.WriteLine("2.Show All Books on Checkout List");
            
            Console.WriteLine("3.Edit Book Information");
            Console.WriteLine("4.Remove Book");
            Console.WriteLine("5.Exit Program");
            int userChoice = userIO.ReadInt("Enter your choice: ", 1, 5);

            return userChoice;
        }
        public Book GetNewBookInformation()
        {
            Book book = new Book();

            book.Title = userIO.ReadString("\nEnter the title of the book you'd like to check out: ");
            book.AuthorFirstName = userIO.ReadString("Enter the author's first name: ");
            book.AuthorLastName = userIO.ReadString("Enter the author's last name: ");
            book.FirstPublicationYear = userIO.ReadString("Enter the publication year: ");


            return book;

        }
        public void DisplayBook(Book book)
        {
            Console.WriteLine("\nBookID: {0}", book.BookID);
            Console.WriteLine("Title of the book: {0}", book.Title);
            Console.WriteLine("Author first name: {0}", book.AuthorFirstName);
            Console.WriteLine("Author last name: {0}", book.AuthorLastName);
            Console.WriteLine("Year published: {0}", book.FirstPublicationYear);
        }

        public void DisplayCheckoutList(Book[] books)
        {
            
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] is null)
                {
                    Console.WriteLine("You have no book selected for the number {0} slot", i + 1);
                    
                }
                else
                {
                    
                    Console.WriteLine("Book number {0} on your list is {1}, " +
                "written by {2} {3}, published {4}.", books[i].BookID + 1, books[i].Title, books[i].AuthorFirstName,
                books[i].AuthorLastName, books[i].FirstPublicationYear);
                    Console.ReadLine();
                }

            }
        }
        public void DeleteVerification(int deletedBook)
        {
            
            Book[] books = new Book[5];
            if (books[deletedBook] == null)
            {
                Console.WriteLine("Book removed from list successfully");
            }
            else
                Console.WriteLine("Book not removed succesfully");
        }


        public void ShowActionSuccess(string actionName)
        {
            Console.WriteLine("\n{0} executed successfully!", actionName);
        }
        public void ShowActionFailure(string actionName)
        {
            Console.WriteLine("\n{0} failed to execute properly!", actionName);
        }
    }
}
