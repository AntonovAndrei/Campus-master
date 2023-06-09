﻿using Domain.SharedKernel;

namespace Domain.Entities;

public class News : BaseEntity
{
    public News()
    {
        PhotoIds = new HashSet<Photo>();
    }
    public DateTime CreateDate { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid MainPhotoId { get; set; }
    
    public Guid CreatedEmployeeId { get; set; }
    public virtual Employee Employee { get; set; }
    
    public virtual ICollection<Photo> PhotoIds { get; set; }
}