# How to install

1. Install a new instance of Sitecore 8.2 Update-5 (SIM recommended)
1. Clone the repository (e.g. to C:\Projects\CarsRUs)
1. Open the solution in Visual Studio
   - Adjust the destination folder in the publishing profile (default is `C:\inetpub\wwwroot\carsrus\Website`)
   - Adjust the sourceFolder setting in `z.CarsRUs.DevSettings.config` (default is `C:\Projects\CarsRUs`)
     *NB: Make sure the IIS user account (usually NETWORK SERVICE) has access to this folder. Unicorn will use it for      serialization.*
1. Publish the project from Visual Studio
1. Open /unicorn.aspx in a browser and do a sync.
1. Open / in a browser.
1. Enjoy :)