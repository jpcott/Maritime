using FluentNHibernate.Mapping;
using Maritime.Repository.Model;

namespace Maritime.Repository.Map
{
    public class RandomNumberMap : ClassMap<RandomNumber>
    {
        public RandomNumberMap()
        {
            Id(c => c.Id).Column("Id").GeneratedBy.Identity();
            Map(c => c.Number).Column("Number").Not.Nullable();
        }
    }
}
