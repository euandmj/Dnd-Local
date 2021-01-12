using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndL.Core.Extensions
{
    public static class EnumFieldExtension
    {

        public static T GetAttributeFromEnumField<T>(this Enum @this)
            where T : Attribute
        {
            var type = @this.GetType();
            var memInfo = type.GetMember(@this.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }

    }
}
