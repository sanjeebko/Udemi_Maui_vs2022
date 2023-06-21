using Dangl.Calculator;
using PropertyChanged;
using System.Windows.Input;

namespace MauiCalc.MVVM.ViewModels;

[AddINotifyPropertyChangedInterface]
public class CalcViewModel
{
    public CalcViewModel()
    { }

    public string Formula { get; set; }

    public string Result { get; set; } = "0";

    public ICommand OperationCommand => new Command((number) =>
    {
        Formula += number;
    });

    public ICommand ResetCommand => new Command(() =>
    {
        Result = "0"; Formula = string.Empty;
    });

    public ICommand BackSpaceCommand => new Command(() =>
    {
        if (Formula.Length > 0)
        {
            Formula = Formula[..^1];
        }
    });

    public ICommand CalculateCommand => new Command(() =>
    {
        if (Formula.Length == 0)
            return;

        var calculation = Calculator.Calculate(Formula);
        Result = calculation.Result.ToString();
    });
}