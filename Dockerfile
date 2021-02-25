FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster 
# Install NodeJs
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_14.x | bash \
    && apt-get install nodejs -yq \
    && npm install -g @angular/cli 
# End Install
COPY . ./

WORKDIR ./
RUN dotnet run -p TechNinjaz.DigiMenu.Presentation 

