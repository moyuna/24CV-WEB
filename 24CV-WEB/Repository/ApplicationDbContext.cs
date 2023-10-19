using _24CV_WEB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _24CV_WEB.Repository
{
	public class ApplicationDbContext : IdentityDbContext<IdentityUser>
	{
		public virtual DbSet<Curriculum> Curriculums { get;set; }	

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}
