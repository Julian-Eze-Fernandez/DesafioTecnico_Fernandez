
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options) 
		{ 
		} 

		public DbSet<Product> Products { get; set; }
	}
}
