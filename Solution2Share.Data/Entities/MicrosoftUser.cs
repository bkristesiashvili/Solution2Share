﻿using Microsoft.Graph;

using System;
using System.ComponentModel.DataAnnotations;

namespace Solution2Share.Data.Entities;

public sealed class MicrosoftUser
{
    #region PUBLIC PROPERTIES

    public Guid Id { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }

    public string DisplayName { get; set; }
    
    public string Department { get; set; }

    public string CompanyName { get; set; }

    public string RoleName { get; set; }

    public bool IsActive { get; set; }

    public Guid TenantId { get; set; }

    public DateTime RegisteredAt { get; set; }

    #endregion
}
