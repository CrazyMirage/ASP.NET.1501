using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BookLibrary
{
    [Serializable]
    public class Book : IEquatable<Book>, IComparable<Book>, ISerializable
    {
        public string Author { get; private set; }
        public string Title { get; private set; } 
        public int SizePages { get; private set; }
        public string Text { get; private set; }
        public string Genre { get; private set; }

        public Book(string author, string title, string text, string genre, int sizePages)
        {
            Author = author;
            Title = title;
            Text = text;
            Genre = genre;
            SizePages = sizePages;
        }

        public Book(SerializationInfo info, StreamingContext context)
        {
            Author = info.GetString("Author");
            Title = info.GetString("Title");
            Text = info.GetString("Text");
            Genre = info.GetString("Genre");
            SizePages = info.GetInt32("Size");
        }

        public override int GetHashCode()
        {
            return Author.GetHashCode() ^ Title.GetHashCode() ^ Text.GetHashCode() ^ Genre.GetHashCode() ^ SizePages;
        }

        public override string ToString()
        {
            return "Title: \"" + Title + "\" Author: " + Author;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Book);
        }

        public bool Equals(Book other)
        {
            if (ReferenceEquals(this, other))
                return true;
            if (null == other)
                return false;
            if (this.Author == other.Author && this.Title == other.Title &&
                this.SizePages == other.SizePages && this.Text == other.Text &&
                this.Genre == other.Genre
              )
            {
                return true;
            }
            return false;
        }

        public int CompareTo(Book other)
        {
            if (Equals(other)) return 0;
            int result = Title.CompareTo(other.Title);
            if(result == 0)
                result = Author.CompareTo(other.Author);
            return result;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Author", Author);
            info.AddValue("Title", Title);
            info.AddValue("Size", SizePages);
            info.AddValue("Text", Text);
            info.AddValue("Genre", Genre);
        }
    }
}
