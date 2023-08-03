using System;

namespace LibraryCatalog 
{
    public class Library 
    {
        private string Name;
        private string Address;
        private List<Book> Books;
        private List<MediaItem> MediaItems;

        public Library(string Name, string Address, List<Book>  Books, List<MediaItem> MediaItems)
        {
            this.Name = Name;
            this.Address = Address;
            this.Books = Books;
            this.MediaItems = MediaItems;
        }   

        public  void AddBook(Book book)
        {
            Books.Add(book);
        }

        public  void RemoveBook(Book book)
        {
            if(Books.Count == 0)
            {
                Console.WriteLine("There are No Books left in this Library");
            } else {
                     
            Books.Remove(book);
            }
        }

        public  void AddMediaItem(MediaItem item)
        {
            MediaItems.Add(item);
        }

        public  void RemoveMediaItem(MediaItem item)
        {
            if (MediaItems.Count == 0){
                Console.WriteLine("There are no MediaItems left");
                
            } else
            {
                MediaItems.Remove(item);
            }
        }
        public  void PrintCatalog()
        {
            if(Books.Count == 0) {
                Console.WriteLine("There are no more books left in the library");

            }
            else {
            Console.WriteLine("Here are the books in the Library");
            foreach(Book book in Books)
            {
                Console.WriteLine($"Book Title: {book.Title} , Author: {book.Author} , ISBN: {book.ISBN}, publication Year: {book.PublicationYear}");
            }
            }
            if(MediaItems.Count == 0) {
                Console.WriteLine("There are no more Media Items left in the library");
            } else {
            Console.WriteLine();
            Console.WriteLine("Here are the Media Items in the Library");
            foreach(MediaItem mediaItem in MediaItems)
            {
                Console.WriteLine($"Media Title: {mediaItem.Title} , type: {mediaItem.MediaType} , Duration: {mediaItem.Duration}");
            }
            }  
        }
    } 
    public class Book
    {
        public string Title;
        public string Author;
        public string ISBN;
        public int PublicationYear;

        public Book(string Title, string Author, string ISBN, int PublicationYear)
        {
            this.Title = Title;
            this.Author = Author;
            this.ISBN = ISBN;
            this.PublicationYear = PublicationYear;
        }
    }

    public class MediaItem
    {
        public string Title;
        public string MediaType;
        public int Duration;
        

        public MediaItem(string Title, string MediaType, int Duration)
        {
            this.Title = Title;
            this.MediaType = MediaType;
            this.Duration = Duration;      
        }
    }

   public class LibraryCatalog
{
    static void Main(string[] args)
    {
        Book AtomicHabit = new Book(Title: "Atomic Habit", Author: "James Clear" ,ISBN: "24234", PublicationYear: 2018 );
        Book George = new Book(Title: "1984", Author: "George Orwell " ,ISBN: "12982", PublicationYear: 1949 );
        MediaItem dvd = new MediaItem(Title: "ATOMIC HABIT AUDIO BOOK", MediaType: "DVD", Duration: 50);
        Library Abrehot = new Library(Name:"Abrehot", Address: "Addis ABABA", Books: new List<Book>(), MediaItems: new List<MediaItem>());

        Abrehot.AddBook(AtomicHabit);
        Abrehot.AddBook(George);
        Abrehot.RemoveBook(George);
        // Abrehot.RemoveBook(AtomicHabit);
        // Abrehot.RemoveBook(George);
        Abrehot.AddMediaItem(dvd);
        Abrehot.PrintCatalog();
    }
}
}
