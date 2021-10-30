using System.Collections.Generic;
using Domain.AccessModifiers;

namespace Engine.AccessModifiers
{
    public class AccessModifiersProcess : IProcessAccessModifiers
    {
        public List<string> ReadAccessModifiersInfo() => _accessModifiers;

        private readonly List<string> _accessModifiers = new()
        {
            "public: It can be accessed by any other code in the same assembly or another assembly that references it.",
            "private: It can be accessed only by code in the same class or struct.",
            "protected: It can be accessed only by code in the same class, or in a class that is derived from that class.",
            "internal: It can be accessed by any code in the same assembly, but not from another assembly.",
            "protected internal: It can be accessed by any code in the assembly in which it's declared, or from within a derived class in another assembly.",
            "private protected: It can be accessed only within its declaring assembly, by code in the same class or in a type that is derived from that class."
        };
    }
}