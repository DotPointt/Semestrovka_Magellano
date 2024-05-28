using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class NFT : BaseEntity
	{
		public Guid? Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public string? Url { get; set; }
		public int? Likes { get; set; }
		public int? Price { get; set; }
		public Guid UserId { get; set; }
		public User User { get; set; }
	}
}
