using Microsoft.EntityFrameworkCore;
using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class ApplicationContext : DbContext
{
    public DbSet<Product> Products { get; set; }

	public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
	{
		
	}
}
