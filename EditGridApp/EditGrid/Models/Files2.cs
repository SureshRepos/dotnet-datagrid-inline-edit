using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EditGrid.Models;

public partial class Files2 
{
   
    public int FileId { get; set; }

    public string FileName { get; set; }

    public string FileType { get; set; }

    public string PersonName { get; set; }

    public string FilePath { get; set; }

    [NotMapped]
    public bool IsEditing { get; set; } // For edit page only

}
