using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioSystems.Exceptions {
    public class WrongPasswordException : Exception {
        public WrongPasswordException() : base("Senha errada") { }
    }
}
