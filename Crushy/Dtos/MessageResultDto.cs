using Crushy.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crushy.Dtos
{
	public class MessageResultDto
	{
		public int Id { get; set; }

		public int SenderId { get; set; } 
		
		public int ReceiverId { get; set; } 

		public string Content { get; set; } 
		public DateTime SentAt { get; set; } 

	}
}
