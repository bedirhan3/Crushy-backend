using Crushy.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crushy.Models
{
	public class Message : BaseEntity
	{
		public int Id { get; set; }

		[ForeignKey("Sender")]
		public int SenderId { get; set; } // Gönderen kullanıcı

		[ForeignKey("Receiver")]
		public int ReceiverId { get; set; } // Alıcı kullanıcı

		public string Content { get; set; } // Mesaj içeriği
		public DateTime SentAt { get; set; } // Gönderim tarihi

		public User Sender { get; set; }
		public User Receiver { get; set; }
	}
}
