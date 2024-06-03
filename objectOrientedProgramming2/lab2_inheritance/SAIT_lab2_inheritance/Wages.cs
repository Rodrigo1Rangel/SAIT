﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIT_lab2_inheritance
{
    internal class Wages : Employee
    {
        private double _rate;
        public double Rate { get { return _rate; } set { _rate = value; } }

        private double _hours;
        public double Hours { get { return _hours; } set { _hours = value; } }

        private float _overtimePaymentRate;
        public float OvertimePaymentRate { get { return _overtimePaymentRate; } set { _overtimePaymentRate = value; } }

        private float _overtimeHourThreshold; 
        public float OvertimeHourThreshold { get { return _overtimeHourThreshold; } set { _overtimeHourThreshold = value; } }

        public Wages(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours) : base(id, name, address, phone, sin, dob, dept)
        {
            //  Wage employees have ID numbers starting with 5-7


            // Calculate payment
            OvertimePaymentRate = 1.5F;
            OvertimeHourThreshold = 40;
            Rate = rate;
            Hours = hours;

            if (Hours > OvertimeHourThreshold)
            {
                WeeklyPayment = rate * OvertimeHourThreshold + (Hours - OvertimeHourThreshold) * rate * OvertimePaymentRate;
            }
            else
            {
                WeeklyPayment = Rate * Hours;
            }
        }
        public double getPay()
        {
            return this.WeeklyPayment;
        }
    }
}
