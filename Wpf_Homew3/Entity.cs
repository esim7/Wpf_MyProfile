using System;
using System.Collections.Generic;
using System.Text;

namespace Wpf_Homew3
{
    public class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
