using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookControllerMVC.Models
{
    public class Book
    {
        private int id;
        private string name;
        private string author;
        private string image;

        public Book()
        {
        }

        public Book(int id)
        {
            this.id = id;
        }

        public Book(string name)
        {
            this.name = name;
        }

        public Book(int id, string name, string author, string image)
        {
            this.id = id;
            this.name = name;
            this.author = author;
            this.image = image;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Author { get => author; set => author = value; }
        public string Image { get => image; set => image = value; }
    }
}