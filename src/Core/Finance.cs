namespace Core;

public sealed record Scenario(double Principal=250000,double MortgageRate=3.5,int Years=25,double Extra=300,double Initial=10000,double ReturnRate=5,double Inflation=2);
public sealed record YearPoint(int Year,double InvestAssets,double PrepayAssets,double InvestDebt,double PrepayDebt,double Savings,double Contributions)
{
    public double InvestNet => InvestAssets-InvestDebt;
    public double PrepayNet => PrepayAssets-PrepayDebt;
}
public sealed record Projection(double Payment,double InvestInterest,double PrepayInterest,int PayoffMonth,IReadOnlyList<YearPoint> Points);
public static class Finance
{
    public static void Validate(Scenario s)
    {
        if (new[]{s.Principal,s.MortgageRate,s.Extra,s.Initial,s.ReturnRate,s.Inflation}.Any(x=>!double.IsFinite(x))) throw new ArgumentException("All inputs must be finite numbers.");
        if(s.Principal<0 || s.Principal>100_000_000 || s.Initial<0 || s.Initial>100_000_000 || s.Extra<0 || s.Extra>100_000 || s.Years<1 || s.Years>50 || s.MortgageRate<0 || s.MortgageRate>30 || s.ReturnRate < -50 || s.ReturnRate>30 || s.Inflation < -10 || s.Inflation>30)
            throw new ArgumentException("Check the input ranges: 1–50 years, mortgage 0–30%, investment −50–30%, inflation −10–30%, and non-negative amounts within the form limits.");
    }
    public static double MonthlyPayment(double principal,double annualPercent,int months)
    {
        if(!double.IsFinite(principal)||!double.IsFinite(annualPercent)||principal<0||annualPercent<0||months<=0)throw new ArgumentException("Invalid mortgage inputs.");
        var r=annualPercent/1200;
        return r==0 ? principal/months : principal*r/(1-Math.Pow(1+r,-months));
    }
    public static Projection Calculate(Scenario s)
    {
        Validate(s);
        var payment=MonthlyPayment(s.Principal,s.MortgageRate,s.Years*12);
        var loanRate=s.MortgageRate/1200;
        // Investment return is an effective annual rate; derive an equivalent monthly rate.
        var growth=Math.Pow(1+s.ReturnRate/100,1d/12);
        var investDebt=s.Principal; var prepayDebt=s.Principal;
        var investAssets=s.Initial;var prepayAssets=s.Initial;var savings=s.Initial;
        double investInterest=0,prepayInterest=0;
        var payoff=s.Principal==0 ? 0 : s.Years*12;
        var points=new List<YearPoint>{new(0,investAssets,prepayAssets,investDebt,prepayDebt,savings,s.Initial)};
        for(int month=1;month<=s.Years*12;month++)
        {
            var i1=investDebt*loanRate;var i2=prepayDebt*loanRate;
            investInterest+=i1;prepayInterest+=i2;
            var paid1=Math.Min(investDebt+i1,payment);
            var paid2=Math.Min(prepayDebt+i2,payment+s.Extra);
            investDebt=Math.Max(0,investDebt+i1-paid1);
            prepayDebt=Math.Max(0,prepayDebt+i2-paid2);
            if(prepayDebt<0.000001 && payoff==s.Years*12)payoff=month;
            // Equal cash budget; all unspent loan budget becomes an end-of-month investment.
            investAssets=investAssets*growth+(payment+s.Extra-paid1);
            prepayAssets=prepayAssets*growth+(payment+s.Extra-paid2);
            savings=savings*growth+s.Extra;
            if(month%12==0)points.Add(new(month/12,investAssets,prepayAssets,investDebt,prepayDebt,savings,s.Initial+s.Extra*month));
        }
        return new(payment,investInterest,prepayInterest,payoff,points);
    }
}
