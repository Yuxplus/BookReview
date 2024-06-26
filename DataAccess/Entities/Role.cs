﻿#nullable disable

// Way 1:
// namespace DataAccess.Entities;
// Way 2:
using DataAccess.Entities.Bases;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities // namespace DataAccess.Entities; can also be written
                              // therefore we don't need to use curly braces
{
    public class Role : Record
    {
        // data member and member method usage example from Java:
        // private int id; // a class variable is called as a field in C#

        // public void setId(int id) // a class method is called as a behavior in C#
        // {
        //     this.id = id;
        // }

        // public int getId()
        // {
        //     return id;
        // }



        // Way 1:
        //public int Id { get; set; } // this is called a property in C# which contains getters and setters,
        // will be primary key in the related database table

        // Way 2: Id property should be inherited from the Record abstract base class



        [Required]
        [StringLength(5, MinimumLength = 4)]
        // Required and StringLength are called C# Attributes and may be used on top of properties,
        // fields (class variables), behaviors (methods) or classes.
        // For entity and models C# Attributes are called Data Annotations and they gain new features to the
        // properties, fields, behaviors or classes by the implementation of Aspect Oriented Programming.
        public string Name { get; set; } // "String" class type can also be used, general usage "string" data type



        // class has a relationship for one to many tables relationship (Users table is the many side)
        // Way 1:
        //public IEnumerable<User> Users { get; set; }
        // Way 2:
        //public ICollection<User> Users { get; set; }
        // Way 3: since List class implements IEnumerable and ICollection interfaces, we can use List class as the type
        public List<User> Users { get; set; }
    }
}