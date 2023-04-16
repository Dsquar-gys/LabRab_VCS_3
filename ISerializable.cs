using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRab_3
{
    public interface ISerializable
    {
        List<int> yearTable { get; set; }
        List<float> data { get; set; }
        List<float> valueChanges { get; set; }
    }
}
