using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioSystems.Exceptions {
    public class UserAlreadyExistsException : Exception {
        public UserAlreadyExistsException() : base("O usuário já existe") {}
    }
}
