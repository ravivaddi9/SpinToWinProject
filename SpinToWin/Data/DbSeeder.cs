using Microsoft.EntityFrameworkCore;


namespace SpinWinKiosk.API.Data
{
 

        public static class DbSeeder
        {
            public static void Seed(AppDbContext context)
            {
                if (!context.Prizes.Any())
                {
                    context.Prizes.AddRange(
                        new Prize { Name = "No Prize", Weight = 50 },
                        new Prize { Name = "$5 Free Play", Weight = 25 },
                        new Prize { Name = "$10 Free Play", Weight = 15 },
                        new Prize { Name = "Food Voucher", Weight = 7 },
                        new Prize { Name = "Gift Item", Weight = 3 }
                    );
                    context.SaveChanges();
                }
            }
        }
        
}
