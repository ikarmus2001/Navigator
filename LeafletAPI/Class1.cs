namespace LeafletAPI
{
    // All the code in this file is included in all platforms.

    public enum SupportedVersions : short
    {
        v1_7_1 = 171,
        v1_9_4 = 194
    }


    public class LeafletAPI
    {
        private SupportedVersions _version;

        public LeafletAPI(string version)
        {
            if (!Enum.TryParse(version, out _version))
                throw new NotSupportedException();
            PrepareStructure();
        }

        private void PrepareStructure()
        {
            throw new NotImplementedException();
        }

        public string Build()
        {
            throw new NotImplementedException();
        }
    }
}