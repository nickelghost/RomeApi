using System;
using AutoMapper.Configuration.Conventions;

# nullable enable

namespace RomeApi.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}