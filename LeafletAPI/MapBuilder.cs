namespace LeafletAPI
{
    // All the code in this file is included in all platforms.

    public enum SupportedVersions : short
    {
        v1_7_1 = 171,
        v1_9_4 = 194
    }


    public class MapBuilder
    {
        private SupportedVersions _version;
        private string _htmlHeader = "<!DOCTYPE html>\r\n<html>\r\n<head>";


        public MapBuilder(string version)
        {
            if (!Enum.TryParse(version, out _version))
                throw new NotSupportedException();
            PrepareStructure();
        }

        private void PrepareStructure()
        {
            ComposeHtmlHeader();
            throw new NotImplementedException();
        }

        private void ComposeHtmlHeader()
        {
            _htmlHeader += _version switch
            {
                SupportedVersions.v1_7_1 => "",
                SupportedVersions.v1_9_4 => "",
                _ => throw new NotSupportedException()
            };

        }

        public string Build()
        {
            throw new NotImplementedException();
        }
    }
}