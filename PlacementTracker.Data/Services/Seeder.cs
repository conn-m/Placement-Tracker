
using Bogus;
using PlacementTracker.Data.Entities;

namespace PlacementTracker.Data.Services
{
    public static class Seeder
    {
        // use this class to seed the database with dummy test data using an IUserService 
        public static void Seed(IUserService svc, IJobApplicationService sja)
        {
            // seeder destroys and recreates the database - NOT to be called in production!!!
            svc.Initialise();
            sja.Initialise();

            // add users
            svc.AddUser("Administrator", "admin@mail.com", "admin", Role.admin);
            svc.AddUser("Manager", "manager@mail.com", "manager", Role.manager);
            svc.AddUser("Guest", "guest@mail.com", "guest", Role.guest);

            // add job applications
            //sja.AddJobApp("Placement Software Developer", "Submitted Application/ CV", DateTime.Today, "Kainos", "Submitted my CV to Kainos for position of software developer.", user.Id);


            // optionally add some fake users
            //var faker = new Faker();
            //for(int i=1; i<=200; i++)
            //{
            //    var s = svc.AddUser(
            //        faker.Name.FullName(),
            //        faker.Internet.Email(),
            //        "password",
            //        Role.guest
            //    );
            //}
        }
    }

}