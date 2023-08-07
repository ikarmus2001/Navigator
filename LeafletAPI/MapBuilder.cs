using System;

namespace LeafletAPI
{
    // All the code in this file is included in all platforms.
    public partial class MapBuilder
    {
        private string _htmlHeader = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <meta charset=\"utf-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">";
        private string _htmlBody;

        public MapBuilder()
        {
            PrepareStructure();
        }

        public void mockBody()
        {
            _htmlBody = tmp_bodybuilder();
        }

        private void PrepareStructure()
        {
            ComposeHtmlHeader();
        }

        private void ComposeHtmlHeader()
        {
            _htmlHeader += AddStylesheetPath();
            _htmlHeader += AddScriptPath();
            _htmlHeader += AddStyles();
        }

        private string AddStyles()
        {
            return """
                <style>
                html, body {
                    height: 100%;
                    margin: 0;
                }

                #map {
                    width: 100%;
                    height: 100%;
                }

                .tooltipclass {
                    background: transparent;
                    border: transparent;
                    box-shadow: 0 0px 0px rgba(0,0,0,0);
                }

                .imgclass {
                    display: block;
                    max-width: 400px;
                    max-height: 400px;
                    width: auto;
                    height: auto;
                }
                </style>
            """;
        }

        private string AddScriptPath()
        {
            return """
            <link rel="stylesheet" href="https://unpkg.com/leaflet@1.9.4/dist/leaflet.css" integrity="sha256-p4NxAoJBhIIN+hmNHrzRCf9tD/miZyoHS5obTRR9BMY=" crossorigin="" />
            """;
        }

        private string AddStylesheetPath()
        {
            return """
            <script src="https://unpkg.com/leaflet@1.9.4/dist/leaflet.js" integrity="sha256-20nQCchB9co0qIjJZRGuk2/Z9VM+kNiyxNV1lvTlZBo=" crossorigin=""></script>
            """;
        }

        public HtmlWebViewSource Build()
        {
            if (_htmlBody == null || _htmlBody.Length < 1)
                throw new InvalidOperationException("Body is not initialized");
            var x = new HtmlWebViewSource
            {
                Html = _htmlHeader + "</head>" + _htmlBody + "</html>"
            };
            return x;
        }
    }
}