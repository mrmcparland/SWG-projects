using BookCheckout.Data;
using BookCheckout.Models;
using BookList.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookList.Controller
{
    public class BookController
    {
        private LibraryMenu libraryMenu;
        private BookCheckoutList bookCheckoutList;
        
        public BookController()
        {
            libraryMenu = new LibraryMenu();
            bookCheckoutList = new BookCheckoutList();
        }

        public void Run()
        {
            bool keepRunning = true;

            while(keepRunning)
            {
                int menuChoice = libraryMenu.ShowMenuAndGetUserChoice();

                switch(menuChoice)
                {
                    case 1:
                        AddBook();
                        break;
                    case 2:
                        ShowAllBooks();
                        break;
                    case 3:
                        EditSelectedBook();
                        break;
                    case 4:
                        RemoveBookFromCheckout();
                        break;
                    case 5:
                        keepRunning = false;
                        break;
                }
            }
        }

        private void AddBook()
        {
            Book newBook = libraryMenu.GetNewBookInformation();
            Book addedBook = bookCheckoutList.CreateBook(newBook);
            
            if(addedBook != null)
            {
                libraryMenu.DisplayBook(newBook);

                libraryMenu.ShowActionSuccess("Add Book");
            }
            else
            {
                libraryMenu.ShowActionFailure("Add Book");
            }
        }
        private void ShowAllBooks()
        {
            Book[] newBook = bookCheckoutList.RetrieveCheckoutSelection();
            libraryMenu.DisplayCheckoutList(newBook);
        }
        private void EditSelectedBook()
        {
            Book editBook = new Book();
            
            bookCheckoutList.EditCheckoutChoice(editBook);
            AddBook();
        }
        private void RemoveBookFromCheckout()
        {
            
            bookCheckoutList.DeleteCheckoutChoice();
           
        }
        private void ExitCheckout()
        {

        }
    }
}
