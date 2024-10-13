using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitsNet;

namespace MauiVerter.MVVM.ViewModels
{
    public class ConverterViewModel
    {
        public string QuantityName {  get; set; }
        public ObservableCollection<string> FromMeasure {  get; set; }
        public ObservableCollection<string> ToMeasures { get; set; }
        public string CurrentFromMeasure { get; set; }
        public string CurrentToMeasure { get; set; }

        public ConverterViewModel() 
        {
            QuantityName = "Length";
            FromMeasure = LoadMeasures();
            ToMeasures = LoadMeasures();
            CurrentFromMeasure = "Meter";
            CurrentToMeasure = "Centimeter";
        }
        private ObservableCollection<string> LoadMeasures()
        {
            var types = Quantity.Infos
                .FirstOrDefault(x => x.Name == QuantityName)
                .UnitInfos
                .Select(u => u.Name)
                .ToList();
            return new ObservableCollection<string>(types);
        }
    }
}
