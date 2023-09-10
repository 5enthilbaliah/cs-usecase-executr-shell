# cs-usecase-executr-shell

## Prerequisites
- You should have a local instance of sql server; We recommend to docker compose up the ms-sql-foundation.
- Make sure that the database has the amrita-tribe database. If mot apply migrations from cs-mssql-tribe-crafter

## About project

## Set up
- Clone the repository
```shell
git clone https://github.com/5enthilbaliah/cs-usecase-executr-shell.git
```

## Set up nuget repository (Ubuntu)

### Set up mono
```shell
sudo apt install ca-certificates gnupg
sudo gpg --homedir /tmp --no-default-keyring --keyring /usr/share/keyrings/mono-official-archive-keyring.gpg --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
echo "deb [signed-by=/usr/share/keyrings/mono-official-archive-keyring.gpg] https://download.mono-project.com/repo/ubuntu stable-focal main" | sudo tee /etc/apt/sources.list.d/mono-official-stable.list
sudo apt update
```

```shell
sudo apt install mono-devel

# Download the latest stable `nuget.exe` to `/usr/local/bin`
sudo curl -o /usr/local/bin/nuget.exe https://dist.nuget.org/win-x86-commandline/latest/nuget.exe

# Create as alias for nuget
alias nuget="mono /usr/local/bin/nuget.exe"
```

### Create local Nuget repository
- Create a folder at shells folder level named .private_nuget. Run the below command, replace the {version} with version in nuget pkg.
```shell
nuget add bin/Release/UseCaseExecutR.{version}.nupkg -source ../../.private_nuget/
```

### Update the ubuntu nuget settings 
Nuget config will be found on one of the two below path
- ~/.nuget/NuGet/NuGet.config
- ~/.config/NuGet/NuGet.config

Update this config to include the private directory path we create
```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
    <add key="local" value="/{path_to_shell_folder}/shells/.private_nuget" />
  </packageSources>
</configuration>
```