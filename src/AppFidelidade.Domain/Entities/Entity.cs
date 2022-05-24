using System;
using AppFidelidade.Domain.Constants;

namespace AppFidelidade.Domain.Entities;

public class Entity <TSource, TDestiny, TOutPut> : EntityBase<TSource, TDestiny, TOutPut>
{
    public Entity()
    {
        Id = Guid.NewGuid();
        DateCreation = DateTime.Now;
        DateChange = DateTime.Now;
        Status = ApplicationConstants.StatusActive;
    }

    public Guid Id { get; protected set; }
    public char Status { get; set; }
    public DateTime DateCreation { get; set; }
    public DateTime DateChange { get; set; }

    public void SetId(Guid id)
    {
        Id = id;
    }
}