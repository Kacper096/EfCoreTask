using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreTask.Data.Model
{
    public class TeamMember : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TitleType Title { get; set; }
        public Guid? TeamId { get; set; }
        public virtual Team Team { get; set; }

        public override string ToString()
        {
            return $" Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, Title: {Title} Team: {Team?.Name ?? "empty"}";
        }
    }
}
