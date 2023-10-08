// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("V4DvkLVN2MgAN7tvy6IFLWRIKm57+Pb5yXv48/t7+Pj5XV9AoXRqe9NmkmElvq5YcgxFriQyh0jtSg4PyXv428n0//DTf7F/DvT4+Pj8+frtvmF7uhovkPj9kMuspr1iiuVXSrm85aFElXSvNPdRbtPUQ1gz7G7DRrMiV3GcguhKHIe7bzCFVeQKFouMxTpgre/3SGRUDdf69shV4IT7oIVyrRZ+IA2aszYZh0PaO/1QrS9addJMX4UzdVJwc14Yb1w8kUYfhx3q1yQ7/iWtXoUOKWx8su92T8kTur9tptHDrXifXyJ777WrrPpbPv8fbXujebgrYwy2bCMzyCs8L3i8+Gxq0B5ahYB6rMVs4dK1/0gAr+7qq9udFod0pekDHPv6+Pn4");
        private static int[] order = new int[] { 5,1,8,5,8,10,9,9,9,10,11,11,13,13,14 };
        private static int key = 249;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
