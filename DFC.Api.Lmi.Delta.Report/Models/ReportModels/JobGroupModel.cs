﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DFC.Api.Lmi.Delta.Report.Models.ReportModels
{
    [ExcludeFromCodeCoverage]
    public class JobGroupModel
    {
        public int Soc { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime TransformedDate { get; set; } = DateTime.UtcNow;

        public DateTime LastCached { get; set; } = DateTime.UtcNow;

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Qualifications { get; set; }

        public string? Tasks { get; set; }

        public IList<JobProfileModel>? JobProfiles { get; set; }

        public JobGrowthPredictionModel? JobGrowth { get; set; }

        public QualificationLevelModel? QualificationLevel { get; set; }

        public IList<BreakdownModel>? EmploymentByRegion { get; set; }

        public IList<BreakdownModel>? TopIndustriesInJobGroup { get; set; }
    }
}
