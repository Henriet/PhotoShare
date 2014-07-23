using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoShare.Domain
{
    public class Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] public Guid Id { get; set;}

        public Entity()
        {
            Id = Guid.NewGuid();
        }

    }
}