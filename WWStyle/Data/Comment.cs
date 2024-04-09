using System;
using System.Collections.Generic;

namespace WWStyle;

public partial class Comment
{
    public int CommentId { get; set; }

    public int ProductId { get; set; }

    public string UserId { get; set; } = null!;

    public string Text { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}
