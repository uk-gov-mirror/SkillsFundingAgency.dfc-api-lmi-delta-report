﻿using System.Diagnostics.CodeAnalysis;

namespace DFC.Api.Lmi.Delta.Report.HttpClientPolicies
{
    [ExcludeFromCodeCoverage]
    public class PolicyOptions
    {
        public CircuitBreakerPolicyOptions HttpCircuitBreaker { get; set; } = new CircuitBreakerPolicyOptions();

        public RetryPolicyOptions HttpRetry { get; set; } = new RetryPolicyOptions();
    }
}
