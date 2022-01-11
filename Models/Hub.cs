using System.Collections.Generic;

namespace AnfangAPI.Models
{
    public class Hub
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public virtual List<Plug> Plugs { get; set; }
        public virtual List<Light> Lights  { get; set; }
    }
}