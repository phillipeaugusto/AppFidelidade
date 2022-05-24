using System;

namespace AppFidelidade.Domain.Dto.Shared;

public class Dto<TSource, TDestiny>: DtoBase<TSource, TDestiny>
{
    public Guid Id { get; set;}
    public char Status { get; set; }
    public DateTime DateCreation { get; set; }
    public DateTime DateChange { get; set; }
}