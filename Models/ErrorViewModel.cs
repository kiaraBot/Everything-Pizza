// EverythingPizza - Group Project
// CIS-2284 - November/December 2018
// Group Members: Alix Field, Sharon Goodrich & Jonathan McPeak
// Page: Models/ErrorViewModel.cs

using System;

namespace EverythingPizza.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}