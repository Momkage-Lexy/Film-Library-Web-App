using System.ComponentModel.DataAnnotations;
namespace FinalProject.Models{
    public class Account
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }
        public string Icon { get; set; }

        public List<string> Favorites { get; set; }

        public override string ToString()
        {
            return $"Hello, {UserName}";
        }
    }
}