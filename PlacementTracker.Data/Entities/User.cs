﻿using System;
using Bogus.DataSets;
namespace PlacementTracker.Data.Entities
{
    // Add User roles relevant to your application
    public enum Role { admin, manager, guest }
    
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public DateTime Dob { get; set; } = DateTime.Now;

        // User role within application
        public Role Role { get; set; } 
    }
}
