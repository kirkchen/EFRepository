using System;
using System.Collections;
using System.Data.Entity;

namespace EFRepository.Hooks
{
    public class HookContext
    {
        public object Entity { get; set; }

        public DbContext DbContext { get; set; }
    }
}