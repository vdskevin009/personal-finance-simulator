using Core;
static void Near(double actual,double expected,double tolerance,string name){if(Math.Abs(actual-expected)>tolerance)throw new Exception($"{name}: {actual} != {expected}");}
Near(Finance.MonthlyPayment(120000,0,120),1000,1e-8,"Zero interest payment");
Near(Finance.MonthlyPayment(200000,6,360),1199.101,0.001,"Known amortization payment");
var flat=Finance.Calculate(new(120000,0,10,100,1000,0,0));
Near(flat.Points[^1].Savings,13000,0.001,"Zero return savings");
Near(flat.Points[^1].InvestNet,flat.Points[^1].PrepayNet,0.001,"Equal budgets at zero rates");
var growth=Finance.Calculate(new(0,0,10,0,1000,10,0));Near(growth.Points[^1].Savings,1000*Math.Pow(1.1,10),1e-5,"Annual effective rate");
var equal=Finance.Calculate(new(250000,4,25,0,10000,5,2));Near(equal.Points[^1].InvestNet,equal.Points[^1].PrepayNet,1e-5,"No extra gives identical strategies");
var prepay=Finance.Calculate(new());if(prepay.PrepayInterest>=prepay.InvestInterest || prepay.PayoffMonth>=300)throw new Exception("Prepay reduces interest and term");
var negative=Finance.Calculate(new(0,0,1,0,1000,-20,0));Near(negative.Points[^1].Savings,800,1e-6,"Negative returns");
try{Finance.Calculate(new(ReturnRate:double.NaN));throw new Exception("NaN accepted");}catch(ArgumentException){}
try{Finance.Calculate(new(Years:0));throw new Exception("Invalid horizon accepted");}catch(ArgumentException){}
Console.WriteLine("PASS: known payment, zero rates, equal budgets, compounding, prepayment, negative returns and invalid inputs (10 checks)");
