# TGTranslate
  ![TGTranslate README Image](./readme-img/img1.png)

## Built with
  ![Static Badge](https://img.shields.io/badge/asp.net-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
  ![Static Badge](https://img.shields.io/badge/bootstrap-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)
  ![Static Badge](https://img.shields.io/badge/OpenAI%20API-black?style=for-the-badge&logo=openaigym&logoColor=%230081A5)
  [![Visual Studio](https://custom-icon-badges.demolab.com/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visualstudio&logoColor=white)](#)

## Setup (To Run Locally)

> [!IMPORTANT]
> 1. Install pre-requisite workload ASP.NET and web development using **Visual Studio Installer** <br/>  
> ![TGTranslate README Image](./readme-img/img2.png)
    
2. Clone this repository
    ```bash
    git clone https://github.com/PanmaTG/TGTranslate.git
    cd TGTranslate
    ```
3. Open the `TGTranslate.slnx` using Visual Studio.

    ```bash
    start TGTranslate.slnx
    ```
<br/>

4. Navigate to TGTranslate\appsettings.json
5. Input your **OpenAI API key**
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "OpenAI": {
    "ApiKey": "YOUR_OPENAI_API_KEY_HERE" // ← Input your OpenAI API key here.
  },
  "AllowedHosts": "*"
}
```
6. Open Developer Terminal (View → Terminal)
7. Install NuGet package "Newtonsoft.Json" by typing the following in Developer terminal
```bash
dotnet add package Newtonsoft.Json --version 13.0.4
```   
8. Run the project by clicking the **Start** or **Start Debugging button** or by pressing **F5**

