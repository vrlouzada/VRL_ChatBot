﻿namespace VRL_ChatBot.Domain.Response
{
    public sealed class SafetyRating
    {
        public string Category { get; set; } = string.Empty;
        public string Probability { get; set; } = string.Empty;
    }
}
