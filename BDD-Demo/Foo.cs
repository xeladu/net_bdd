using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BDD_Demo;
public class Foo
{
    public string SomeValue { get; private set; }

    public Foo()
    {
        SomeValue = "";
    }

    public void Activate()
    {
        var bar = new Bar();
        SomeValue = bar.Calculate();
    }
}

public class Bar
{
    public string Calculate()
    {
        return "dummy";
    }
}
