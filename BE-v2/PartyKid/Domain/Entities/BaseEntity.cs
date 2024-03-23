using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PartyKid;

public class BaseEntity<TKey> where TKey : IEquatable<TKey>
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public TKey Id { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsDeleted { get; set; } = false;
}

public class BaseEntity : BaseEntity<int>
{
    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(1000)]
    public string Description { get; set; }
}
