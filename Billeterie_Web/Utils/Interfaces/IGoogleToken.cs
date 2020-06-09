using MailKit.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billeterie_Web.Utils.Interfaces
{

    public interface IGoogleToken
    {
        Task<SaslMechanismOAuth2> Token();
    }

}
