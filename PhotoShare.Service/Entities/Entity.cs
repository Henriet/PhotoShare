using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoShare.Service.Entities
{
    /// <summary>
    ///     папка для ef. папка для доменной модели (сущностей). папка репозиториев.//todo
    /// </summary>
    /// todo: [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public class Entity
    {
        [NotMapped]public static int Index;
        [Key] public  int Id { get; set;}

        public Entity()
        {
            Index++;
            Id = Index;
        }

        //todo increment id
    }
}