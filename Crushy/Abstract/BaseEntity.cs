namespace Crushy.Abstract
{
	public abstract class BaseEntity
	{
		public bool IsDeleted { get; set; } = false;
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public DateTime? UpdatedAt { get; set; }
	}
}
