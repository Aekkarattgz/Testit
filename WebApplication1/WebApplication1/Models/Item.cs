using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public partial class Item
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ItemTypeId { get; set; }

        public string Title { get; set; } = string.Empty;

        public int Capacity { get; set; }

        public int NumberOfBeds { get; set; }

        public int NumberOfBedrooms { get; set; }

        public int NumberOfBathrooms { get; set; }

        public string ExactAddress { get; set; } = string.Empty;

        public string ApproximateAddress { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string HostRules { get; set; } = string.Empty;

        public int MinimumNights { get; set; }

        public int MaximumNights { get; set; }

        // Navigation Properties
        [JsonIgnore]
        public virtual User? User { get; set; } // Navigation property to User

        [JsonIgnore]
        public virtual ItemType? ItemType { get; set; } // Navigation property to ItemType
    }
}
