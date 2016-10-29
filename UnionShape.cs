using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter
{
    public class UnionShape : Shape
    {

        // اینم پیاده‌ش کن.

        public UnionShape(params LocatedShape[] shapes)
        {
            this.Shapes = new System.Collections.ObjectModel.ReadOnlyCollection<LocatedShape>(shapes);
        }

        public IReadOnlyList<LocatedShape> Shapes { get; }

    }
}
