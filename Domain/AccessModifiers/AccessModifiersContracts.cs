using System.Collections.Generic;

namespace Domain.AccessModifiers
{
    public interface IProcessAccessModifiers
    {
        List<string> ReadAccessModifiersInfo();
    }
}