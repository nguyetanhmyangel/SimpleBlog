using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBlog.Domain.Abstractions
{
    public abstract class AuditEntity<TId> : IAuditEntity<TId>
    {
        public TId Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateOn { get; set; }
    }

    public interface IAuditEntity<TId> : IAuditEntity, IEntity<TId>
    {
    }

    public interface IAuditEntity : IEntity
    {
        string CreatedBy { get; set; }

        DateTime CreatedOn { get; set; }

        string UpdateBy { get; set; }

        DateTime? UpdateOn { get; set; }
    }

    public abstract class Entity<TId> : IEntity<TId>
    {
        public TId Id { get; set; }
    }


    public interface IEntity<TId> : IEntity
    {
        public TId Id { get; set; }
    }

    public interface IEntity
    {
    }
}
