using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.System;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;

namespace SaphireOS.System.Drivers
{
    public static class FileSystemDriver
    {
        public static CosmosVFS VFS { get; private set; }

        public static void Initialize()
        {
            VFS = new CosmosVFS();
            VFSManager.RegisterVFS(VFS);
        }
    }
}
