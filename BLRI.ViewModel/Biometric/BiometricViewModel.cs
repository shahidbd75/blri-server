using System;
using System.Collections.Generic;
using System.Text;
using BLRI.ViewModel.Core;

namespace BLRI.ViewModel.Biometric
{
    public class BiometricViewModel
    {
        public Guid Id { get; set; }
        public int  AnimalCategoryId { get; set; }
        public Guid AnimalId { get; set; }
        public string AnimalNewId { get; set; }
        public long BiometricUnitId { get; set; }
        public string BiometricUnitName { get; set; }
        public double BodyLength { get; set; }
        public double ChestGirth { get; set; }
        public double WitherHeight { get; set; }
        public double HipHeight { get; set; }
        public double RumpLength { get; set; }
        public double RumpWidth { get; set; }
        public double HeadLength { get; set; }
        public double HeadBreadth { get; set; }
        public double NeckLength { get; set; }
        public double NeckBreadth { get; set; }
        public double EarLength { get; set; }
        public double EarBreadth { get; set; }
        public double HornLength { get; set; }
        public double HornCircumference { get; set; }
        public double TailLength { get; set; }
        public double TailCircumference { get; set; }
        public double LegLengthFront { get; set; }
        public double LegLengthHind { get; set; }
        public double TestesLength { get; set; }
        public double TestesBreadth { get; set; }
        public double TestesCircumference { get; set; }
        public double UdderLength { get; set; }
        public double UdderBreadth { get; set; }
        public double UdderCircumference { get; set; }
        public double TeatLength { get; set; }
        public double TeatBreadth { get; set; }
        public double TeatCircumference { get; set; }
    }
}
