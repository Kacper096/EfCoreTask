using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreTask.Data.Model
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<TeamMember> Members { get; set; }

        public override string ToString()
        {
            return $" Id: {Id}, Name: {Name}";
        }
    }
}
