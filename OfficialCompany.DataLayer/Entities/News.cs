using System;
using System.Collections.Generic;

namespace OfficialCompany.DataLayer.Entities;

public partial class News
{
    public int NewsId { get; set; }

    public short NewsGroupId { get; set; }

    public string NewsTitle { get; set; }

    public string? NewsDesc { get; set; }

    public string Slug { get; set; }

    public bool IsActive { get; set; }

    public DateTime RegDate { get; set; }
	public required byte[] NewsImage { get; set; }

	public virtual NewsGroup? NewsGroup { get; set; }
}
