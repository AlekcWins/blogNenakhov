using System.ComponentModel.DataAnnotations;

namespace blogNenakhov.ViewModels.Blog
{
    public class AddNewPostViewModel
    {
        /// <summary>
        /// Заголовок
        /// </summary>
        [Required]
        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        /// <summary>
        /// Текст поста
        /// </summary>
        [Required]
        [Display(Name = "Текст поста")]
        public string Data { get; set; }
    }
}