﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace BPCalculator
{
    // BP categories
    public enum BPCategory
    {
        [Display(Name = "Low Blood Pressure")] Low,
        [Display(Name = "Ideal Blood Pressure")] Ideal,
        [Display(Name = "Pre-High Blood Pressure")] PreHigh,
        [Display(Name = "High Blood Pressure")] High
    };

    public class BloodPressure
    {
        public const int SystolicMin = 70;
        public const int SystolicMax = 190;
        public const int DiastolicMin = 40;
        public const int DiastolicMax = 100;

        [Range(SystolicMin, SystolicMax, ErrorMessage = "Invalid Systolic Value")]
        public int Systolic { get; set; }                       // mmHg

        [Range(DiastolicMin, DiastolicMax, ErrorMessage = "Invalid Diastolic Value")]
        public int Diastolic { get; set; }                      // mmHg

        // Calculate BP category
        public BPCategory Category
        {
            get
            {
                // ---------------------------------------------
                // Check for low blood pressure
                // Systolic < 90 OR Diastolic < 60
                // ---------------------------------------------
                if (Systolic < 90 || Diastolic < 60)
                {
                    return BPCategory.Low;
                }

                // ---------------------------------------------
                // Ideal (Normal) blood pressure
                // Systolic between 90–119 AND Diastolic between 60–79
                // ---------------------------------------------
                if (Systolic >= 90 && Systolic <= 119 &&
                    Diastolic >= 60 && Diastolic <= 79)
                {
                    return BPCategory.Ideal;
                }

                // ---------------------------------------------
                // Pre-High blood pressure
                // Systolic between 120–139 OR Diastolic between 80–89
                // ---------------------------------------------
                if ((Systolic >= 120 && Systolic <= 139) ||
                    (Diastolic >= 80 && Diastolic <= 89))
                {
                    return BPCategory.PreHigh;
                }

                // ---------------------------------------------
                // High blood pressure
                // Systolic ≥ 140 OR Diastolic ≥ 90
                // ---------------------------------------------
                if (Systolic >= 140 || Diastolic >= 90)
                {
                    return BPCategory.High;
                }

                // ---------------------------------------------
                // Default (should not normally be reached)
                // ---------------------------------------------
                return BPCategory.Ideal;
            }
        }
    }
}
