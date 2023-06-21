using Microsoft.Maui.Media;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UnitsNet;

namespace MauiVerter.MVVM.ViewModels;

[AddINotifyPropertyChangedInterface]
public class ConverterViewModel
{
    public string QuantityName { get; set; }
    public ObservableCollection<string> FromMeasures { get; set; }
    public ObservableCollection<string> ToMeasures { get; set; }
    public string CurrentFromMeasures { get; set; }
    public string CurrentToMeasures { get; set; }

    public double FromValue { get; set; } = 1;
    public double ToValue { get; set; }

    public ICommand ReturnCommand => new Command(() => { Convert(); });

    public ConverterViewModel(string quantityName)
    {
        QuantityName = quantityName;
        FromMeasures = LoadMeasures();
        ToMeasures = LoadMeasures();
        CurrentFromMeasures = FromMeasures.FirstOrDefault();
        CurrentToMeasures = ToMeasures.Skip(1).FirstOrDefault();
        Convert();
    }

    public void Convert()
    {
        ToValue = UnitConverter.ConvertByName(FromValue, QuantityName, CurrentFromMeasures, CurrentToMeasures);
    }

    private ObservableCollection<string> LoadMeasures()
    {
        var types = Quantity.Infos.FirstOrDefault(a => a.Name == QuantityName)?.UnitInfos.Select(u => u.Name).ToList();

        return new ObservableCollection<string>(types);
    }
}