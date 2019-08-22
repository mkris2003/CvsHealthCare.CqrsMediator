using System;

namespace CvsHealthCare.CqrsMediator.Application.Infrastructure.AutoMapper
{
    public sealed class Map
    {
        public Type Source { get; set; }
        public Type Destination { get; set; }
    }
}
