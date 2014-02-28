using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using KidsCove.Core.Domain;

namespace KidsCove.Database.Mappings
{
    public class ChildActivityDetailMap : ClassMap<ChildActivityDetail>
    {
        public ChildActivityDetailMap()
        {
            Table("kc_child_eventdetail");
            Id(x => x.Key).Column("id");
            Map(x => x.EventDate).Column("event_date");
            Map(x => x.StartTime).Column("start_time");
            Map(x => x.EndTime).Column("end_time");
            References(x => x.Activity).Column("event_type_id");
            References(x => x.Child).Column("child_id");
        }
    }
}
