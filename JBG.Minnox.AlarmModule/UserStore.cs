using System.Collections;
using JBG.Minnox.Alarm.Contracts;

namespace JBG.Minnox.AlarmModule
{
    public class UserStore : IUserStore
    {
        private readonly Hashtable _codes;

        public UserStore()
        {
            _codes = new Hashtable
                         {
                             {"123", "Wouter"}
                         }; 
        }

        public ValidateCodeResult ValidateCode(string code)
        {
            var result = new ValidateCodeResult {IsValidCode = _codes.Contains(code)};

            result.ValidatedUser = (string) (result.IsValidCode ? _codes[code] : string.Empty);

            return result;
        }
    }
}
