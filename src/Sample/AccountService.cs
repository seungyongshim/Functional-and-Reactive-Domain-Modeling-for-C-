using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageExt;
using static LanguageExt.Prelude;

namespace Sample;

public record Account(string No, string Name, DateTime OpenDate)
{
    public DateTime CloseDate { get; init; }
};

public interface IAccountService<TAccount>
{
    Eff<TAccount> OpenEff(string no, string name, DateTime openDate);
    Eff<TAccount> CloseEff(TAccount account, DateTime closeDate);

}

public class AccountService : IAccountService<Account>
{
    public Eff<Account> OpenEff(string no, string name, DateTime openDate)
    {
        return SuccessEff(new Account(no, name, openDate));
    }

    public Eff<Account> CloseEff(Account account, DateTime closeDate)
    {
        return SuccessEff(account with
        {
            CloseDate = closeDate
        });
    }
}
