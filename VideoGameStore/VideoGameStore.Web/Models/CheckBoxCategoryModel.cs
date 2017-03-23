using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoGameStore.Web.Models
{
    public class CheckBoxModel
    {
        public CheckBoxModel()
        {
        }

        public bool Checked { get; set; }

        public string Name { get; set; }

        public int Id { get; set; }
    }
}