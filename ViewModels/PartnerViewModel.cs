using System.ComponentModel.DataAnnotations;
using VjencanjeIzSnova_WebApp.Models;

namespace VjencanjeIzSnova_WebApp.ViewModels
{
	public class PartnerViewModel
	{
		//[Key]
        //public int PartnerId { get; set; }

        [Required]
		[EmailAddress]
		public string Email { get; set; } = null!;

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; } = null!;

		[Required]
		public string UserType { get; set; } = null!;

		[Required]
		public string Ime { get; set; } = null!;

		public string? Mobitel { get; set; }

		[Required]
		public int KategorijaId { get; set; }

        public IEnumerable<Kategorije> KategorijeList { get; set; } = new List<Kategorije>();
    }
}

   