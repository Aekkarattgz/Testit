using System.Text.Json.Serialization;
using WebApplication1.Models;

public partial class User
{
    public int Id { get; set; }

    public int UserTypeId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public bool Gender { get; set; }

    public DateTime BirthDate { get; set; }

    public int FamilyCount { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    [JsonIgnore]
    public virtual UserType? UserType { get; set; }  // ทำให้เป็น nullable
}
