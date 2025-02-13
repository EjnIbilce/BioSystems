using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioSystems.Exceptions {
    public class UserNotFoundException : Exception {
        public UserNotFoundException() : base("Usuário nã foi encontrado") { }
    }
}
