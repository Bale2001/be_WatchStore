using System;
using System.Collections.Generic;

namespace be_watchStore.DATA;

public partial class Staff
{
    public int StaffId { get; set; }

    public string? StaffName { get; set; }

    public bool? StaffSex { get; set; }

    public string? StaffAdress { get; set; }

    public string? StaffPhone { get; set; }

    public DateTime? StaffBirthday { get; set; }
}
