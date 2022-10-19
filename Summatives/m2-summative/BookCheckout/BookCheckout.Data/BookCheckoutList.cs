using BookCheckout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCheckout.Data
{
    public class BookCheckoutList 
    {
        Book[] books;

        public BookCheckoutList()
        {
            books = new Book[5];
        }

        public Book CreateBook(Book book)
        {
            for (int i = 0; i<books.Length; i++)
            {
                if(books[i] == null)
                {
                    book.BookID = i;
                    books[i] = book;
                    return book;
                }
            }
            return null;
        }
        public Book[] RetrieveCheckoutSelection()
        {
            return books;
        }
        public Book RetrieveBookByID(int bookID)
        {
            return books[bookID];
        }
        public void DeleteCheckoutChoice()
        {
            Console.WriteLine("Enter the Book ID you'd like to remove from your checkout list.");
            int deleteBook = Convert.ToInt32(Console.ReadLine());
            books[deleteBook] = null;
            

        }
        public void EditCheckoutChoice(Book book)
        {
            Console.WriteLine("Enter the Book ID you'd like to edit on the list: ");
            int editID = Convert.ToInt32(Console.ReadLine());
            book.BookID = editID;
            books[editID] = null; 
        }
    }
}
