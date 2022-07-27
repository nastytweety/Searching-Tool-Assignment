using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Searching_Tool_Assignment.Models;

namespace IdentityVote.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            

            //builder.Entity<Party>()
            //   .HasOne(e => e.Election)
            //   .WithOne()
            //   .HasForeignKey<Party>(e => e.ElectionId)
            //   .OnDelete(DeleteBehavior.Cascade);

            Seed(builder);
        }

        private void Seed(ModelBuilder builder)
        {

            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN".ToUpper() });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2", Name = "User", NormalizedName = "USER".ToUpper() });


            var hasher = new PasswordHasher<IdentityUser>();


            //Seeding the Users to AspNetUsers table
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Password = "Adm//assign",
                    PasswordHash = hasher.HashPassword(null, "Adm//assign"),
                    PhoneNumber = "6947940268",
                    FullName = "Nikos Diakos",
                    Email = "nd@nd.gr",
                }
            );

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb8",
                    UserName = "user",
                    NormalizedUserName = "USER",
                    Password = "Adm//assign",
                    PasswordHash = hasher.HashPassword(null, "Adm//assign"),
                    PhoneNumber = "6947940268",
                    FullName = "Test Tester",
                    Email = "nd@nd.gr",
                }
            );


            //Seeding the relation between our user and role to AspNetUserRoles table
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "1",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb8"
                }
            );

            //Seeding sources
            builder.Entity<Source>().HasData(
               new Source
               {
                   Id = 1,
                   Name = "Bitstamp",
                   BaseURL = "https://www.bitstamp.net/api/v2/ticker/",
                   PriceKeyword = "last",
                   DateTimeKeyword = "timestamp"
               }
           );

            //Seeding currencies
            builder.Entity<Currency>().HasData(
               new Currency
               {
                   CurrencyId = 1,
                   CurrencyName = "Bitcoin to USD",
                   Extension = "btcusd"
               }
           ); ;



        }

        public DbSet<Source> Sources { get; set; }
        public DbSet<Ticker> Tickers { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        //public DbSet<Party> Parties { get; set; }
    }
}
