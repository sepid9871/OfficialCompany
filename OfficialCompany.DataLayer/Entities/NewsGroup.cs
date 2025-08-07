using System;
using System.Collections.Generic;

namespace OfficialCompany.DataLayer.Entities;

public partial class NewsGroup
{
    public short NewsGroupId { get; set; }

    public string GroupTitle { get; set; }

    public string Slug { get; set; }

    public bool IsActive { get; set; }

    public DateTime RegDate { get; set; }

    public virtual ICollection<News> News { get; set; } = new List<News>();
}
