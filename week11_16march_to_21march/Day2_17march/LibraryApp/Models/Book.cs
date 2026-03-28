using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(200, MinimumLength = 2)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        public string Author { get; set; }

        [Range(1000, 2100, ErrorMessage = "Enter a valid year.")]
        [Display(Name = "Published Year")]
        public int PublishedYear { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        public string Genre { get; set; }
    }
}
