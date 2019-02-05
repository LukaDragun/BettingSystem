using System;

namespace BettingSystem.Common.Infrastructure.Entities
{
    public class BaseEntity
    {
        private int Id { get; set; }
        private DateTime CreatedDateTime { get; set; }
        private DateTime UpdatedDateTime { get; set; }
    }
}