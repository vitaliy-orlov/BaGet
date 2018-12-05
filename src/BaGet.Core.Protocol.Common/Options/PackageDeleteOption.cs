using BaGet.Core.Protocol.Common.Enums;

namespace BaGet.Core.Protocol.Common.Options
{
    public class PackageDeleteOption
    {
        /// <summary>
        /// How BaGet should interpret package deletion requests.
        /// </summary>
        public PackageDeletionBehaviorType PackageDeletionBehavior { get; set; } = PackageDeletionBehaviorType.Unlist;
    }
}
