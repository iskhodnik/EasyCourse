﻿using System;

namespace InputFormParanoid
{
    public class Task
    {
        public enum TaskFields
        {
            name,
            startDate,
            endDate,
            estimate,
            description,
        }

        private string name;
        private DateTime startDate;
        private DateTime endDate;
        private float estimate;
        private string description;

        public string GetName() => name;
        public DateTime GetStartDate() => startDate;
        public DateTime GetEndDate() => endDate;
        public float GetTimeEvaluation() => estimate;
        public string GetDescription() => description;

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetStartDate(DateTime startDate)
        {
            this.startDate = startDate;
        }

        public void SetEndDate(DateTime endDate)
        {
            this.endDate = endDate;
        }

        public void SetEstimate(float estimate)
        {
            this.estimate = estimate;
        }

        public void SetDescription(string description)
        {
            this.description = description;
        }
    }
}
